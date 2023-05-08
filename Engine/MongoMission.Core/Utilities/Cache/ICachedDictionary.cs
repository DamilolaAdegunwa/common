using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Utilities.Cache
{
    public interface ICachedDictionary<TValue> : ICached
    {
        void RefreshIfExpired();
        void RefreshIfExpired(TimeSpan ttl);
        void Refresh();
        void Update(IDictionary<string, TValue> items);
        void ExtendTTL();
        TValue Get(string key);
        TValue Find(string key);
        bool IsExpired(TimeSpan ttl);
    }
}
