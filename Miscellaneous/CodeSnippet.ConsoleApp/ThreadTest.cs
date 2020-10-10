using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodeSnippet.ConsoleApp
{
    public class ThreadTest1
    {
        static void MainThreadTest1()
        {
            Thread t = new Thread(WriteY); // Kick off a new thread
            t.Start(); // running WriteY()
                       // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++) Console.Write("x");
        }
        static void WriteY()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }
    }
    public struct ThreadVariables
    {
        bool CheckIfDoneBoolField;
        string CheckIfDoneStringField;
        bool CheckIfDoneBoolProperty { get; set; }
        string CheckIfDoneStringProperty { get; set; }
    }
    public struct ThreadTest2
    {
        //public bool done { get; set; }//you get "Done" twice (stack)
        //public bool done;//you get "Done" once (heap)

        bool CheckIfDoneBoolField;
        string CheckIfDoneStringField;
        bool CheckIfDoneBoolProperty { get; set; }
        string CheckIfDoneStringProperty { get; set; }
        ThreadTest1 threadTest1;
        static void MainThreadTest2()
        {
            ThreadTest2 tt = new ThreadTest2(); // Create a common instance
            new Thread(tt.Go).Start();
            tt.Go();
        }
        // Note that Go is now an instance method
        void Go()
        {
            if (threadTest1 == null) { threadTest1 = new ThreadTest1(); Console.WriteLine("Done"); }
        }
    }
    class ThreadTest3
    {
        static bool done; // Static fields are shared between all threads
        static void MainThreadTest3()
        {
            new Thread(Go).Start();
            Go();
        }
        static void Go()
        {
            if (!done) { done = true; Console.WriteLine("Done"); }
        }
    }
    class ThreadSafe
    {
        static bool done;
        static readonly object locker = new object();
        static void MainThreadSafe()
        {
            new Thread(Go).Start();
            Go();
        }
        static void Go()
        {
            lock (locker)
            {
                if (!done) { Console.WriteLine("Done"); done = true; }
            }
        }
    }
    public class JoinandSleep
    {
        static void Main()
        {
            Thread t = new Thread(While);
            t.Start();
            //t.Join(); if you uncomment this line the code will not move past this line cos of the infinite while loop
            Thread t2 = new Thread(Go);
            t2.Start();
            t2.Join();
            Console.WriteLine("Thread t has ended!");

            Thread.Sleep(TimeSpan.FromHours(1)); // sleep for 1 hour
            Thread.Sleep(500); // sleep for 500 milliseconds
            Thread.Yield();
        }
        public static void While()
        {
            while(true)
            { }
        }
        static void Go()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }
    }
    class ThreadNaming
    {
        static void Main()
        {
            Thread.CurrentThread.Name = "main";
            Thread worker = new Thread(Go);
            worker.Name = "worker";
            worker.Start();
            Go();
        }
        static void Go()
        {
            Console.WriteLine("Hello from " + Thread.CurrentThread.Name);
        }
    }
}