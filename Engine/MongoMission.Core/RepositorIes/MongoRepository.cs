using MongoDB.Driver;
using MongoMission.Core.Models.Collections;
using MongoMission.Core.Models;
using MongoMission.Core.RepositorIes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MongoMission.Core.Utilities;
using MongoDB.Bson;
using System.Linq.Expressions;
using MongoMission.Core.Models.Collections.Base;

namespace MongoMission.Core.RepositorIes
{
    public class MongoRepository<T> : IMongoRepository<T> where T : BaseEntity
    {
        private readonly AppSettings _appSettings;
        private readonly IMongoCollection<T> _collection;
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;
        public MongoRepository(IOptions<AppSettings> options, string collectionName)
        {
            //get the product collection
            _appSettings = options.Value;
            _collectionName = collectionName;
            string connStr = _appSettings.DatabaseConnection.ConnectionString;
            var databaseName = MongoUrl.Create(connStr).DatabaseName;
            var mongoClient = new MongoClient(connStr);
            _database = mongoClient.GetDatabase(databaseName);
            _collection = _database.GetCollection<T>(collectionName);//collection <=> table
        }

        public List<T> Get()
        {
            var filterdefinition = Builders<T>.Filter.Empty;
            var list = _collection.Find(filterdefinition).ToList();
            return list;
        }

        public IMongoCollection<T> GetCollection()
        {
            return _collection;
        }

        public IMongoDatabase GetDatabse()
        {
            return _database;
        }

        public bool Ping()
        {
            bool isMongoLive = false;
            try
            {
                isMongoLive = _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait(5000);//5sec

            }
            catch (Exception)
            {

            }

            return isMongoLive;
        }

        public virtual async Task<bool> DeleteAsync(ObjectId id)
        {
            var result = await _collection.DeleteOneAsync(t => t.Id == id);

            return result.IsAcknowledged;
        }

        public virtual async Task<bool> DeleteAsync(T obj)
        {
            return await DeleteAsync(obj.Id);
        }

        public virtual async Task<T> GetAsync(ObjectId id)
        {
            IFindFluent<T, T> findFluent = _collection.Find(x => x.Id == id);
            findFluent = findFluent.Limit(1);
            T data = await findFluent.FirstOrDefaultAsync();

            return data;
        }

        public virtual async Task<IList<T>> GetAsync(Expression<Func<T, bool>> query, int page, int pageSize)
        {
            if (page <= 0) page = 1;

            if (pageSize < 0) pageSize = 100;

            var queryable = _collection.Find(query).Skip(page - 1).Limit(pageSize);

            var result = await queryable.ToListAsync();

            return result;
        }

        public async Task<IList<T>> GetAndSortDescAsync(Expression<Func<T, bool>> query, Expression<Func<T, object>> orderDesc, int pageSize)
        {
            var queryable = _collection.Find(query)
                .SortByDescending(orderDesc)
                .Limit(pageSize).ToListAsync();

            return await queryable;
        }


        public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> query)
        {
            var queryable = await _collection.Find(query).ToListAsync();

            return queryable;
        }

        public virtual async Task<IList<T>> GetAllAsync()
        {
            var result = await _collection.Find(_ => true).ToListAsync();

            return result;
        }

        public virtual async Task<T> SaveAsync(T obj)
        {
            await _collection.InsertOneAsync(obj);

            return obj;
        }

        public virtual async Task<T> UpdateAsync(T obj)
        {
            var result = await _collection.ReplaceOneAsync(t => t.Id == obj.Id, obj, new UpdateOptions
            {
                IsUpsert = true
            });

            return obj;
        }
    }
}
