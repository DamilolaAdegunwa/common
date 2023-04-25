using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertApp.ConsoleApp.Services.SystemSpan
{
	[MemoryDiagnoser]
	public class SimpleSpanTest
	{
		private static readonly string _dateAsText = "08 07 2023";
		private static readonly ReadOnlySpan<string> strings;
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

	public readonly ref struct ReadOnlySpanTest<T>
	{

	}
}
