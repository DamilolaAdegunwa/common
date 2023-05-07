﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
//using Quickteller.Core.Services;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Quickteller.Core.Caching
{
    public partial class RedisCacheManager : IStaticCacheManager
    {
        #region Fields
        private readonly IConfiguration _config;
        private readonly ICacheManager _perRequestCacheManager;
        private readonly IRedisConnectionWrapper _connectionWrapper;
        private string _redisDataProtectionKey = "Isw.Redis_key";
        private int _cacheTime = 5;
        private readonly IDatabase _db;

        #endregion

        protected string GetConnectionString()
        {
            // return _config.GetConnectionString("RedisConnectionString");
            return default;
            //return _quicktellerSettingsManager.QtIntlConnectionStrings;
        }
        //ISettingsManager _quicktellerSettingsManager;
        #region Ctor

        public RedisCacheManager(ICacheManager perRequestCacheManager,
            IRedisConnectionWrapper connectionWrapper,
            //ISettingsManager quicktellerSettingsManager,
            IConfiguration config)
        {

           // _quicktellerSettingsManager = quicktellerSettingsManager;
            //if (string.IsNullOrEmpty(config.GetConnectionString("RedisConnectionString")))
            //    throw new Exception("Redis connection string is empty");

            this._perRequestCacheManager = perRequestCacheManager;

            // ConnectionMultiplexer.Connect should only be called once and shared between callers
            this._connectionWrapper = connectionWrapper;
            this._config = config;
            this._db = _connectionWrapper.GetDatabase();
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Gets the list of cache keys prefix
        /// </summary>
        /// <param name="endPoint">Network address</param>
        /// <param name="prefix">String key pattern</param>
        /// <returns>List of cache keys</returns>
        protected virtual IEnumerable<RedisKey> GetKeys(EndPoint endPoint, string prefix = null)
        {
            var server = _connectionWrapper.GetServer(endPoint);

            //we can use the code below (commented), but it requires administration permission - ",allowAdmin=true"
            //server.FlushDatabase();

            var keys = server.Keys(_db.Database, string.IsNullOrEmpty(prefix) ? null : $"{prefix}*");

            //we should always persist the data protection key list
            keys = keys.Where(key => !key.ToString().Equals(_redisDataProtectionKey, StringComparison.OrdinalIgnoreCase));

            return keys;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Key of cached item</param>
        /// <returns>The cached value associated with the specified key</returns>
        public virtual async Task<T> GetAsync<T>(string key)
        {
            //little performance workaround here:
            //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
            //this way we won't connect to Redis server many times per HTTP request (e.g. each time to load a locale or setting)
            if (_perRequestCacheManager.IsSet(key))
                return _perRequestCacheManager.Get(key, () => default(T), 0);

            //get serialized item from cache
            var serializedItem = await _db.StringGetAsync(key);
            if (!serializedItem.HasValue)
                return default(T);

            //deserialize item
            var item = JsonConvert.DeserializeObject<T>(serializedItem);
            if (item == null)
                return default(T);

            //set item in the per-request cache
            _perRequestCacheManager.Set(key, item, 0);

            return item;
        }

        /// <summary>
        /// Adds the specified key and object to the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <param name="data">Value for caching</param>
        /// <param name="cacheTime">Cache time in minutes</param>
        public virtual async Task SetAsync(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            //set cache time
            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            //serialize item
            var serializedItem = JsonConvert.SerializeObject(data);

            //and set it to cache
            await _db.StringSetAsync(key, serializedItem, expiresIn);
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <returns>True if item already is in cache; otherwise false</returns>
        protected virtual async Task<bool> IsSetAsync(string key)
        {
            //little performance workaround here:
            //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
            //this way we won't connect to Redis server many times per HTTP request (e.g. each time to load a locale or setting)
            if (_perRequestCacheManager.IsSet(key))
                return true;

            return await _db.KeyExistsAsync(key);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get a cached item. If it's not in the cache yet, then load and cache it
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <param name="cacheTime">Cache time in minutes; pass 0 to do not cache; pass null to use the default time</param>
        /// <returns>The cached value associated with the specified key</returns>
        public async Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int? cacheTime = null)
        {
            //item already is in cache, so return it
            if (await IsSetAsync(key))
                return await GetAsync<T>(key);

            //or create it using passed function
            var result = await acquire();

            //and set in cache (if cache time is defined)
            if ((cacheTime ?? _cacheTime) > 0)
                await SetAsync(key, result, cacheTime ?? _cacheTime);

            return result;
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Key of cached item</param>
        /// <returns>The cached value associated with the specified key</returns>
        public virtual T Get<T>(string key)
        {
            //little performance workaround here:
            //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
            //this way we won't connect to Redis server many times per HTTP request (e.g. each time to load a locale or setting)
            if (_perRequestCacheManager.IsSet(key))
                return _perRequestCacheManager.Get(key, () => default(T), 0);

            //get serialized item from cache
            var serializedItem = _db.StringGet(key);
            if (!serializedItem.HasValue)
                return default(T);

            //deserialize item
            var item = JsonConvert.DeserializeObject<T>(serializedItem);
            if (item == null)
                return default(T);

            //set item in the per-request cache
            _perRequestCacheManager.Set(key, item, 0);

            return item;
        }

        /// <summary>
        /// Get a cached item. If it's not in the cache yet, then load and cache it
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <param name="cacheTime">Cache time in minutes; pass 0 to do not cache; pass null to use the default time</param>
        /// <returns>The cached value associated with the specified key</returns>
        public virtual T Get<T>(string key, Func<T> acquire, int? cacheTime = null)
        {
            //item already is in cache, so return it
            if (IsSet(key))
                return Get<T>(key);

            //or create it using passed function
            var result = acquire();

            //and set in cache (if cache time is defined)
            if ((cacheTime ?? _cacheTime) > 0)
                Set(key, result, cacheTime ?? _cacheTime);

            return result;
        }

        /// <summary>
        /// Adds the specified key and object to the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <param name="data">Value for caching</param>
        /// <param name="cacheTime">Cache time in minutes</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            //set cache time
            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            //serialize item
            var serializedItem = JsonConvert.SerializeObject(data);

            //and set it to cache
            _db.StringSet(key, serializedItem, expiresIn);
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">Key of cached item</param>
        /// <returns>True if item already is in cache; otherwise false</returns>
        public virtual bool IsSet(string key)
        {
            //little performance workaround here:
            //we use "PerRequestCacheManager" to cache a loaded object in memory for the current HTTP request.
            //this way we won't connect to Redis server many times per HTTP request (e.g. each time to load a locale or setting)
            if (_perRequestCacheManager.IsSet(key))
                return true;

            return _db.KeyExists(key);
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        public virtual void Remove(string key)
        {
            //we should always persist the data protection key list
            if (key.Equals(_redisDataProtectionKey, StringComparison.OrdinalIgnoreCase))
                return;

            //remove item from caches
            _db.KeyDelete(key);
            _perRequestCacheManager.Remove(key);
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">Key of cached item</param>
        public virtual async Task RemoveAsync(string key)
        {
            //we should always persist the data protection key list
            if (key.Equals(_redisDataProtectionKey, StringComparison.OrdinalIgnoreCase))
                return;

            //remove item from caches
            await _db.KeyDeleteAsync(key);
            _perRequestCacheManager.Remove(key);
        }



        /// <summary>
        /// Removes items by key prefix
        /// </summary>
        /// <param name="prefix">String key prefix</param>
        public virtual void RemoveByPrefix(string prefix)
        {
            _perRequestCacheManager.RemoveByPrefix(prefix);

            foreach (var endPoint in _connectionWrapper.GetEndPoints())
            {
                var keys = GetKeys(endPoint, prefix);

                _db.KeyDelete(keys.ToArray());
            }
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public virtual void Clear()
        {
            foreach (var endPoint in _connectionWrapper.GetEndPoints())
            {
                var keys = GetKeys(endPoint).ToArray();

                //we cant use _perRequestCacheManager.Clear(),
                //because HttpContext stores some server data that we should not delete
                foreach (var redisKey in keys)
                {
                    _perRequestCacheManager.Remove(redisKey.ToString());
                }

                _db.KeyDelete(keys);
            }
        }

        /// <summary>
        /// Dispose cache manager
        /// </summary>
        public virtual void Dispose()
        {
            //if (_connectionWrapper != null)
            //    _connectionWrapper.Dispose();
        }

        #endregion
    }

}
