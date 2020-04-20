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

namespace CodeSnippet.ConsoleApp
{
    public sealed class Program
    {
        public static async Task Main()
        {
            
            //await? 
            //int? df ??= 3;
            //var sd = ["name":2];
            //using string xx = null!;
            //Span<int> data = new int[] {0,1,2,3,4,5,6,7,8,9,10 };
            //foreach(var n in data[^6..])
            //{
            //    Console.WriteLine(n);
            //}
            //var slice = data.Slice(5..^1);
            await foreach(var n in GetAsync())
            {

            }
        }
        public static async IAsyncEnumerable<int> GetAsync()
        {
            
            string ss = "fish";
            ss ??= "hmm...";
            //if!(true){ }
            //if(int is not int){ }
            //unless(true){ }
            //bool exist = false;

            //exist &&= true;
            //exist ||= true;

            //var sd = ["name":2];
            using (var st = new SwitchTest()) ;
            for(var i = 0; i < 10; i++)
            {
                yield return await Task.FromResult(i); 
            }
        }
    }

    public class TupleTest
    {
        public TupleTest()
        {
            (int x, int y) = (10, 20);
            (int x, int y) p = (10, 20);
            var p2 = (10, 20);
            _ = (10, 20);
        }
    }
    public class SwitchTest : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void SwitchTestMethod()
        {
            Dummy dummy = new Dummy { Id = 1, BarCode = "12345", DateCreated = DateTime.Now.AddDays(-50), Name = "Bon-Boy" };
            string result = dummy switch
            {
                //Dummy { Id: 1 } d => "fine"
                Dummy (string Id) d => "fine"
                //Dummy { Id: 1, BarCode : "12345"} d => "fine"
            };
        }
        public class Dummy
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string BarCode { get; set; }
            public DateTime DateCreated { get; set; }

            public void Deconstruct(out string MyP)
            {
                MyP = "12";
            }
        }
    }
}
