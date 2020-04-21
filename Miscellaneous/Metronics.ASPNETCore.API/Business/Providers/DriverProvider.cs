using Metronics.ASPNETCore.API.Business.Services;
using Metronics.ASPNETCore.API.Core.Domain.Entities;
using Metronics.ASPNETCore.API.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Business.Providers
{
    public interface IDriverProvider<TEntity> where TEntity : Driver
    {
        #region Select/Get/Query
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);
        List<TEntity> GetAllList();
        Task<List<TEntity>> GetAllListAsync();
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);
        TEntity Get(long id);
        Task<TEntity> GetAsync(long id);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(long id);
        Task<TEntity> FirstOrDefaultAsync(long id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity Load(long id);
        #endregion

        #region Insert
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        long InsertAndGetId(TEntity entity);
        Task<long> InsertAndGetIdAsync(TEntity entity);
        TEntity InsertOrUpdate(TEntity entity);
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        long InsertOrUpdateAndGetId(TEntity entity);
        Task<long> InsertOrUpdateAndGetIdAsync(TEntity entity);
        #endregion

        #region Update
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        TEntity Update(long id, Action<TEntity> updateAction);
        Task<TEntity> UpdateAsync(long id, Func<TEntity, Task> updateAction);
        #endregion

        #region Delete
        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);
        void Delete(long id);
        Task DeleteAsync(long id);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Aggregates
        int Count();
        Task<int> CountAsync();
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        long LongCount();
        Task<long> LongCountAsync();
        long LongCount(Expression<Func<TEntity, bool>> predicate);
        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }

    public class DriverProvider<TEntity> : IDriverService, IDriverProvider<TEntity> where TEntity : Driver
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriverProvider(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }

    public static class DriverExtension : IDriverService
    {

    }
}
