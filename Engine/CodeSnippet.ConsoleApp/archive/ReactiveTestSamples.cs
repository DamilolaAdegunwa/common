using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using System.Linq;
using System.Threading;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Web.UI;
//using System.Web.UI.WebControls;
using Xamarin.Forms;
using FireBase.Notification;
using System.IO;
using LINQPad;
using System.Windows.Input;
//using System.Windows.Controls;
//using Microsoft.Phone.Controls;
//using Microsoft.Phone.Reactive;
//using Microsoft.Phone.Reactive;
using LINQPad.Controls;

namespace CodeSnippet.ConsoleApp
{
    //public interface IObservable<out T>
    //{
    //    IDisposable Subscribe(IObserver<T> observer);
    //}
    //public interface IObserver<in T>
    //{
    //    void OnCompleted();
    //    void OnError(Exception error);
    //    void OnNext(T value);
    //}
    public class TestObserver : IObserver<string>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Completed!!");
            //throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Error!! {error}");
            //throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            Console.WriteLine($"Next!! {value}");
            //throw new NotImplementedException();
        }
    }
    public class ReactiveTestSamples
    {
        public static void MainReactiveTestSamples()
        {
            var input3 = Observable.Return(24).Materialize();
            input3.Dump();
            var input2 = new[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 }.ToObservable();
            var output2 = input2.Take(5).Select(x => x * 10);
            var input = new[] { 1, 2, 3, 4, 5, 4, 3, 2, 1 }.ToObservable();
            var output = input.Distinct().Select(x => x * 10);
            output.Dump();
            var ObservableStrings = Observable.Using<char, StreamReader>(
                () => new StreamReader(new FileStream("randomstrings.txt",
                FileMode.Open)),
                                streamReader =>
                (
                from str in streamReader.ReadToEnd()
                select str
                )
                .ToObservable()
                );
            var ObservableStrings2 = Observable.Using<char, StreamReader>
            (
            () => new StreamReader(new FileStream("randomstrings.txt",
            FileMode.Open)),
            streamReader =>
            (
            from str in streamReader.ReadToEnd()
            select str
            )
            .ToObservable()
            );
            ObservableStrings2.Subscribe(Console.Write);
            var keys = Observable.FromEvent<KeyEventArgs>(Search, KeyUp).Throttle(TimeSpan.FromSeconds(.5)); ;
            keys.ObserveOn(Scheduler.CurrentThread).Subscribe(evt =>
            {
                //var lblSearchText = "Searching for ..." + Search.Text;
                //lblProgress.Visibility = System.Windows.Visibility.Visible;
                //webBrowser1.Navigate(new Uri("http://en.wikipedia.org/wiki/"
                //+ Search.Text));
            });
            new ReactiveTestSamples().Observe();
            var listOne = Observable.Range(1, 100);
            string[] states = {"Alabama", "Alaska", "Arizona", "Arkansas","California" };
            var listTwo = states.ToObservable();
            var numberedStates = listOne.Zip(listTwo,
            (num, state) => num + ": " + state);
            numberedStates.Dump();
            Console.WriteLine(numberedStates);
            //var mousedown = from evt in Observable.FromEvent<ConsoleCancelEventArgs>(image, "MouseLeftButtonDown")
            //select evt.EventArgs.GetPosition(image);
            //var mouseup = Observable.FromEvent<MouseButtonEventArgs>(this, "MouseLeftButtonUp");
            //var mousemove = from evt in Observable.FromEvent<MouseEventArgs>(this, "MouseMove")
            //select evt.EventArgs.GetPosition(this);
            
            Console.ReadLine();
        }

        private static void KeyUp(Action<KeyEventArgs> obj)
        {
            throw new NotImplementedException();
        }

        private static void Search(Action<KeyEventArgs> obj)
        {
            throw new NotImplementedException();
        }

        private void Observe()
        {
            int c = 0;
            var source = Observable.While(()=>{return c++ < 5;}, Observable.Return(42));
            //IObservable<int> source = Observable.Range(42, 4);//Observable.Return(42);
            //input.Sum().Subscribe(x => Console.WriteLine("The Sum is {0}", x));
            IDisposable subscription = source.Subscribe(
                x => new TestObserver().OnNext($"message to indicate a next {x}"),
                ex => new TestObserver().OnError(ex) ,
                () => new TestObserver().OnCompleted()
            );
        }
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

//namespace MouseTrapDragAndDrop
//{
//    public class MainPage : PhoneApplicationPage
//    {
//        public MainPage()
//        {
//            InitializeComponent();
//            var mousedown = from evt in Observable.FromEvent
//            <MouseButtonEventArgs>(
//            image, "MouseLeftButtonDown")
//                            select evt.EventArgs.GetPosition(image);
//            var mouseup = Observable.FromEvent
//            <MouseButtonEventArgs>(
//            this, "MouseLeftButtonUp");
//            var mousemove = from evt in Observable.FromEvent
//            <MouseEventArgs>(
//            this, "MouseMove")
//                            select evt.EventArgs.GetPosition(
//                            this);
//            var q = from start in mousedown
//                    from end in mousemove.TakeUntil(mouseup)
//                    select new
//                    {
//                        X = end.X - start.X,
//                        Y = end.Y - start.Y
//                    };
//            q.Subscribe(value =>
//            {
//                Canvas.SetLeft(image, value.X);
//                Canvas.SetTop(image, value.Y);
//            });
//        }
//    }
//}
