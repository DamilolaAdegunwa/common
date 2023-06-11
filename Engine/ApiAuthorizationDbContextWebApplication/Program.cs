using ApiAuthorizationDbContextWebApplication.Persistence;
using ApiAuthorizationDbContextWebApplication.Services;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Disable certificate validation
Validations.DisableCertificateValidation();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(
		//Configuration.GetConnectionString("DefaultConnection")
		builder.Configuration.GetConnectionString("DefaultConnection")
		)
	);

// Register the IUserClaimsPrincipalFactory<TUser> with its implementation
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddUserManager<UserManager<ApplicationUser>>()
	.AddSignInManager<SignInManager<ApplicationUser>>()
	.AddDefaultTokenProviders();

// IdentityServer configuration
builder.Services.AddIdentityServer()
	.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

// IdentityServer operational store configuration
builder.Services.Configure<OperationalStoreOptions>(options =>
{
	options.ConfigureDbContext = configDb =>
	{
		configDb.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
		//configDb.
	};
	//options.
});

// Other service configurations...

//builder.Services.AddControllers();

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
