using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using System;
using System.Reflection;
using Castle.Core.Interceptor;

namespace ConvertApp.ConsoleApp.Services.Others
{
	public interface IService
	{
		void PerformAction();
	}

	public class Service : IService
	{
		public void PerformAction()
		{
			Console.WriteLine("Performing the actual action.");
		}
	}

	public class LoggingInterceptor : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			Console.WriteLine($"Before invoking method: {invocation.Method.Name}");

			// Proceed with the original method invocation
			invocation.Proceed();

			Console.WriteLine($"After invoking method: {invocation.Method.Name}");
		}
	}

	public class Example
	{
		public static void Main()
		{
			// Create a proxy generator
			var proxyGenerator = new ProxyGenerator();

			// Create an instance of the original service
			var service = new Service();

			// Create a proxy by intercepting the original service
			var proxy = proxyGenerator.CreateInterfaceProxyWithTarget<IService>(service, new LoggingInterceptor());

			// Call the method on the proxy
			proxy.PerformAction();
		}
	}

}
