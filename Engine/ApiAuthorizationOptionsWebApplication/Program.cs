using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add code here
// Add authentication services
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
	// Configure JWT bearer authentication options
	options.TokenValidationParameters = new TokenValidationParameters
	{
		// Configure token validation parameters
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = "your-issuer",
		ValidAudience = "your-audience",
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"))
	};
});
// Add authorization services
builder.Services.AddAuthorization(options =>
{
	// Configure authorization policies
	options.AddPolicy("AdminOnly", policy =>
	{
		policy.RequireAuthenticatedUser();
		policy.RequireRole("Admin");
	});

	options.AddPolicy("UserOnly", policy =>
	{
		policy.RequireAuthenticatedUser();
		policy.RequireRole("User");
	});
});

// Configure API authorization options
//builder.Services.Configure<ApiAuthorizationOptions>(options =>
//{
//	options.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
//	options.DefaultAnonymousPolicy = new AuthorizationPolicyBuilder()
//		.RequireAuthenticatedUser()
//		.Build();
//});
// Configure API authorization options
builder.Services.Configure<ApiAuthorizationOptions>(options =>
{
	#region 1) SigningCredential
	// Set the signing credentials for JWT tokens
	// Generate an RSA key pair
	RSA rsa = RSA.Create();
	RSAParameters rsaParams = rsa.ExportParameters(true);

	// Create a new instance of RSA using the generated key pair
	RSA rsaKey = RSA.Create();
	rsaKey.ImportParameters(rsaParams);

	// Create a new instance of SecurityKey using the RSA key
	SecurityKey securityKey = new RsaSecurityKey(rsaKey);

	// You can also specify additional properties for the SecurityKey if needed
	securityKey.KeyId = "my-key-id";

	// Use the securityKey in your code as needed
	options.SigningCredential = new SigningCredentials(/* Your signing key */securityKey, SecurityAlgorithms.RsaSha256);
	#endregion

	#region 2) clients
	// Configure the clients that can access the API
	var clients = new List<Duende.IdentityServer.Models.Client>
	{
		new Duende.IdentityServer.Models.Client
		{
			ClientId = "client1",
			AllowedGrantTypes = GrantTypes.ClientCredentials,
			ClientSecrets =
			{
				new Duende.IdentityServer.Models.Secret("clientSecret".Sha256())
			},
			AllowedScopes = { "apiScope1", "apiScope2" }
		},
        // Add more clients as needed
    };
	options.Clients = new ClientCollection(clients) {  };
	#endregion

	#region 3) api resources
	// Configure the API resources
	var apiResources = new List<Duende.IdentityServer.Models.ApiResource>
	{
		new Duende.IdentityServer.Models.ApiResource("api1", "API 1"),
		new Duende.IdentityServer.Models.ApiResource("api2", "API 2")
        // Add more API resources as needed
    };
	options.ApiResources = new ApiResourceCollection(apiResources) { };
	#endregion

	#region 4) api scopes
	// Configure the API scopes
	var apiScopes = new List<Duende.IdentityServer.Models.ApiScope> { 
		new Duende.IdentityServer.Models.ApiScope
		{
			Name = "apiScope1"
		},
	};
	options.ApiScopes = new ApiScopeCollection(apiScopes) { };
	#endregion

	#region 5) identity resources
	// Configure the identity resources
	var identityResources = new List<Duende.IdentityServer.Models.IdentityResource>
	{
		new IdentityResources.OpenId(),
		new IdentityResources.Profile(),
        // Add more identity resources as needed
    };
	options.IdentityResources = new IdentityResourceCollection(identityResources);
	#endregion
});

// Add other services and dependencies
// ...
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
