using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IPagedList;
using Metronics.ASPNETCore.API.Core.Domain.DTOs;

namespace Metronics.ASPNETCore.API.Business.Services
{
    public interface IDriverService
    {
        Task<DriverDTO> GetActiveDriverByCodeAsync(string DriverCode);
        Task<DriverDTO> GetActiveDriverByVehicleAsync(string regnum);
        Task<List<DriverDTO>> GetAllAvailableDriversAsync();
        Task<List<DriverDTO>> GetAvailableDriversAsync();
        Task AddDriver(DriverDTO driver);
        Task AddCredentialForExistingDriver();
        Task<List<DriverDTO>> GetAvailableDriversForTripCountAsync();
        //Task<List<JourneyManagementDTO>> GetAvailableJourneyMangementCount(string DriverCode, int StartDay, int EndDay);
        Task<DriverDTO> GetDriverByBusNumberAsync(string busNumber);
        Task<DriverDTO> GetDriverByCodeAsync(string DriverCode);
        Task<DriverDTO> GetDriverByVehicleAsync(string regnum);
        Task<IPagedList<DriverDTO>> GetDriversAsync(int pageNumber, int pageSize, string searchTerm);
        Task<List<DriverDTO>> GetVirtualDriversAsync();
        void RemoveAssignedVehicle(string DriverCode);
        Task<Driver> FirstOrDefaultAsync(Expression<Func<Driver, bool>> filter);
        Task<bool> ExistAsync(Expression<Func<Driver, bool>> filter);
        Task<Driver> GetAsync(int id);
        Task<DriverDTO> GetDriverById(int? id);
        Task<DriverDTO> GetDriverByEmail(string email);
        Task UpdateDriver(int id, DriverDTO model);
        Task RemoveDriver(int id);
        IQueryable<Driver> GetAll();
        Task<DriverDTO> GetDriverByVehicleRegNum(string regnum);
        Task<DriverDTO> GetDriverByVehicleId(string id);
        Task PayDriver(WalletTransactionDTO model);
        Task UpdateDriverWallet(string code, decimal Amount);
        Task<IPagedList<WalletTransactionDTO>> GetDriverTransaction(string code, int pageNumber, int pageSize, string search);
        Task<WalletTransactionDTO> GetDriverWalletTransactionById(Guid id);
        Task UpdateDriverWalletTransaction(Guid Id, WalletTransactionDTO model);
        Task<bool> UpdateDriverPayment(string code);
        Task RemovePayment(Guid id);
        Task<IPagedList<DriverDTO>> DriverDetails(int pageNumber, int pageSize, string searchTerm);
        Task<IPagedList<WalletTransactionDTO>> PilotApproval(TransactionStatus status, int pageNumber, int pageSize);
        Task<List<WalletTransactionDTO>> GetPilotTransactionDetail(string code, int type);
        Task<bool> VerifyPilotTransaction(string code);
        Task<bool> VerifyAllPilotTransaction();
        Task<bool> ApprovePilotTransaction(string code);
        Task<bool> ApproveAllPilotTransaction();
        Task<List<WalletTransactionDTO>> PilotPaySlip(SearchDTO search);
        Task<IPagedList<WalletTransactionDTO>> PilotPaySchedule(SearchDTO date, int pageNumber, int pageSize, string search);
        Task<decimal> GetDeductedWalletBalance(string code);
        Task<decimal> ResetWalletBalance(string code, decimal Amount);
        Task<IPagedList<WalletTransactionDTO>> PilotApprovalReport(SearchDTO date, int pageNumber, int pageSize, string search);
        Task<List<WalletTransactionDTO>> GetPilotApprovalDetails(DateTime startdate, DateTime enddate, string code);
        Task<IPagedList<WalletTransactionDTO>> GetPilotsCapturedPayment(DateModel date, int pageNumber, int pageSize, string search);
    }
}
