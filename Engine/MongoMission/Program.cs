using MongoMission.Core.Models;
using MongoMission.Core.Repositories;
using MongoMission.Core.Repositories.Interfaces;
using MongoMission.Core.Services;
using MongoMission.Core.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//app settings config
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//add unit of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//add repo
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();

//add processor
builder.Services.AddScoped<IProcessor, Processor>();

//add services
builder.Services.AddScoped<ICustomerRelationshipService, CustomerRelationshipService>();
builder.Services.AddScoped<IEcommerceService, EcommerceService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<INotificationHubService, NotificationHubService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<IShoppingService, ShoppingService>();
builder.Services.AddScoped<ISupplyChainManagementService, SupplyChainManagementService>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
