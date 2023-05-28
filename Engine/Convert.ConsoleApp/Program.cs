using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using ConvertApp.ConsoleApp.Services.Junk;
using ConvertApp.ConsoleApp.Services.Others;
using ConvertApp.ConsoleApp.Services.SystemSpan;

namespace ConvertApp.ConsoleApp
{
	public class Program
	{
        //test 1
        //public static void Main() 
        //{
        //	//Dummy dummy = stackalloc object[];
        //	ReadOnlySpanTest<int> i = new ReadOnlySpanTest<int>();// default(ReadOnlySpanTest<int>);
        //	Console.WriteLine($"{i.Age}");
        //	Console.WriteLine($"{i.YearsOfExperience}");
        //	Console.WriteLine($"{i.Strings.ToArray()}");
        //}

        //test 2
        //public static void Main() { Console.WriteLine("working"); }

        //test 3
        public static void Main_()
        {
            VarianceCode.Main_VarianceCode();
        }
    }
}
