using Steeltoe.Extensions.Configuration.RandomValue;
namespace RandomValueWebApi
{
	public class RandomValueOptions
	{
		public string Secret { get; set; }
		public string ApiKey { get; set; }
	}
	public class Program
	{
		static void Main()
		{
			// Create the configuration
			var configuration = new ConfigurationBuilder().AddRandomValueSource()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();

			// Create the service collection and add the configuration
			var services = new ServiceCollection();
			services.AddSingleton<IConfiguration>(configuration);
			services.AddOptions();
			var RSectn = services.Configure<RandomValueOptions>(configuration.GetSection("RandomValue"));
			
			// Build the service provider
			var serviceProvider = services.BuildServiceProvider();

			// Resolve the configuration with random values
			var randomValueConfiguration = serviceProvider.GetRequiredService<IConfiguration>();

			// Access the configuration values with random values
			var secret = configuration.GetValue<string>("RandomValue:Secret");
			var apiKey = configuration.GetValue<string>("RandomValue:ApiKey");

			Console.WriteLine("Secret: " + secret);
			Console.WriteLine("API Key: " + apiKey);

			// Wait for user input before closing the console window
			Console.ReadLine();
		}
	}
	//public class Program
	//{
	//	//public static void Main(string[] args)
	//	//{
	//	//	var builder = WebApplication.CreateBuilder(args);

	//	//	// Add services to the container.

	//	//	builder.Services.AddControllers();
	//	//	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	//	//	builder.Services.AddEndpointsApiExplorer();
	//	//	builder.Services.AddSwaggerGen();

	//	//	var app = builder.Build();

	//	//	// Configure the HTTP request pipeline.
	//	//	if (app.Environment.IsDevelopment())
	//	//	{
	//	//		app.UseSwagger();
	//	//		app.UseSwaggerUI();
	//	//	}

	//	//	app.UseHttpsRedirection();

	//	//	app.UseAuthorization();


	//	//	app.MapControllers();

	//	//	app.Run();
	//	//}
	//}
}