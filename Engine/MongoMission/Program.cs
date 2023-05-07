using MongoMission.Core.Models;
using MongoMission.Core.RepositorIes;
using MongoMission.Core.RepositorIes.Interfaces;
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

//add repo
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//add services
builder.Services.AddScoped<ISalesService, SalesService>();

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
