using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using System.Linq;
using System.Threading;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
namespace CodeSnippet.ConsoleApp
{
    public class ReactiveTestSamples
    {
        public static void Sample1()
        {
            var query = from number in Enumerable.Range(1, 5) select number;
            foreach(var number in query)
            {
                Console.WriteLine(number);
            }
            ImDone();
            var observableQuery = query.ToObservable();
        }
        public static void ImDone()
        {
            Console.WriteLine("I'm done!");
        }
    }
}
