using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Remoting;
namespace CodeSnippet.ConsoleApp.SystemThreadingTasks
{
    public class Example
    {
        public static void MainThreadExample()
        {
            var rnd = new Random();
            int breakIndex = rnd.Next(1, 11);

            Console.WriteLine($"Will call Break at iteration {breakIndex}\n");
            var result = Parallel.For(1, 101, (i, state) =>
            {
                Console.WriteLine($"Beginning iteration {i}");
                int delay;
                lock (rnd)
                    delay = rnd.Next(1, 1001);
                Thread.Sleep(delay);

                if (state.ShouldExitCurrentIteration)
                {
                    if (state.LowestBreakIteration < i)
                        return;
                }

                if (i == breakIndex)
                {
                    Console.WriteLine($"Break in iteration {i}");
                    state.Break();
                }

                Console.WriteLine($"Completed iteration {i}");
            });

            if (result.LowestBreakIteration.HasValue)
                Console.WriteLine($"\nLowest Break Iteration: {result.LowestBreakIteration}");
            else
                Console.WriteLine($"\nNo lowest break iteration.");
        }
    }
    // The example displays output like the following:
    //       Will call Break at iteration 8
    //
    //       Beginning iteration 1
    //       Beginning iteration 13
    //       Beginning iteration 97
    //       Beginning iteration 25
    //       Beginning iteration 49
    //       Beginning iteration 37
    //       Beginning iteration 85
    //       Beginning iteration 73
    //       Beginning iteration 61
    //       Completed iteration 85
    //       Beginning iteration 86
    //       Completed iteration 61
    //       Beginning iteration 62
    //       Completed iteration 86
    //       Beginning iteration 87
    //       Completed iteration 37
    //       Beginning iteration 38
    //       Completed iteration 38
    //       Beginning iteration 39
    //       Completed iteration 25
    //       Beginning iteration 26
    //       Completed iteration 26
    //       Beginning iteration 27
    //       Completed iteration 73
    //       Beginning iteration 74
    //       Completed iteration 62
    //       Beginning iteration 63
    //       Completed iteration 39
    //       Beginning iteration 40
    //       Completed iteration 40
    //       Beginning iteration 41
    //       Completed iteration 13
    //       Beginning iteration 14
    //       Completed iteration 1
    //       Beginning iteration 2
    //       Completed iteration 97
    //       Beginning iteration 98
    //       Completed iteration 49
    //       Beginning iteration 50
    //       Completed iteration 87
    //       Completed iteration 27
    //       Beginning iteration 28
    //       Completed iteration 50
    //       Beginning iteration 51
    //       Beginning iteration 88
    //       Completed iteration 14
    //       Beginning iteration 15
    //       Completed iteration 15
    //       Completed iteration 2
    //       Beginning iteration 3
    //       Beginning iteration 16
    //       Completed iteration 63
    //       Beginning iteration 64
    //       Completed iteration 74
    //       Beginning iteration 75
    //       Completed iteration 41
    //       Beginning iteration 42
    //       Completed iteration 28
    //       Beginning iteration 29
    //       Completed iteration 29
    //       Beginning iteration 30
    //       Completed iteration 98
    //       Beginning iteration 99
    //       Completed iteration 64
    //       Beginning iteration 65
    //       Completed iteration 42
    //       Beginning iteration 43
    //       Completed iteration 88
    //       Beginning iteration 89
    //       Completed iteration 51
    //       Beginning iteration 52
    //       Completed iteration 16
    //       Beginning iteration 17
    //       Completed iteration 43
    //       Beginning iteration 44
    //       Completed iteration 44
    //       Beginning iteration 45
    //       Completed iteration 99
    //       Beginning iteration 4
    //       Completed iteration 3
    //       Beginning iteration 8
    //       Completed iteration 4
    //       Beginning iteration 5
    //       Completed iteration 52
    //       Beginning iteration 53
    //       Completed iteration 75
    //       Beginning iteration 76
    //       Completed iteration 76
    //       Beginning iteration 77
    //       Completed iteration 65
    //       Beginning iteration 66
    //       Completed iteration 5
    //       Beginning iteration 6
    //       Completed iteration 89
    //       Beginning iteration 90
    //       Completed iteration 30
    //       Beginning iteration 31
    //       Break in iteration 8
    //       Completed iteration 8
    //       Completed iteration 6
    //       Beginning iteration 7
    //       Completed iteration 7
    //
    //       Lowest Break Iteration: 8


    public class ParallelForCancellation
    {
        // Demonstrated features:
        //		CancellationTokenSource
        // 		Parallel.For()
        //		ParallelOptions
        //		ParallelLoopResult
        // Expected results:
        // 		An iteration for each argument value (0, 1, 2, 3, 4, 5, 6, 7, 8, 9) is executed.
        //		The order of execution of the iterations is undefined.
        //		The iteration when i=2 cancels the loop.
        //		Some iterations may bail out or not start at all; because they are temporally executed in unpredictable order, 
        //          it is impossible to say which will start/complete and which won't.
        //		At the end, an OperationCancelledException is surfaced.
        // Documentation:
        //		http://msdn.microsoft.com/library/system.threading.cancellationtokensource(VS.100).aspx
        static void CancelDemo()
        {
            CancellationTokenSource cancellationSource = new CancellationTokenSource();
            ParallelOptions options = new ParallelOptions();
            options.CancellationToken = cancellationSource.Token;

            try
            {
                ParallelLoopResult loopResult = Parallel.For(
                        0,
                        10,
                        options,
                        (i, loopState) =>
                        {
                            Console.WriteLine("Start Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);

                        // Simulate a cancellation of the loop when i=2
                        if (i == 2)
                            {
                                cancellationSource.Cancel();
                            }

                        // Simulates a long execution
                        for (int j = 0; j < 10; j++)
                            {
                                Thread.Sleep(1 * 200);

                            // check to see whether or not to continue
                            if (loopState.ShouldExitCurrentIteration) return;
                            }

                            Console.WriteLine("Finish Thread={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i);
                        }
                    );

                if (loopResult.IsCompleted)
                {
                    Console.WriteLine("All iterations completed successfully. THIS WAS NOT EXPECTED.");
                }
            }
            // No exception is expected in this example, but if one is still thrown from a task,
            // it will be wrapped in AggregateException and propagated to the main thread.
            catch (AggregateException e)
            {
                Console.WriteLine("Parallel.For has thrown an AggregateException. THIS WAS NOT EXPECTED.\n{0}", e);
            }
            // Catching the cancellation exception
            catch (OperationCanceledException e)
            {
                Console.WriteLine("An iteration has triggered a cancellation. THIS WAS EXPECTED.\n{0}", e.ToString());
            }
            finally
            {
                cancellationSource.Dispose();
            }
        }
    }

    public class Example2
    {
        public static void Main2()
        {
            Task[] tasks = new Task[5];
            for (int ctr = 0; ctr <= 4; ctr++)
            {
                int factor = ctr;
                tasks[ctr] = Task.Run(() => Thread.Sleep(factor * 250 + 50));
            }
            int index = Task.WaitAny(tasks);
            Console.WriteLine("Wait ended because task #{0} completed.",
                              tasks[index].Id);
            Console.WriteLine("\nCurrent Status of Tasks:");
            foreach (var t in tasks)
                Console.WriteLine("   Task {0}: {1}", t.Id, t.Status);
        }
    }
}