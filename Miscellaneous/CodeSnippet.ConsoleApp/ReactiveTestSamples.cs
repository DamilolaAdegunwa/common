using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using System.Linq;
using System.Threading;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
//using System.Concurrency;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xamarin.Forms;

namespace CodeSnippet.ConsoleApp
{

    public class ReactiveTestSamples
    {
        public delegate int PerformCalculation(int x, int y);
        public static void Sample1()
        {
            var query = from number in Enumerable.Range(1, 5) select number;
            foreach(var number in query)
            {
                Console.WriteLine(number);
            }
            ImDone();
            //var observableQuery = query.ToObservable();
            //var or = Observable.Range(1, 5);
            //var or2 = Observable.Timer(TimeSpan.FromSeconds(30));
            
        }
        public static void ImDone()
        {
            Console.WriteLine("I'm done!");
        }
    }
}
