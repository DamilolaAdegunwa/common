using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using ConvertApp.ConsoleApp.Services.SystemSpan;

namespace ConvertApp.ConsoleApp
{
	public class Program
	{
		public static void Main() 
		{
			BenchmarkRunner.Run<SimpleSpanTest>();
			Console.WriteLine("program file up and running!");
		}
	}
}
