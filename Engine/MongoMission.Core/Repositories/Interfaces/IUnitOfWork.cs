using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICartRepository Cart { get; }
        ICommentRepository Comment { get; }
        ICustomerRepository Customer { get; }
        IInvoiceRepository Invoice { get; }
        INotificationRepository Notification { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        IReceiptRepository Receipt { get; }
        ITransactionRepository Transaction { get; }
        IWalletRepository Wallet { get; }
    }
}
