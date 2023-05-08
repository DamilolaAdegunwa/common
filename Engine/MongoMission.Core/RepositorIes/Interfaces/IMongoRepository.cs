using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Repositories.Interfaces
{
    public interface IMongoRepository<T>
    {
        List<T> Get();
        Task<IList<T>> GetAllAsync();
        Task<T> GetAsync(ObjectId id);
        Task<IList<T>> GetAsync(Expression<Func<T, bool>> query);
        Task<IList<T>> GetAsync(Expression<Func<T, bool>> query, int page, int pageSize);
        Task<IList<T>> GetAndSortDescAsync(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderDesc, int pageSize);
        Task<T> SaveAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(ObjectId id);
        Task<bool> DeleteAsync(T obj);
        IMongoCollection<T> GetCollection();
        IMongoDatabase GetDatabse();
        bool Ping();
    }
}
