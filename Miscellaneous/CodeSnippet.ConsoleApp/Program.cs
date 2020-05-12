using CodeSnippet.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.IO;
using System.Web;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Timers;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.FileProviders;
//using Microsoft.Extensions.Http.Polly;
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.Http;
namespace CodeSnippet.ConsoleApp
{
    public sealed class Program
    {
        public static  void/*async Task*/ Main()
        {
            new Partitioning().ForEachPartition();

            //var a = Enumerable.Range(1, 300);
            //var b = Enumerable.Repeat("Win", 10);
            //var c = Enumerable.Cast<string>(new int[] { 1, 2, 3 }).ToList();
            //var fileInfo = new FileInfo(Path.Combine(""));
            
            Console.ReadLine();
        }
       
    }

}