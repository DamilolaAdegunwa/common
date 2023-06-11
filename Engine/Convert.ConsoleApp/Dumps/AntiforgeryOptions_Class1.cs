using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace ExerciseApp.ConsoleApp.Dumps
{
	internal class AntiforgeryOptions_Class1
	{
	}


	class Program_AntiforgeryOptions_Class1
	{
		static void Main_AntiforgeryOptions_Class1()
		{
			// Create a new instance of AntiforgeryOptions
			var antiforgeryOptions = new AntiforgeryOptions
			{
				Cookie = new CookieBuilder
				{
					Name = "MyAntiforgeryCookie",
					HttpOnly = true,
					SecurePolicy = CookieSecurePolicy.Always
				},
				FormFieldName = "MyAntiforgeryField",
				HeaderName = "X-CSRF-TOKEN",
				SuppressXFrameOptionsHeader = true,
				
				//RequireSsl = true,
				//SuppressXFrameOptionsHeaderWhenNoCookies = false
			};

			// Create an instance of IServiceCollection and add Antiforgery services
			var services = new ServiceCollection();
			services.AddAntiforgery(options =>
			{
				options.HeaderName = antiforgeryOptions.HeaderName;
			});

			// Build the service provider
			var serviceProvider = services.BuildServiceProvider();

			// Resolve the IAntiforgery service
			var antiforgery = serviceProvider.GetRequiredService<IAntiforgery>();

			// Generate an antiforgery token
			var tokenSet = antiforgery.GetAndStoreTokens(new DefaultHttpContext());

			// Print the generated token
			Console.WriteLine("Generated Antiforgery Token:");
			Console.WriteLine("Request Token: " + tokenSet.RequestToken);
			Console.WriteLine("Header Name: " + tokenSet.HeaderName);
			Console.WriteLine("Cookie Token: " + tokenSet.CookieToken);

			Console.ReadLine();
		}
	}

}
