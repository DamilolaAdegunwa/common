using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Diagnostics;

namespace CodeSnippet.ConsoleApp
{
    public class DFB
    {
        public DFB()
        {
            //NewMethod();
        }

        public static void NewMethod()
        {
            var result = 0;
            BroadcastBlock<int> broadcaster = new BroadcastBlock<int>(null);
            //
            var toggleCheckBox = new ActionBlock<int>(number =>
            {
                number += 10;
            }
            //,
            //new ExecutionDataflowBlockOptions
            //{
            //    TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()
            //}
            );
            //
            var taskSchedulerPair = new ConcurrentExclusiveSchedulerPair();
            //
            var readerActions =
            from checkBox in new int[] { 1, 2, 3 }
            select new ActionBlock<int>(number =>
            {
                result += 1;//number;
                Thread.Sleep(2500);
                result += 1;//number;
                Console.WriteLine(result);
            },
            new ExecutionDataflowBlockOptions
            {
                TaskScheduler = taskSchedulerPair.ConcurrentScheduler
            });//12
            //
            var writerAction = new ActionBlock<int>(number =>
            {
                result += 1;// number;
                Thread.Sleep(2500);
                result += 1;// number;
                Console.WriteLine(result);
            },
            new ExecutionDataflowBlockOptions
            {
                TaskScheduler = taskSchedulerPair.ExclusiveScheduler
            });

            foreach (var readerAction in readerActions)
            {
                broadcaster.LinkTo(readerAction);
            }
            broadcaster.LinkTo(writerAction);

            broadcaster.Post<int>(1);

            broadcaster.Complete();

            broadcaster.Completion.Wait();
            Console.WriteLine(result);
        }


        /// <summary>
        /// I can use like a parallel for(each)
        /// </summary>
        /// <param name="maxDegreeOfParallelism"></param>
        /// <param name="messageCount"></param>
        /// <returns></returns>
        public static TimeSpan TimeDataflowComputations(int maxDegreeOfParallelism, int messageCount)
        {
            var workerBlock = new ActionBlock<int>(
               millisecondsTimeout => { 
                   Thread.Sleep(millisecondsTimeout);
                   Console.WriteLine("was here");
               },
               // Specify a maximum degree of parallelism.
               new ExecutionDataflowBlockOptions
               {
                   MaxDegreeOfParallelism = maxDegreeOfParallelism
               });

            // Compute the time that it takes for several messages to
            // flow through the dataflow block.

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < messageCount; i++)
            {
                workerBlock.Post(2000);
            }
            workerBlock.Complete();
            workerBlock.Completion.Wait();
            // Stop the timer and return the elapsed number of milliseconds. (took the time equivalent of just 1 irrespective of the one of loop)
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public void NewMethod2()
        {
            BroadcastBlock<int> broadcaster = new BroadcastBlock<int>(null);
            var toggleCheckBox = new ActionBlock<int>(number =>
            {
                Console.WriteLine(number);
            }
            //,
            //new ExecutionDataflowBlockOptions
            //{
            //    TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()
            //}
            );
            var taskSchedulerPair = new ConcurrentExclusiveSchedulerPair();
            var readerActions =
               from checkBox in new int[] { 1, 2, 3 }
               select new ActionBlock<int>(milliseconds =>
               {
                toggleCheckBox.Post(checkBox);
                Thread.Sleep(milliseconds);
                toggleCheckBox.Post(checkBox);
                   Console.WriteLine(checkBox);
               },
               new ExecutionDataflowBlockOptions
               {
                   TaskScheduler = taskSchedulerPair.ConcurrentScheduler
               });
            var writerAction = new ActionBlock<int>(milliseconds =>
            {
                toggleCheckBox.Post(4);
                Thread.Sleep(milliseconds);
                toggleCheckBox.Post(4);
                Console.WriteLine(4);
            },
            new ExecutionDataflowBlockOptions
            {
                TaskScheduler = taskSchedulerPair.ExclusiveScheduler
            });
            foreach (var readerAction in readerActions)
            {
                broadcaster.LinkTo(readerAction);
            }
            broadcaster.LinkTo(writerAction);

            broadcaster.Post(1000);

            broadcaster.Complete();
            broadcaster.Completion.Wait();
            
            //timer1.Start();
        }
    }
    public class Test
    {
        static int N = 1000;

        static void TestMethod()
        {
            // Using a named method.
            Parallel.For(0, N, Method2);

            // Using an anonymous method.
            Parallel.For(0, N, delegate (int i)
            {
                // Do Work.
            });

            // Using a lambda expression.
            Parallel.For(0, N, i =>
            {
                // Do Work.
            });
        }

        static void Method2(int i)
        {
            // Do work.
        }
    }
}  