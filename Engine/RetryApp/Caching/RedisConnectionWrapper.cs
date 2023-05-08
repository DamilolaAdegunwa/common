using Microsoft.Extensions.Configuration;
//using Quickteller.Core.Services;
using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Net;

namespace Quickteller.Core.Caching
{
    /// <summary>
    /// Represents Redis connection wrapper implementation
    /// </summary>
    public class RedisConnectionWrapper : IRedisConnectionWrapper, ILocker
    {
        #region Fields

        private readonly IConfiguration _config;
        ISettingsManager _quicktellerSettingsManager;

        private readonly object _lock = new object();
        private volatile ConnectionMultiplexer _connection;
        private readonly Lazy<string> _connectionString;
        private volatile RedLockFactory _redisLockFactory;

        #endregion

        #region Ctor

        public RedisConnectionWrapper(IConfiguration config, ISettingsManager quicktellerSettingsManager)
        {
            this._quicktellerSettingsManager = quicktellerSettingsManager;
            this._config = config;
            this._connectionString = new Lazy<string>(GetConnectionString);
            this._redisLockFactory = CreateRedisLockFactory();


        }

        #endregion

        #region Utilities

        /// <summary>
        /// Get connection string to Redis cache from configuration
        /// </summary>
        /// <returns></returns> 
        protected string GetConnectionString()
        {
            // return _config.GetConnectionString("RedisConnectionString");

            return _quicktellerSettingsManager.QtIntlConnectionStrings;
        }

        /// <summary>
        /// Get connection to Redis servers
        /// </summary>
        /// <returns></returns>
        protected StackExchange.Redis.ConnectionMultiplexer GetConnection()
        {
            if (_connection != null && _connection.IsConnected) return _connection;

            lock (_lock)
            {
                if (_connection != null && _connection.IsConnected) return _connection;

                _connection?.Dispose();

                if (_quicktellerSettingsManager.UseRedisSentinel && _quicktellerSettingsManager.RedisSentinelInstances != null && _quicktellerSettingsManager.RedisSentinelInstances.Any())
                {
                    _connection = GenerateSentinalConfig();
                }

                _connection = ConnectionMultiplexer.Connect(_connectionString.Value);
            }

            return _connection;
        }

        public ConnectionMultiplexer GenerateSentinalConfig()
        {
            ConfigurationOptions sentinelConfig = new ConfigurationOptions();
            foreach (var p in _quicktellerSettingsManager.RedisSentinelInstances)
            {
                if (p.Contains(':'))
                    sentinelConfig.EndPoints.Add(p);
            }

            sentinelConfig.TieBreaker = "";
            sentinelConfig.CommandMap = CommandMap.Sentinel;
            sentinelConfig.AbortOnConnectFail = false;
            sentinelConfig.SyncTimeout = 3000;
            //Creating new instance of Redis Connection
            _connection = ConnectionMultiplexer.Connect(sentinelConfig, Console.Out);

            return _connection;
        }

        /// <summary>
        /// Create instance of RedLock factory
        /// </summary>
        /// <returns>RedLock factory</returns>
        protected RedLockFactory CreateRedisLockFactory()
        {
            //get RedLock endpoints
            var configurationOptions = ConfigurationOptions.Parse(_connectionString.Value);
            // configurationOptions.AbortOnConnectFail = true;
            configurationOptions.ConnectRetry = _quicktellerSettingsManager.RedisConnectRetry;


            var redLockEndPoints = GetEndPoints().Select(endPoint => new RedLockEndPoint
            {
                EndPoint = endPoint,
                Password = configurationOptions.Password,
                Ssl = configurationOptions.Ssl,
                RedisDatabase = configurationOptions.DefaultDatabase,
                ConfigCheckSeconds = configurationOptions.ConfigCheckSeconds,
                ConnectionTimeout = configurationOptions.ConnectTimeout,
                SyncTimeout = configurationOptions.SyncTimeout
            }).ToList();

            //create RedLock factory to use RedLock distributed lock algorithm
            return RedLockFactory.Create(redLockEndPoints);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Obtain an interactive connection to a database inside Redis
        /// </summary>
        /// <param name="db">Database number</param>
        /// <returns>Redis cache database</returns>
        public IDatabase GetDatabase(int? db)
        {
            return GetConnection().GetDatabase(db ?? -1);
        }


        /// <summary>
        /// Obtain a configuration API for an individual server
        /// </summary>
        /// <param name="endPoint">The network endpoint</param>
        /// <returns>Redis server</returns>
        public IServer GetServer(EndPoint endPoint)
        {
            return GetConnection().GetServer(endPoint);
        }

        /// <summary>
        /// Gets all endpoints defined on the server
        /// </summary>
        /// <returns>Array of endpoints</returns>
        public EndPoint[] GetEndPoints()
        {
            return GetConnection().GetEndPoints();
        }

        /// <summary>
        /// Delete all the keys of the database
        /// </summary>
        /// <param name="db">Database number</param>
        public void FlushDatabase(int? db = null)
        {
            var endPoints = GetEndPoints();

            foreach (var endPoint in endPoints)
            {
                GetServer(endPoint).FlushDatabase(db ?? -1);
            }
        }

        /// <summary>
        /// Perform some action with Redis distributed lock
        /// </summary>
        /// <param name="resource">The thing we are locking on</param>
        /// <param name="expirationTime">The time after which the lock will automatically be expired by Redis</param>
        /// <param name="action">Action to be performed with locking</param>
        /// <returns>True if lock was acquired and action was performed; otherwise false</returns>
        public bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action)
        {
            //use RedLock library
            using (var redisLock = _redisLockFactory.CreateLock(resource, expirationTime))
            {
                //ensure that lock is acquired
                if (!redisLock.IsAcquired)
                    return false;

                //perform action
                action();

                return true;
            }
        }

        /// <summary>
        /// Release all resources associated with this object
        /// </summary>
        public void Dispose()
        {
            //dispose ConnectionMultiplexer
            _connection?.Dispose();

            //dispose RedLock factory
            _redisLockFactory?.Dispose();
        }

        #endregion
    }

    public interface ISettingsManager
    {
        string QtIntlConnectionStrings { get; set; }
        bool UseRedisSentinel { get; set; }
        List<string> RedisSentinelInstances { get; set; }
        int RedisConnectRetry { get; set; }
    }
}
