using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Steeltoe.Extensions.Logging;
using Steeltoe.Management.Endpoint;

namespace EurekaDiscoverExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
            .ConfigureLogging((context, builder) => builder.AddDynamicConsole())
            .AddHealthActuator()
            .AddInfoActuator()
            .AddLoggersActuator()
            .AddAllActuators();

		//"/actuator/health"
		//"/actuator/info"
		/*
         {
    "status": "UP",
    "details": {
        "ping": null,
        "eurekaServer": {
            "remoteInstStatus": "UNKNOWN",
            "fetch": "Successful",
            "fetchStatus": "UP",
            "fetchTime": "2023-07-14T15:25:37",
            "heartbeatStatus": "Not registering",
            "status": "UP",
            "applications": {
                "EUREKAREGISTEREXAMPLE": 1,
                "EUREKAADDEDEXAMPLE": 1
            }
        },
        "liveness": {
            "LivenessState": "CORRECT"
        },
        "readiness": {
            "ReadinessState": "ACCEPTING_TRAFFIC"
        },
        "diskSpace": {
            "total": 1004236247040,
            "free": 629827604480,
            "threshold": 10485760,
            "status": "UP"
        }
    }
}

        //info
        {"applicationVersionInfo":{"ProductName":"EurekaDiscoverExample","FileVersion":"1.0.0.0","ProductVersion":"1.0.0"},"steeltoeVersionInfo":{"ProductName":"Steeltoe.Management.EndpointBase","FileVersion":"3.2.3.0","ProductVersion":"3.2.3\u002B34c1143068dd1ccc8d1903698be90292ed5371a3"},"build":{"version":"1.0.0.0"}}
         */
	}
}
