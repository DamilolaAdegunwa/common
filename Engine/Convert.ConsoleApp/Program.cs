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
			ReadOnlySpanTest<int> i = new ReadOnlySpanTest<int>();// default(ReadOnlySpanTest<int>);
			Console.WriteLine($"{i.Age}");
			Console.WriteLine($"{i.YearsOfExperience}");
			Console.WriteLine($"{i.Strings.ToArray()}");
		}
	}
}
