using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Utilities.Cache
{
    public interface ICached
    {
        void Clear();
        void ClearExpired();
        void Remove(string key);
        int Count { get; }
    }

    public interface ICached<T> : ICached
    {
        void Set(string key, T value, TimeSpan? lifetime = null);
        T Get(string key, Func<T> function, TimeSpan? lifeTime = null);
        T Find(string key);

        ICollection<T> Values { get; }
    }
}
