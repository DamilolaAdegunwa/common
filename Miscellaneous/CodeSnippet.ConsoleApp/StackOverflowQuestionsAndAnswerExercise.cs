using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp
{
    public class StackOverflowQuestionsAndAnswerExercise
    {
        public static void MainStackOverflow()
        {

        }
        #region question 3
        public class ViewModel : BindableBase
        {

            private DispatcherTimer timerUpdate = null;

            public ViewModel()
            {
                NetworkAvailabilty.Instance.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;

                timerUpdate = new DispatcherTimer();
                timerUpdate.Interval = TimeSpan.FromMinutes(15);
                timerUpdate.Tick += timerUpdate_Tick;

                if (NetworkAvailabilty.Instance.IsNetworkAvailable)
                {
                    timerUpdate.Start();
                }
            }

            private void timerUpdate_Tick(object sender, object e)
            {
                // do something 
            }

            public void OnNetworkAvailabilityChanged(object source, EventArgs e)
            {
                if (NetworkAvailabilty.Instance.IsNetworkAvailable)
                {
                    timerUpdate.Start();
                }
                else
                {
                    timerUpdate.Stop();
                }
            }
            public void OnNetworkAvailabilityChanged2(object source, EventArgs e)
            {
                if (NetworkAvailabilty.Instance.IsNetworkAvailable)
                {
                    //Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    //() =>
                    //{
                    //    timerUpdate.Start();
                    //});
                    SynchronizationContext.Current.Post(s =>
                    {
                        timerUpdate.Start();
                    }, null);
                }
                else
                {
                    //Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    //() =>
                    //{
                    //    timerUpdate.Stop();
                    //});
                    SynchronizationContext.Current.Post(s =>
                    {
                        timerUpdate.Start();
                    }, null);
                }
            }
            private class DispatcherTimer
            {
                public TimeSpan Interval { get; set; }
                public Action<object, object> Tick { get; set; }

                internal void Start()
                {
                    throw new NotImplementedException();
                }

                internal void Stop()
                {
                    throw new NotImplementedException();
                }
            }
            private class NetworkAvailabilty
            {
                public static NetworkAvailabilty Instance { get; set; } = new NetworkAvailabilty();
                public bool IsNetworkAvailable { get; set; }
                public Action<object, EventArgs> NetworkAvailabilityChanged { get; set; }
            }
        }
        public class BindableBase
        {
        }
        #endregion
        #region question 2
        internal class DeliveryDoc
        {
        }
        delegate void DelegateFillList(DeliveryDoc[] deliveryDocs);
        private void FillListViewAssignment(DeliveryDoc[] docs)
        {
            
            //if (lvMyAssignments.Dispatcher.CheckAccess())
            //{
            //    lvMyAssignments.ItemsSource = docs;
            //    lvAllOngoingAssignments.ItemsSource = docs;

            //    if (m_tempDeliveryDocs != null)
            //    {
            //        txtblockHandOverCount.Text = m_tempDeliveryDocs.Length.ToString();
            //    }

            //}
            //else
            //{
            //    lvMyAssignments.Dispatcher.BeginInvoke(
            //        new DelegateFillList(FillListViewAssignment(docs)), null);
            //}
        }
        #endregion
        #region question 1
        public void Question1()
        {
            //Application.Current.Dispatcher.Invoke(default);// WPF dispatcher
            SynchronizationContext.Current.Post(default, null);
        }
        public void Control_Event(object sender, EventArgs e)
        {
            var uiContext = SynchronizationContext.Current;
            Task.Run(() =>
            {
                // do some work
                uiContext.Post(default,default/* update UI controls*/);
            });
        }
        /// <summary>
        /// Start a long series of asynchronous tasks using the `Dispatcher` for coordinating
        /// UI updates.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Via_Dispatcher_OnClick(object sender, RoutedEventArgs e)
        {
            // update initial start time and task status
            /*Time_Dispatcher.Text*/_ = DateTime.Now.ToString("hh:mm:ss");
            /*Status_Dispatcher.Text*/_ = "Started";

            // create UI dont event object
            var uiUpdateDone = new ManualResetEvent(false);

            // Start a new task (this uses the default TaskScheduler, 
            // so it will run on a ThreadPool thread).
            Task.Factory.StartNew(async () =>
            {
                // We are running on a ThreadPool thread here.

                // Do some work.
                await Task.Delay(2000);

                // Report progress to the UI.
                SynchronizationContext.Current.Post(SendOrPostCallback =>
                {
                    /*Time_Dispatcher.Text*/_ = DateTime.Now.ToString("hh:mm:ss");

                    // signal that update is complete
                    uiUpdateDone.Set();
                }, null);

                // wait for UI thread to complete and reset event object
                uiUpdateDone.WaitOne();
                uiUpdateDone.Reset();

                // Do some work.
                await Task.Delay(2000); // Do some work.

                // Report progress to the UI.
                //Application.Current.Dispatcher.Invoke(() =>
                SynchronizationContext.Current.Post(SendOrPostCallback =>
                {
                    /*Time_Dispatcher.Text*/_ = DateTime.Now.ToString("hh:mm:ss");

                    // signal that update is complete
                    uiUpdateDone.Set();
                }, null);

                // wait for UI thread to complete and reset event object
                uiUpdateDone.WaitOne();
                uiUpdateDone.Reset();

                // Do some work.
                await Task.Delay(2000); // Do some work.

                // Report progress to the UI.
                //Application.Current.Dispatcher.Invoke(() =>
                SynchronizationContext.Current.Post(SendOrPostCallback =>
                {
                    /*Time_Dispatcher.Text*/_ = DateTime.Now.ToString("hh:mm:ss");

                    // signal that update is complete
                    uiUpdateDone.Set();
                }, null);

                // wait for UI thread to complete and reset event object
                uiUpdateDone.WaitOne();
                uiUpdateDone.Reset();
            },
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskScheduler.Default)
              .ConfigureAwait(false)
              .GetAwaiter()
              .GetResult()
              .ContinueWith(_ =>
              {
                  //Application.Current.Dispatcher.Invoke(() =>
                  SynchronizationContext.Current.Post(SendOrPostCallback =>
                  {
                      /*Status_Dispatcher.Text*/string Text = "Finished";

                        // dispose of event object
                        uiUpdateDone.Dispose();
                  }, null);
              });
        }

        public void DoAsync()
        {
            //write some code in the main thread
            var uiupdate = new ManualResetEvent(false);
            Task.Factory.StartNew(async () => {
                //you are now on a threadpool thread
                //do some work (async work)

                SynchronizationContext.Current.Post(sopb => {
                    /*repeat what you did in d main thread*/
                    uiupdate.Set();
                }, null);
                uiupdate.WaitOne();
                uiupdate.Reset();
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Via_SynchronizationContext_OnClick(object sender, RoutedEventArgs e)
        {
            // update initial time and task status
            /*Time_SynchronizationContext.Text*/_ = DateTime.Now.ToString("hh:mm:ss");
            /*Status_SynchronizationContext.Text*/_ = "Started";

            // capture synchronization context
            var sc = SynchronizationContext.Current;

            // Start a new task (this uses the default TaskScheduler, 
            // so it will run on a ThreadPool thread).
            Task.Factory.StartNew(async () =>
            {
                // We are running on a ThreadPool thread here.

                // Do some work.
                await Task.Delay(2000);

                // Report progress to the UI.
                sc.Send(state =>
                {
                    /*Time_SynchronizationContext.Text*/_ = DateTime.Now.ToString("hh:mm:ss");
                }, null);

                // Do some work.
                await Task.Delay(2000);

                // Report progress to the UI.
                sc.Send(state =>
                {
                    /*Time_SynchronizationContext.Text*/_ = DateTime.Now.ToString("hh:mm:ss");
                }, null);

                // Do some work.
                await Task.Delay(2000);

                // Report progress to the UI.
                sc.Send(state =>
                {
                    /*Time_SynchronizationContext.Text*/_ = DateTime.Now.ToString("hh:mm:ss");
                }, null);
            },
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskScheduler.Default)
            .ConfigureAwait(false)
            .GetAwaiter()
            .GetResult()
            .ContinueWith(_ =>
            {
                sc.Post(state =>
                {
                    /*Status_SynchronizationContext.Text*/string text = "Finished";
                }, null);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Via_TaskScheduler_OnClick(object sender, RoutedEventArgs e)
        {
            /*Time_TaskScheduler.Text*/_ = DateTime.Now.ToString("hh:mm:ss");


            // This TaskScheduler captures SynchronizationContext.Current.
            var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            /*Status_TaskScheduler.Text*/_ = "Started";

            // Start a new task (this uses the default TaskScheduler, 
            // so it will run on a ThreadPool thread).
            Task.Factory.StartNew(async () =>
            {
                // We are running on a ThreadPool thread here.

                // Do some work.
                await Task.Delay(2000);

                // Report progress to the UI.
                var reportProgressTask = ReportProgressTask(taskScheduler, () =>
                {
                    /*Time_TaskScheduler.Text*/_ = DateTime.Now.ToString("hh:mm:ss");
                    return 90;
                });

                // get result from UI thread
                var result = reportProgressTask.Result;
                Debug.WriteLine(result);

                // Do some work.
                await Task.Delay(2000); // Do some work.

                // Report progress to the UI.
                reportProgressTask = ReportProgressTask(taskScheduler, () =>
                {
                    /*Time_TaskScheduler.Text*/_ = DateTime.Now.ToString("hh:mm:ss");
                    return 10;
                });

                // get result from UI thread
                result = reportProgressTask.Result;
                Debug.WriteLine(result);

                // Do some work.
                await Task.Delay(2000); // Do some work.

                // Report progress to the UI.
                reportProgressTask = ReportProgressTask(taskScheduler, () =>
                {
                    /*Time_TaskScheduler.Text*/_ = DateTime.Now.ToString("hh:mm:ss");
                    return 340;
                });

                // get result from UI thread
                result = reportProgressTask.Result;
                Debug.WriteLine(result);
            },
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskScheduler.Default)
              .ConfigureAwait(false)
              .GetAwaiter()
              .GetResult()
              .ContinueWith(_ =>
              {
                  var reportProgressTask = ReportProgressTask(taskScheduler, () =>
                  {
                      /*Status_TaskScheduler.Text*/string Text = "Finished";
                      return 0;
                  });
                  reportProgressTask.Wait();
              });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskScheduler"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        private Task<int> ReportProgressTask(TaskScheduler taskScheduler, Func<int> func)
        {
            var reportProgressTask = Task.Factory.StartNew(func,
              CancellationToken.None,
              TaskCreationOptions.None,
              taskScheduler);
            return reportProgressTask;
        }
        private class RoutedEventArgs
        {
        }
        #endregion
    }

    
}
