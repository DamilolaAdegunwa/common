using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.Placeholder;
using Steeltoe.Extensions.Configuration.RandomValue;
namespace PlaceholderWebApi
{
	//class Program
	//{
	//	static void Main()
	//	{
	//		// Create the configuration
	//		var configuration = new ConfigurationBuilder().AddPlaceholderResolver()
	//			.SetBasePath(AppContext.BaseDirectory)
	//			.AddJsonFile("appsettings.json")
	//			.Build();

	//		// Create the service collection and add the configuration
	//		var services = new ServiceCollection();
	//		services.AddSingleton<IConfiguration>(configuration);
	//		services.AddOptions();
	//		services.Configure<PlaceholderOptions>(configuration.GetSection("Placeholder"));

	//		// Build the service provider
	//		var serviceProvider = services.BuildServiceProvider();

	//		// Resolve the configuration with placeholders
	//		var placeholderConfiguration = serviceProvider.GetRequiredService<IConfiguration>();

	//		// Access the configuration value with placeholders resolved
	//		var mySetting = placeholderConfiguration.GetValue<string>("MySetting");
	//		Console.WriteLine(mySetting);

	//		// Wait for user input before closing the console window
	//		Console.ReadLine();
	//	}
	//}
	public class PlaceholderOptions
	{
		public string Name { get; set; }
	}
	public class Program
	{
		public static void Main(string[] args)
		{
			//1) test placeholder
			var builder = WebApplication.CreateBuilder(args).AddPlaceholderResolver();
			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddOptions();
			builder.Services.Configure<PlaceholderOptions>(builder.Configuration.GetSection("Placeholder"));
			//var serviceProvider = builder.Services.BuildServiceProvider();
			//serviceProvider.
			var mySetting = builder.Configuration.GetValue<string>("MySetting");

			//test random value source
			builder.Configuration.AddRandomValueSource();

			//var configuration = new ConfigurationBuilder().AddPlaceholderResolver()
			//	.AddRandomValueSource()
			//	.SetBasePath(AppContext.BaseDirectory)
			//	.AddJsonFile("appsettings.json")
			//	.Build();

			var app = builder.Build();
			//var PortNumberRand = configuration.GetValue<string>("PortNumberRand");
			//var ProjectCodeNameRand = builder.Configuration.GetValue<string>("ProjectCodeNameRand");
			//var ProjectRefRand = builder.Configuration.GetValue<long>("ProjectRefRand");
			//var ProjectIdRand = builder.Configuration.GetValue<Guid>("ProjectIdRand");
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
		}
	}
}

/*
 
static void MigrationScript2(string directory, string connectionstring)
{
    //var connectionString = _config.ConnectionString;
    EnsureDatabase.For.MySqlDatabase(connectionstring);

    var dbUpgradeEngine = DeployChanges.To.MySqlDatabase(connectionstring)
        .WithScriptsEmbeddedInAssembly(typeof(Program).Assembly)
        .WithTransactionPerScript()
        .LogToConsole()
        .Build();

    //var dbUpgradeEngine = dbUpgradeEngineBuilder.Build();

    if (dbUpgradeEngine.IsUpgradeRequired())
    {
        //_logger.WriteInformation("Upgrades have been detected. Upgrading database now... ");
        var operation = dbUpgradeEngine.PerformUpgrade();

        if (operation.Successful)
        {
           // _logger.WriteInformation("Upgrade completed successfully");
        }
        else
        {
           // _logger.WriteInformation("Error happened in the upgrade. Please check the logs");
        }
    }

    //return next;
}
 */