using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#region added
using System;
using System.Threading.Tasks;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
//using IdentityServer4.EntityFramework.Options;
#endregion
namespace ApiAuthorizationDbContextWebApplication.Persistence
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
	{
		//public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		//	: base(options)
		//{
		//}
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
			IOptions<OperationalStoreOptions> operationalStoreOptions)
			: base(options, operationalStoreOptions)
		{
		}
	}

	public class ApplicationUser : IdentityUser
	{
		// Additional user properties can be added here
	}
}
/*
 dotnet add package Microsoft.AspNetCore.ApiAuthorization.IdentityServer
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.AspNetCore.ApiAuthorization.IdentityServer
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package IdentityServer4.EntityFramework.Storage

 */