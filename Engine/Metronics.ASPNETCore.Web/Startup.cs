using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
namespace Metronics.ASPNETCore.Web
{
    public class Startup
    {
        public string AllowAll => "AllowAll";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowAll,
                    build =>
                    {
                        build.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddMvc(options=> { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseCors(AllowAll);
            app.UseDefaultFiles();
            app.UseDirectoryBrowser();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/dammy", async context =>
                {
                    //It ignores view pages and write directly to the output stream
                    await context.Response.WriteAsync("Hello World! from earthling-131363116 Lockdown-Base: Lagos-NG-Ilupeju-CokerRoad");
                });
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=home}/{action=index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
                endpoints.MapRazorPages();
            });
            
            app.UseWelcomePage();
        }
    }
}
