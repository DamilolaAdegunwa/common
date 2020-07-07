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
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.Http;
using System.Collections.Specialized;
using static System.Text.StringBuilder;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Collections.Concurrent;
using System.Threading;
using System.ComponentModel;
using Nito.AsyncEx;
//using Microsoft.Tpl.Dataflow;
using System.Reactive;
//using System.Reactive.Core;
//using System.Reactive.Interfaces;
using System.Reactive.Linq;
using System.Reactive.PlatformServices;
using Microsoft.Reactive.Testing;
using EO.Base.UI;
using System.Fabric.Description;

namespace CodeSnippet.ConsoleApp
{
    public sealed class Program
    {
        #region parallel programming (to be cont'd)
        //public static async Task Main()
        //{
        //    Action action = () => { Console.WriteLine("Done!!"); };
        //    IObservable<string> observable = Observable.Return<string>("Damilola");
        //    //Observable.Return("stub").Delay(Delay, Scheduler);
        //    var t = new TaskCompletionSource<string>();
        //    t.TrySetResult("doom!");
        //    var tt = await t.Task;
        //    StatefulServiceDescription d = Activator.CreateInstance<StatefulServiceDescription>();
        //    var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
        //    var subtractBlock = new TransformBlock<int, int>(item => item - 2);
        //    // After linking, values that exit multiplyBlock will enter subtractBlock.
        //    multiplyBlock.LinkTo(subtractBlock);
        //}
        //IEnumerable<bool> PrimalityTest(IEnumerable<int> values)
        //{
        //    return values.AsParallel().Select(val => {
        //        var x = 1;
        //        var y = 2;
        //        var z = 3;

        //        var a = 4;
        //        var b = 5;
        //        var c = 6;
        //        return a == b;
        //    }/*IsPrime(val)*/);
        //}
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
        //    handler => (s, a) => handler(s, a),
        //    handler => MouseMove += handler,
        //    handler => MouseMove -= handler)
        //    .Select(x => x.EventArgs.GetPosition(this))
        //    .Sample(TimeSpan.FromSeconds(1))
        //    .Subscribe(x => Trace.WriteLine(
        //    DateTime.Now.Second + ": Saw " + (x.X + x.Y)));
        //}
        #endregion

        #region simple parallel programming 2
        //static List<int> vsint = new int[] { 1, 2, 3, 4, 5, 6 }.ToList();//new List<int>();
        //public static async Task Main()
        //{
        //    List<int> vsint = new List<int>();
        //    Task.Run(() => { vsint = new int[] { 1, 2, 3, 4, 5, 6 }.ToList(); return "love!"; }).ContinueWith( tk => {
        //        foreach (var j in vsint)
        //        {
        //            Console.WriteLine(j);
        //        }
        //    });
        //    Console.WriteLine("done!");
        //}
        #endregion

        #region simple parallel programming 1
        //public static async Task Main()
        //{
        //    var e = Enumerable.Range(1, 100000);
        //    //var d = Channel.CreateUnbounded<int>();
        //    List<int> vs = new List<int>();
        //    Task.Run(async () =>
        //    {
        //        Parallel.ForEach(e, i =>
        //        {
        //            Task.Run(async () =>
        //            {
        //                //d.Writer.TryWrite(i);
        //                vs.Add(i);
        //            });

        //        });
        //    });
        //    while (true)
        //    {

        //        Task.Run(async () =>
        //        {
        //            //Console.WriteLine(_ = (await d.Reader.ReadAsync()));
        //            Console.WriteLine(vs.FirstOrDefault());
        //        });
        //        //break;
        //    }
        //}
        #endregion

        #region Channel
        //public static async Task Main()
        //{
        //    //BackgroundWorker backgroundWorker = new BackgroundWorker();

        //    //var c = new MyQueue<int>();
        //    var d = Channel.CreateUnbounded<int>();
        //    _ = Task.Run(async delegate
        //    {
        //        for (var i = 0; true; i++)
        //        {
        //            await Task.Delay(100);
        //            //c.Write(i);
        //            d.Writer.TryWrite(i);
        //        }
        //    });
        //    //var z = await d.Reader.ReadAllAsync().ToListAsync();// if your your aim is to get it all as a list
        //    while (true)
        //    {
        //        //Console.WriteLine((_ = await c.ReadAsync()));
        //        Console.WriteLine(_ = await d.Reader.ReadAsync());
        //    }
        //}

        #endregion

        #region Unsafe and Trials!
        //public static void Main()
        //{
        //    
        //    //public enum AccountType
        //    //{
        //    //    Android = 0, IOS = 1, Web = 2, Mobile = Android | IOS
        //    //}
        //    //string x = Activator.CreateInstance<string>();  
        //    ////void x = ;
        //    //AccountType accountType1 = AccountType.Android;
        //    //AccountType accountType2 = AccountType.IOS;

        //    //if(accountType1 == AccountType.Mobile && accountType2 == AccountType.Mobile)
        //    //{
        //    //    Console.WriteLine("both accounts are mobile!!");
        //    //}else
        //    //{
        //    //    Console.WriteLine("they are not!!");
        //    //}
        //    //unsafe
        //    //{
        //    //    int a = 10;
        //    //    int b = 20;
        //    //    int c = 30;

        //    //    int* ptra = &a;
        //    //    int* ptrb = &b;
        //    //    int* ptrc = &c;


        //    //    Console.WriteLine((int)ptra);
        //    //    Console.WriteLine(*ptra);


        //    //}

        //    ////string ptr = Convert.ToInt32(&x);
        //    //byte[] byt = new byte[] { };
        //    //BitConverter.ToInt32(byt);
        //    //BinaryReader binaryReader = default;
        //    

        //    Console.WriteLine("done!");
        //    Console.ReadLine();
        //}
        #endregion
    }
}