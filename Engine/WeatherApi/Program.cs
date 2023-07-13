using Steeltoe.Common.Hosting;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;

namespace WeatherApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args).UseCloudHosting();

            // Add services to the container.

            builder.Services.AddDiscoveryClient();
            builder.Services.AddHttpClient("weather", client => client.BaseAddress = new Uri("http://weatherapi/")).AddServiceDiscovery();
            //builder.Services.AddHttpClient("weather", client => client.BaseAddress = new Uri("http://localhost:5051/")).AddServiceDiscovery();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

            app.UseDiscoveryClient();
            app.Run();
        }
    }
}