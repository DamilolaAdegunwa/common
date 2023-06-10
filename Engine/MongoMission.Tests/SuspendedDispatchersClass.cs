//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System;
//using System.Threading;
//using System.Windows;
////using System.Windows.Threading;
//using static System.Net.Mime.MediaTypeNames;
//using Microsoft.AspNetCore.Components;

//namespace MongoMission.Tests
//{


//    public class Program
//    {
//        private static Dispatcher _dispatcher;

//        [STAThread]
//        public static void Main()
//        {
//            _dispatcher = default;//new Dispatcher();//Application.Current.Dispatcher;

//            Thread workerThread = new Thread(DoWork);
//            workerThread.Start();

//            // Simulate some UI interaction
//            Console.WriteLine("UI interaction...");

//            // Pause the dispatcher
//            SuspendDispatcher();

//            Console.WriteLine("Dispatcher suspended.");

//            // Perform some lengthy operation without UI interruption
//            Console.WriteLine("Performing lengthy operation...");
//            Thread.Sleep(5000);

//            // Resume the dispatcher
//            ResumeDispatcher();

//            Console.WriteLine("Dispatcher resumed.");
//        }

//        private static void DoWork()
//        {
//            // Simulate work on a background thread
//            Console.WriteLine("Background thread started.");

//            // Perform some work on the background thread
//            for (int i = 1; i <= 5; i++)
//            {
//                Console.WriteLine($"Background thread: {i}");
//                Thread.Sleep(1000);
//            }

//            Console.WriteLine("Background thread finished.");
//        }

//        private static void SuspendDispatcher()
//        {
//            //_dispatcher.Invoke(() =>
//            //{
//            //    _dispatcher.Pause();
//            //});
//        }

//        private static void ResumeDispatcher()
//        {
//            //_dispatcher.InvokeAsync(() =>
//            //{
//            //    _dispatcher.Resume();
//            //});
//        }
//    }

//    internal class SuspendedDispatchersClass
//    {
//    }
//}
