using MongoMission.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
        ICartRepository cartRepository,
        ICommentRepository commentRepository,
        ICustomerRepository customerRepository,
        IInvoiceRepository invoiceRepository,
        INotificationRepository notificationRepository,
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IReceiptRepository receiptRepository,
        ITransactionRepository transactionRepository,
        IWalletRepository walletRepository)
        {
            Cart = cartRepository;
            Comment = commentRepository;
            Customer = customerRepository;
            Invoice = invoiceRepository;
            Notification = notificationRepository;
            Order = orderRepository;
            Product = productRepository;
            Receipt = receiptRepository;
            Transaction = transactionRepository;
            Wallet = walletRepository;
        }

        public ICartRepository Cart { get; }
        public ICommentRepository Comment { get; }
        public ICustomerRepository Customer { get; }
        public IInvoiceRepository Invoice { get; }
        public INotificationRepository Notification { get; }
        public IOrderRepository Order { get; }
        public IProductRepository Product { get; }
        public IReceiptRepository Receipt { get; }
        public ITransactionRepository Transaction { get; }
        public IWalletRepository Wallet { get; }
    }
}
