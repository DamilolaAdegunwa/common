using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Services.Interfaces
{
    public interface IProcessor
    {
        public ICustomerRelationshipService CustomerRelationshipService { get; }
        public IEcommerceService EcommerceService { get; }
        public IInventoryService InventoryService { get; }
        public INotificationHubService NotificationHubService { get; }
        public IPaymentService PaymentService { get; }
        public IReportService ReportService { get; }
        public ISalesService SalesService { get; }
        public IShoppingService ShoppingService { get; }
        public ISupplyChainManagementService SupplyChainManagementService { get; }
    }
}
