using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();

        void BeginTransaction();
        void Commit();
        void Rollback();
        public TDbContext GetOrCreateDbContext<TDbContext>() where TDbContext : DbContext;
    }
}
