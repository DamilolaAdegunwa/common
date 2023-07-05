using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.SystemSpan
{
	#region run in main program 1

	#endregion
	[MemoryDiagnoser]
	public class SimpleSpanTest
	{
		//public List<ReadOnlySpanTest> readOnlySp { get; set; }
		private static readonly string _dateAsText = "08 07 2023";
		//private readonly ReadOnlySpan<string> strings;
		public SimpleSpanTest() { }

		[Benchmark]
		public (int day, int month, int year) DateUsingSubstring()
		{
			var day = int.Parse(_dateAsText.Substring(0,2));
			var month = int.Parse(_dateAsText.Substring(3,2));
			var year = int.Parse(_dateAsText.Substring(6));
			return (day, month, year);
		}

		[Benchmark]
		public (int day, int month, int year) DateUsingSpan()
		{
			ReadOnlySpan<char> chars = _dateAsText;
			var day = int.Parse(chars.Slice(0, 2));
			var month = int.Parse(chars.Slice(3, 2));
			var year = int.Parse(chars.Slice(6));
			return (day, month, year);
		}
		public void SimpleSpanMethod()
		{
			try
			{
				checked
				{

				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}

	public interface INothing
	{

	}
	public unsafe readonly ref partial struct ReadOnlySpanTest<T> //: INothing //cannot impl interface
	{
		public readonly int Age { get; }
		public readonly int YearsOfExperience { get; }

		public readonly ReadOnlySpan<string> Strings = new string[] { };
		//public ReadOnlySpanTest(int age, int yoe, string[] s) => (Age, YearsOfExperience, Strings) = (age, yoe, s);
		public ReadOnlySpanTest(int age, int yoe, ReadOnlySpan<string> s)
		{
			Age = age;
			YearsOfExperience = yoe;
			Strings = s;
		}

		public ReadOnlySpanTest<T> Test()
		{
			return default(ReadOnlySpanTest<T>);
		}

		public static ReadOnlySpanTest<T> Test2()
		{
			return default(ReadOnlySpanTest<T>);
		}

		public ReadOnlySpanTest()
		{
			Age = 35;
			YearsOfExperience = 10;
			Strings = new string[] { "One", "Two", "Three", "Four", "Five", "Six" };
		}
	}
}