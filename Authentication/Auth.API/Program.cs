using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace Auth.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Microsoft.AspNetCore.Server.IIS.Core.IO.AsyncIOEngine;
            //Microsoft.AspNetCore.Server.IIS.Core.IISHttpContext;
            EventSource eventSource = new EventSource("myEventSource");
            eventSource.Write("myEvent");
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
