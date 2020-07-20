using CodeSnippet.ConsoleApp.Services;
using Nito.AsyncEx;
using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Drawing.Common;
using System.Runtime.Remoting;
using System.Runtime;
using System.Diagnostics;
//using Microsoft.;
using FireBase.Notification;
using FireBase;
namespace CodeSnippet.ConsoleApp
{
    public class Program
    {
        public readonly int x = 4;
        public static void Main()
        {
            
            using (var firebase = new FireBase.Notification.Firebase())
            {
                firebase.ServerKey = "{Your Server Key}";
                var id = "{Your Device Id}";
                firebase.PushNotifyAsync(id, "Hello", "World").Wait();
                Console.ReadLine();
            }
            //autolayout

            //    class
            //sealed
            //AnsiClass
            //BeforeFieldInit
            #region ---
            //ImmutableStack<T> ist = default;
            ////System.Collections.Immutable includes many others!!

            //ConcurrentDictionary<string, int> cdtt = default;
            //BlockingCollection<T> ts = default;
            ////System.Collections.Concurrent ...

            //AsyncProducerConsumerQueue<T> asyncpc = default;
            //AsyncCollection<T> asyncC = default;
            ////Nito.AsyncEx ...

            //BufferBlock<T> bb = default;
            ////System.Threading.Tasks.Dataflow

            someService some = Activator.CreateInstance<someService>();
            some.MyProperty = 125;
            Console.WriteLine(some.MyProperty);
            Console.ReadLine();
            #endregion
        }
        void DoLongOperation()
        {
            var operationId = Guid.NewGuid();
            //CallContext.LogicalSetData("OperationId", operationId);
            DoSomeStepOfOperation();
            //CallContext.FreeNamedDataSlot("OperationId");
        }
        void DoSomeStepOfOperation()
        {
            // Do some logging here.
            //Trace.WriteLine("In operation: " + CallContext.LogicalGetData("OperationId"));
        }
        IEnumerable<int> ParallelMultiplyBy2(IEnumerable<int> values)
        {
            return values.AsParallel()
            .WithDegreeOfParallelism(10)
            .Select(item => item * 2);
        }
        // Using the Parallel class
        void ParallelRotateMatrices(IEnumerable<Matrix> matrices, float degrees)
        {
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 10
            };
            Parallel.ForEach(matrices, options, matrix => matrix.Rotate(degrees));
        }
        public AsyncLazy<int> Data
        {
            get { return _data; }
        }
        public void Fetch(in int x, int y, in string z)
        {
            y = 10 + x;

            //x = 40; //compile time error!
        }

        private readonly AsyncLazy<int> _data =
        new AsyncLazy<int>(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return 13;
        });
        public static class AsyncInitialization
        {
            static Task WhenAllInitializedAsync(params object[] instances)
            {
                 return Task.WhenAll(Task.FromResult(instances.OfType<string>().Select(x => x)));
            }
        }
    }

    public class someService
    {
        public someService()
        {
            Console.WriteLine("the constructor was called!");
        }
        public int MyProperty { get; set; }
    }
}