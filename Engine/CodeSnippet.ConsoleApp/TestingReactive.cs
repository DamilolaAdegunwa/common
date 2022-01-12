using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Reactive;
using System.Reactive.Linq;
namespace CodeSnippet.ConsoleApp
{
    public class TestingReactive
    {
        public static void MainTestingReactive()
        {
            IObservable<int> observableInt = Observable.Range(1, 10);
            observableInt.Subscribe<int>(a => Console.WriteLine(a));
            Console.ReadKey();
        }
    }
}