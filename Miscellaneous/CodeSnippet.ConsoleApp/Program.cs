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
namespace CodeSnippet.ConsoleApp
{
    public sealed class Program
    {
        public enum Boys { kolade, mayowa, adefarati}
        public static async Task Main()
        {
            Activator.CreateInstance<string>();
            Type CardType = typeof(VISA);
            Console.ReadLine();
        }
       
    }
    public class VISA { }
    public class MasterCard { }
    public class LayeredTask
    {
        public static void OuterLayer()
        {
            Console.ReadLine();
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            ////Task.Run(() => {
            //    for (var x = 1; x < 100_000_000; x++){}
            //    SecondLayer();
            ////});
            
            //var elapsedTime = watch.ElapsedMilliseconds;
            ////without task 791ms, 918ms, 870ms, 756ms,807ms
            ////with task 279ms
            ////with nested task 70ms, 63ms, 63ms, 59, 68, 55, 55, 71, 67, 64, 61, 60, 48 (with first async 61, 54, 59, 65, 63 | all async 68, 50, 85, 54, 74, 68, 67 | all await)

            ////conclusions
            ////1) as much as possible, wrap your work in a Task.Run,
            ////2) await affects speed, use wisely!!
            ////3) async on method makes little difference in speed
            //watch.Stop();
        }
        //public static void SecondLayer()
        //{
        //    Task.Run(() => {
        //        for (var x = 1; x < 100_000_000; x++)
        //        {
        //            //Console.WriteLine("");
        //        }
        //        ThirdLayer();
        //    });
            
        //}
        //public static void ThirdLayer()
        //{
        //    Task.Run(() => {
        //        for (var x = 1; x < 100_000_000; x++)
        //        {
        //            //Console.WriteLine("");
        //        }
        //    });
                
        //}
    }
}