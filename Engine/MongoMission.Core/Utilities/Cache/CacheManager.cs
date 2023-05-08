using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Utilities.Cache
{
    public interface ICacheManager
    {
        ICached<T> GetCache<T>(Type host);
        ICached<T> GetCache<T>(Type host, string name);
        ICached<T> GetRollingCache<T>(Type host, string name, TimeSpan defaultLifeTime);
        ICachedDictionary<T> GetCacheDictionary<T>(Type host, string name, Func<IDictionary<string, T>> fetchFunc = null, TimeSpan? lifeTime = null);
        void Clear();
        ICollection<ICached> Caches { get; }
    }

    public class CacheManager : ICacheManager
    {
        private readonly ICached<ICached> _cache;

        public CacheManager()
        {
            _cache = new Cached<ICached>();
        }

        public void Clear()
        {
            _cache.Clear();
        }

        public ICollection<ICached> Caches => _cache.Values;

        public ICached<T> GetCache<T>(Type host)
        {
            //Ensure.That(host, () => host).IsNotNull();
            if(host == null) { throw new ArgumentNullException(nameof(host)); }
            return GetCache<T>(host, host.FullName);
        }

        public ICached<T> GetCache<T>(Type host, string name)
        {
            //Ensure.That(host, () => host).IsNotNull();
            if (host == null) { throw new ArgumentNullException(nameof(host)); }
            //Ensure.That(name, () => name).IsNotNullOrWhiteSpace();
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(host)); }
            return (ICached<T>)_cache.Get(host.FullName + "_" + name, () => new Cached<T>());
        }

        public ICached<T> GetRollingCache<T>(Type host, string name, TimeSpan defaultLifeTime)
        {
            //Ensure.That(host, () => host).IsNotNull();
            if (host == null) { throw new ArgumentNullException(nameof(host)); }
            //Ensure.That(name, () => name).IsNotNullOrWhiteSpace();
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(host)); }

            return (ICached<T>)_cache.Get(host.FullName + "_" + name, () => new Cached<T>(defaultLifeTime, true));
        }

        public ICachedDictionary<T> GetCacheDictionary<T>(Type host, string name, Func<IDictionary<string, T>> fetchFunc = null, TimeSpan? lifeTime = null)
        {
            //Ensure.That(host, () => host).IsNotNull();
            if (host == null) { throw new ArgumentNullException(nameof(host)); }
            //Ensure.That(name, () => name).IsNotNullOrWhiteSpace();
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(host)); }

            return (ICachedDictionary<T>)_cache.Get("dict_" + host.FullName + "_" + name, () => new CachedDictionary<T>(fetchFunc, lifeTime));
        }
    }
}
