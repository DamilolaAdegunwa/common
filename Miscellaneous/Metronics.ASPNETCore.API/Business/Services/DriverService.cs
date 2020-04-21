using Metronics.ASPNETCore.API.Core.Domain.DTOs;
using Metronics.ASPNETCore.API.Core.Domain.Entities;
using Metronics.ASPNETCore.API.Core.Domain.Entities.Common;
using Metronics.ASPNETCore.API.Data.Repository;
using Metronics.ASPNETCore.API.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Metronics.ASPNETCore.API.Business.Services
{
    public interface IDriverService
    {
        #region commented out some driver services
        //#region Select/Get/Query
        //IQueryable<IEntity> GetAll();
        //IQueryable<Driver> GetAllIncluding(params Expression<Func<Driver, object>>[] propertySelectors);
        //List<Driver> GetAllList();
        //Task<List<Driver>> GetAllListAsync();
        //List<Driver> GetAllList(Expression<Func<Driver, bool>> predicate);
        //Task<List<Driver>> GetAllListAsync(Expression<Func<Driver, bool>> predicate);
        //T Query<T>(Func<IQueryable<Driver>, T> queryMethod);
        //Driver Get(long id);
        //Task<Driver> GetAsync(long id);
        //Driver Single(Expression<Func<Driver, bool>> predicate);
        //Task<Driver> SingleAsync(Expression<Func<Driver, bool>> predicate);
        //Driver FirstOrDefault(long id);
        //Task<Driver> FirstOrDefaultAsync(long id);
        //Driver FirstOrDefault(Expression<Func<Driver, bool>> predicate);
        //Task<Driver> FirstOrDefaultAsync(Expression<Func<Driver, bool>> predicate);
        //Task<bool> ExistAsync(Expression<Func<Driver, bool>> predicate);
        //Driver Load(long id);
        //#endregion

        //#region Insert
        //Driver Insert(Driver entity);
        //Task<Driver> InsertAsync(Driver entity);
        //long InsertAndGetId(Driver entity);
        //Task<long> InsertAndGetIdAsync(Driver entity);
        //Driver InsertOrUpdate(Driver entity);
        //Task<Driver> InsertOrUpdateAsync(Driver entity);
        //long InsertOrUpdateAndGetId(Driver entity);
        //Task<long> InsertOrUpdateAndGetIdAsync(Driver entity);
        //#endregion

        //#region Update
        //Driver Update(Driver entity);
        //Task<Driver> UpdateAsync(Driver entity);
        //Driver Update(long id, Action<Driver> updateAction);
        //Task<Driver> UpdateAsync(long id, Func<Driver, Task> updateAction);
        //#endregion

        //#region Delete
        //void Delete(Driver entity);
        //Task DeleteAsync(Driver entity);
        //void Delete(long id);
        //Task DeleteAsync(long id);
        //void Delete(Expression<Func<Driver, bool>> predicate);
        //Task DeleteAsync(Expression<Func<Driver, bool>> predicate);

        //#endregion

        //#region Aggregates
        //int Count();
        //Task<int> CountAsync();
        //int Count(Expression<Func<Driver, bool>> predicate);
        //Task<int> CountAsync(Expression<Func<Driver, bool>> predicate);
        //long LongCount();
        //Task<long> LongCountAsync();
        //long LongCount(Expression<Func<Driver, bool>> predicate);
        //Task<long> LongCountAsync(Expression<Func<Driver, bool>> predicate);

        //#endregion
        #endregion

        #region driver-specific services
        Task<DriverDTO> GetActiveDriverByCodeAsync(string DriverCode);
        //Task<DriverDTO> GetActiveDriverByVehicleAsync(string regnum);
        //Task<List<DriverDTO>> GetAllAvailableDriversAsync();
        //Task<List<DriverDTO>> GetAvailableDriversAsync();
        //Task AddDriver(DriverDTO driver);
        //Task AddCredentialForExistingDriver();
        //Task<List<DriverDTO>> GetAvailableDriversForTripCountAsync();
        //Task<List<JourneyManagementDTO>> GetAvailableJourneyMangementCount(string DriverCode, int StartDay, int EndDay);
        //Task<DriverDTO> GetDriverByBusNumberAsync(string busNumber);
        //Task<DriverDTO> GetDriverByCodeAsync(string DriverCode);
        //Task<DriverDTO> GetDriverByVehicleAsync(string regnum);
        //Task<IPagedList<DriverDTO>> GetDriversAsync(int pageNumber, int pageSize, string searchTerm);
        //Task<List<DriverDTO>> GetVirtualDriversAsync();
        //void RemoveAssignedVehicle(string DriverCode);
        //Task<Driver> FirstOrDefaultAsync(Expression<Func<Driver, bool>> filter);
        //Task<bool> ExistAsync(Expression<Func<Driver, bool>> filter);
        //Task<Driver> GetAsync(int id);
        //Task<DriverDTO> GetDriverById(int? id);
        //Task<DriverDTO> GetDriverByEmail(string email);
        //Task UpdateDriver(int id, DriverDTO model);
        //Task RemoveDriver(int id);
        //IQueryable<Driver> GetAll();
        //Task<DriverDTO> GetDriverByVehicleRegNum(string regnum);
        //Task<DriverDTO> GetDriverByVehicleId(string id);
        //Task PayDriver(WalletTransactionDTO model);
        //Task UpdateDriverWallet(string code, decimal Amount);
        //Task<IPagedList<WalletTransactionDTO>> GetDriverTransaction(string code, int pageNumber, int pageSize, string search);
        //Task<WalletTransactionDTO> GetDriverWalletTransactionById(Guid id);
        //Task UpdateDriverWalletTransaction(Guid Id, WalletTransactionDTO model);
        //Task<bool> UpdateDriverPayment(string code);
        //Task RemovePayment(Guid id);
        //Task<IPagedList<DriverDTO>> DriverDetails(int pageNumber, int pageSize, string searchTerm);
        //Task<IPagedList<WalletTransactionDTO>> PilotApproval(TransactionStatus status, int pageNumber, int pageSize);
        //Task<List<WalletTransactionDTO>> GetPilotTransactionDetail(string code, int type);
        //Task<bool> VerifyPilotTransaction(string code);
        //Task<bool> VerifyAllPilotTransaction();
        //Task<bool> ApprovePilotTransaction(string code);
        //Task<bool> ApproveAllPilotTransaction();
        //Task<List<WalletTransactionDTO>> PilotPaySlip(SearchDTO search);
        //Task<IPagedList<WalletTransactionDTO>> PilotPaySchedule(SearchDTO date, int pageNumber, int pageSize, string search);
        //Task<decimal> GetDeductedWalletBalance(string code);
        //Task<decimal> ResetWalletBalance(string code, decimal Amount);
        //Task<IPagedList<WalletTransactionDTO>> PilotApprovalReport(SearchDTO date, int pageNumber, int pageSize, string search);
        //Task<List<WalletTransactionDTO>> GetPilotApprovalDetails(DateTime startdate, DateTime enddate, string code);
        //Task<IPagedList<WalletTransactionDTO>> GetPilotsCapturedPayment(DateModel date, int pageNumber, int pageSize, string search);
        #endregion
    }

    public class DriverService : IDriverService
    {
        private readonly IRepository<Driver> _driverRepo;
        private readonly IServiceHelper _serviceHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userSvc;
        public DriverService(
            IRepository<Driver> driverRepo,
            IServiceHelper serviceHelper, 
            IUnitOfWork unitOfWork,
            IUserService userSvc
            )
        {
            _driverRepo = driverRepo;
            _serviceHelper = serviceHelper;
            _unitOfWork = unitOfWork;
            _userSvc = userSvc;
        }

        public Task<DriverDTO> GetActiveDriverByCodeAsync(string DriverCode)
        {
            throw new NotImplementedException();
        }
    }
}
