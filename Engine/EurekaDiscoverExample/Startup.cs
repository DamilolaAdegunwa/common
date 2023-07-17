using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Discovery.Client;
using System;
using Steeltoe.Common.Hosting;
using Steeltoe.Common.Http.Discovery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Management.Tracing;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Steeltoe.Connector.MySql;
//using Steeltoe.Connector.MySql.EFCore;
using Steeltoe.Management.Tracing;
using OpenTelemetry.Trace;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Context.Propagation;
using OpenTelemetry.Exporter;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Steeltoe.Common;
using Steeltoe.Common.Reflection;
using Steeltoe.Management.Endpoint.Health;
using Steeltoe.Management.Endpoint;
//using Steeltoe.Logging;
//using Steeltoe.Management.Wavefront.Exporters;
//using B3Propagator = OpenTelemetry.Extensions.Propagators.B3Propagator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Management.Endpoint.CloudFoundry;
using Steeltoe.Management.Tracing;

namespace EurekaDiscoverExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddHttpClient(AppConstants.EurekaDiscoverExample, client => client.BaseAddress = new Uri("http://EurekaDiscoverExample:5000/")).AddServiceDiscovery().AddRandomLoadBalancer();
			services.AddHttpClient(AppConstants.EurekaRegisterExample, client => client.BaseAddress = new Uri("http://EurekaRegisterExample:5001/")).AddServiceDiscovery().AddRoundRobinLoadBalancer();

			services.AddDiscoveryClient(Configuration);
            services.AddControllers();
            services.AddHealthActuator(Configuration);
            services.AddDistributedTracing();
            //services.AddDistributedTracing(Configuration, b => b.);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EurekaDiscoverExample", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EurekaDiscoverExample"));
            }

			//app.UseHttpsRedirection();
			app.UseDiscoveryClient(); // Enable Steeltoe's DiscoveryClient middleware
			//app.UseHealthActuator();
			//app.UseCloudFoundryActuator();
			app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
