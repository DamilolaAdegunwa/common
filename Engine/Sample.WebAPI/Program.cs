using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json;

namespace Sample.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/bson"));
            //Task<Stream> stream = client.GetStreamAsync("http://localhost:50006/api/values/GetAll");
            Task<Stream> stream = client.GetStreamAsync("~/WeatherForecast/Get");

            MemoryStream result = new MemoryStream();
            stream.Result.CopyTo(result);
            result.Seek(0, SeekOrigin.Begin);

            using (BsonReader reader = new BsonReader(result) { ReadRootValueAsArray = true })
            {
                var jsonSerializer = new JsonSerializer();
                var output = jsonSerializer.Deserialize<IEnumerable<MyType>>(reader);
                foreach (var item in output)
                {
                    Console.WriteLine(item.Name);
                }
            }
            
        }
        public class MyType
        {
            public string Name { get; set; }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
