
namespace PlaceholderWebApi
{
	class Program
	{
		static void Main()
		{
			// Create the configuration
			var configuration = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();

			// Create the service collection and add the configuration
			var services = new ServiceCollection();
			services.AddOptions();
			services.Configure<PlaceholderOptions>(configuration.GetSection("Placeholder"));

			// Build the service provider
			var serviceProvider = services.BuildServiceProvider();

			// Resolve the configuration with placeholders
			var placeholderConfiguration = serviceProvider.GetRequiredService<IConfiguration>();

			// Access the configuration value with placeholders resolved
			var mySetting = placeholderConfiguration.GetValue<string>("MySetting");
			Console.WriteLine(mySetting);

			// Wait for user input before closing the console window
			Console.ReadLine();
		}
	}
	public class PlaceholderOptions
	{
		public string Name { get; set; }
	}
	//public class Program
	//{
	//	public static void Main(string[] args)
	//	{
	//		var builder = WebApplication.CreateBuilder(args);

	//		// Add services to the container.

	//		builder.Services.AddControllers();
	//		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	//		builder.Services.AddEndpointsApiExplorer();
	//		builder.Services.AddSwaggerGen();

	//		var app = builder.Build();

	//		// Configure the HTTP request pipeline.
	//		if (app.Environment.IsDevelopment())
	//		{
	//			app.UseSwagger();
	//			app.UseSwaggerUI();
	//		}

	//		app.UseHttpsRedirection();

	//		app.UseAuthorization();


	//		app.MapControllers();

	//		app.Run();
	//	}
	//}
}