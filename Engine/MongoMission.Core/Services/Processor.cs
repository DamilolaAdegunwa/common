using MongoMission.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMission.Core.Services
{
    public class Processor : IProcessor
    {
        public Processor(
        ICustomerRelationshipService customerRelationshipService,
        IEcommerceService ecommerceService,
        IInventoryService inventoryService,
        INotificationHubService notificationHubService,
        IPaymentService paymentService,
        IReportService reportService,
        ISalesService salesService,
        IShoppingService shoppingService,
        ISupplyChainManagementService supplyChainManagementService)
        {
            CustomerRelationshipService = customerRelationshipService;
            EcommerceService = ecommerceService;
            InventoryService = inventoryService;
            NotificationHubService = notificationHubService;
            PaymentService = paymentService;
            ReportService = reportService;
            SalesService = salesService;
            ShoppingService = shoppingService;
            SupplyChainManagementService = supplyChainManagementService;
        }

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
