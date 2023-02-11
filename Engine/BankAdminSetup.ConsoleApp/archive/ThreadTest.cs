using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using ThreadState = System.Diagnostics.ThreadState;

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
        static void MainJoinandSleep()
        {
            Thread t = new Thread(While);
            t.Start();
            //t.Join(); if you uncomment this line the code will not move past this line cos of the infinite while loop
            Thread t2 = new Thread(Go);
            t2.Start();
            t2.Join();
            bool blocked = ((int)t2.ThreadState & (int)ThreadState.Wait) != 0;
            SpinLock spinLock;
            SpinWait spinWait;
            Console.WriteLine("Thread t has ended!");

            Thread.Sleep(TimeSpan.FromHours(1)); // sleep for 1 hour
            Thread.Sleep(500); // sleep for 500 milliseconds
            Thread.Yield();
        }
        public static void While()
        {
            while (true)
            { }
        }
        static void Go()
        {
            for (int i = 0; i < 1000; i++) Console.Write("y");
        }
    }
    class ThreadNaming
    {
        static void MainThreadNaming()
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
    class threadingTest
    {
        public static void MainthreadingTest()
        {
            test2();
            Console.WriteLine("4th");
            using (Process p = Process.GetCurrentProcess())
            { p.PriorityClass = ProcessPriorityClass.High; }
            Console.ReadLine();
        }
        public static void test2()
        {
            test();
            Console.WriteLine("3rd");
        }
        public static int test()
        {//we see from here that a thread keeps working even after the 
            //method that calls the thread has returned
            new Thread(() =>
            {
                var i = 1;
                while (true)
                {
                    //Thread.Sleep(500);
                    Console.WriteLine(i++);
                }
            }).Start();
            new Thread(() =>
            {
                while (true)
                {
                    //Thread.Sleep(500);
                    Console.WriteLine(DateTime.Now);
                }
            }).Start();
            return 1;
        }

    }
    #region better way to handle ex
    /*
     public static void MainthreadingTest()
    {
        new Thread (Go).Start();
    }
    static void Go()
    {
        try
        {
            ...
            throw null; // The NullReferenceException will get caught below
            ...
        }
        catch (Exception ex)
        {
            Typically log the exception, and/or signal another thread
            that we've come unstuck
            ...
        }
    }
    */
    #endregion

    //Application.DispatcherUnhandledException and Application.ThreadException) and AppDomain.CurrentDomain.UnhandledException  
    //Thread.CurrentThread.IsThreadPoolThread.
    class TaskThread
    {
        static void MainTaskThread()
        {
            // Start the task executing:
            Task<string> task = Task.Factory.StartNew<string>
            (() => DownloadString("http://www.linqpad.net"));
            task.Wait();
            //task.
            // We can do other work here and it will execute in parallel:
            RunSomeOtherMethod();
            // When we need the task's return value, we query its Result property:
            // If it's still executing, the current thread will now block (wait)
            // until the task finishes:
            string result = task.Result;
        }

        private static void RunSomeOtherMethod()
        {
            throw new NotImplementedException();
        }

        static string DownloadString(string uri)
        {
            using (var wc = new System.Net.WebClient())
                return wc.DownloadString(uri);
        }
        /*

         static void MainTaskThread()
        {
        ThreadPool.QueueUserWorkItem (Go);
        ThreadPool.QueueUserWorkItem (Go, 123);
        Console.ReadLine();
        }
        static void Go (object data) // data will be null with the first call.
        {
        Console.WriteLine ("Hello from the thread pool! " + data);
        }
        // Output:
        Hello from the thread pool!
        Hello from the thread pool! 123
        */
    }
    class AsynchronousDelegates
    {
        static void MainAsynchronousDelegates()
        {
            Func<string, int> method = Work;
            IAsyncResult cookie = method.BeginInvoke("test", null, null);
            //
            // ... here's where we can do other work in parallel...
            //
            int result = method.EndInvoke(cookie);
            Console.WriteLine("String length is: " + result);
        }
        static int Work(string s) { return s.Length; }
    }
    public class AsynchronousDelegatesWithAsyncCallback
    {
        public static void MainAsynchronousDelegatesWithAsyncCallback()
        {
            Func<string, int> method = Work;
            method.BeginInvoke("test", Done, method);
            // ...
            //
        }
        static int Work(string s) { return s.Length; }
        static void Done(IAsyncResult cookie)
        {
            var target = (Func<string, int>)cookie.AsyncState;
            int result = target.EndInvoke(cookie);
            Console.WriteLine("String length is: " + result);
        }
        public static ThreadState SimpleThreadState(ThreadState ts)
        {
            //return ts & (ThreadState.Unstarted |
            //ThreadState..WaitSleepJoin |
            //ThreadState.Stopped);
            return default;
        }
    }
    class ThreadSafeTest
    {
        static readonly object _locker = new object();
        static int _val1, _val2;
        static void Go()
        {
            lock (_locker)
            {
                if (_val2 != 0) Console.WriteLine(_val1 / _val2);
                _val2 = 0;
            }
            //or
            Monitor.Enter(_locker);
            try
            {
                if (_val2 != 0) Console.WriteLine(_val1 / _val2);
                _val2 = 0;
            }
            finally { Monitor.Exit(_locker); }
        }
    }
    public class TheClub // No door lists!
    {
        static SemaphoreSlim _sem = new SemaphoreSlim(3); // Capacity of 3
        static void MainTheClub()
        {
            for (int i = 1; i <= 5; i++) new Thread(Enter).Start(i);
        }
        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            _sem.Wait();
            Console.WriteLine(id + " is in!"); // Only three threads
            Thread.Sleep(1000 * (int)id); // can be here at
            Console.WriteLine(id + " is leaving"); // a time.
            _sem.Release();
        }
        /*
         1 wants to enter
        1 is in!
        2 wants to enter
        2 is in!
        3 wants to enter
        3 is in!
        4 wants to enter
        5 wants to enter
        1 is leaving
        4 is in!
        2 is leaving
        5 is in!
         */
    }
    class TwoWaySignaling
    {
        static EventWaitHandle _ready = new AutoResetEvent(false);
        static EventWaitHandle _go = new AutoResetEvent(false);
        static readonly object _locker = new object();
        static string _message;
        static void MainTwoWaySignaling()
        {
            new Thread(Work).Start();
            _ready.WaitOne(); // First wait until worker is ready
            lock (_locker) _message = "ooo";
            _go.Set(); // Tell worker to go
            _ready.WaitOne();
            lock (_locker) _message = "ahhh"; // Give the worker another message
            _go.Set();
            _ready.WaitOne();
            lock (_locker) _message = null; // Signal the worker to exit
            _go.Set();
        }
        static void Work()
        {
            while (true)
            {
                _ready.Set(); // Indicate that we're ready
                _go.WaitOne(); // Wait to be kicked off...
                lock (_locker)
                {
                    if (_message == null) return; // Gracefully exit
                    Console.WriteLine(_message);
                }
            }
        }
    }
    class ProducerConsumerQueue : IDisposable
    {
        EventWaitHandle _wh = new AutoResetEvent(false);
        Thread _worker;
        readonly object _locker = new object();
        Queue<string> _tasks = new Queue<string>();
        public ProducerConsumerQueue()
        {
            _worker = new Thread(Work);
            _worker.Start();
        }
        public void EnqueueTask(string task)
        {
            lock (_locker) _tasks.Enqueue(task);
            _wh.Set();
        }
        public void Dispose()
        {
            EnqueueTask(null); // Signal the consumer to exit.
            _worker.Join(); // Wait for the consumer's thread to finish.
            _wh.Close(); // Release any OS resources.
        }
        void Work()
        {
            while (true)
            {
                string task = null;
                lock (_locker)
                    if (_tasks.Count > 0)
                    {
                        task = _tasks.Dequeue();
                        if (task == null) return;
                    }
                if (task != null)
                {
                    Console.WriteLine("Performing task: " + task);
                    Thread.Sleep(1000); // simulate work...
                }
                else
                    _wh.WaitOne(); // No more tasks - wait for a signal
            }
        }
        static void MainProducerConsumerQueue()
        {
            using (ProducerConsumerQueue q = new ProducerConsumerQueue())
            {
                q.EnqueueTask("Hello");
                for (int i = 0; i < 10; i++) q.EnqueueTask("Say " + i);
                q.EnqueueTask("Goodbye!");
            }
            // Exiting the using statement calls q's Dispose method, which
            // enqueues a null task and waits until the consumer finishes.
        }
    }
}