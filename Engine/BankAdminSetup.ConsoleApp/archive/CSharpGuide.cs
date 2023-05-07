//using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp
{
    public class LearningAboutDelegates
    {
        #region learning about delegates
        public static void MainLearningAboutDelegates()
        {
            //new LearningAboutDelegates.DelegateSecondTest().Test();
            //new UseLoggerContoller(new ConsoleLogger()).Index();
            //new UseLoggerService().Log("you all need to see this", Logger.WriteMessage);
            //new UseLoggerService().Log(Severity.Critical, "EntryPage", "You all need to see this!", new Logger().LogMessage);
            new UseLoggerService().Log(Severity.Critical, "EntryPage", "You all need to see this!", Logger.LogMessage);
        }
        public delegate void Simple<T>(T s);
        public class DelegateTest<T>
        {
            /// <value>
            /// Get a "Simple" object of type string for display
            /// </value>
            
            public static Simple<string> SimpleStringConsoleDisplay { get; set; }
            
            public void DelegateTestMethod()
            {
                SimpleStringConsoleDisplay = new Simple<string>(TakeString);
                SimpleStringConsoleDisplay = TakeString;
                SimpleStringConsoleDisplay("boss");
                SimpleStringConsoleDisplay.Invoke("boss");
            }
            public void TakeString(string s)
            {

            }
        }
        //////////////////////////////2
        public delegate string SingleAnswer(int t, int u);
        public class DelegateSecondTest
        {
            public static SingleAnswer Mathematics { get; set; }
            public static SingleAnswer BooleanAnswer { get; set; }
            public void Test()
            {
                Mathematics += AddInts;
                Mathematics += SubtractInts;
                Mathematics += MultiplyInts;
                Mathematics += DivideInts;

                //string m = Mathematics(10, 20);
                //UseMathematics(10, 20, Mathematics);
                UseMathematics(10, 20, AddInts);
            }
            /// <example>
            /// <code>
            ///  UseMathematics(10, 20, AddInts);
            ///  or
            ///  var sum = AddInts(10,20);
            /// </code>
            /// </example>
            public string AddInts(int a, int b)
            {
                Console.WriteLine(a + b);
                
                return (a + b).ToString();
            }
            public string SubtractInts(int a, int b)
            {//delegate invocation target,
                Console.WriteLine(a - b);

                return (a - b).ToString();
            }
            public string MultiplyInts(int a, int b)
            {//delegate invocation target,
                Console.WriteLine(a * b);

                return (a * b).ToString();
            }
            public string DivideInts(int a, int b)
            {//delegate invocation target,
                Console.WriteLine(a / b);

                return (a / b).ToString();
            }
            public void UseMathematics(int a, int b, SingleAnswer singleAnswer)
            {
                singleAnswer(a, b);
            }
        }
        /// <summary>
        /// SUMMARY:
        /// <para>The main logger service for making writing information, debug, trace and warning messages</para>
        /// <para>Also includes the fatal, danger, error and test messages</para>
        /// </summary>
        /// <remarks>
        /// <para>It has the "WriteMessage" property,</para>
        /// <para>The "LogMessage" method</para>
        /// </remarks>
        public static class Logger// third party logger service
        {
            public static Action<Severity, string, string> WriteMessage;
            public static void LogMessage(Severity severity, string component, string msg)
            {
                WriteMessage(severity, component, msg);
            }
        }

        public static class LoggingMethods// user-defined log-to-console implementation
        {
            public static void LogToConsole(Severity severity, string component, string msg)
            {
                Console.Error.WriteLine($"{severity} {component} {msg}");
            }
            //LogToFile
            //LogToElasticSearch
            //LogToMSSQL
            //LogToEventSource
            //LogToOSEventLog
        }

        public class UseLogger
        {
            public void Index()
            {
                //compliment the WriteMessage function to inc a log to console function
                Logger.WriteMessage += LoggingMethods.LogToConsole;
            }
        }
        #endregion

        #region about async contructors
        public sealed class MyClass
        {
            private String asyncData;
            private MyClass() {  }

            private async Task<MyClass> InitializeAsync()
            {
                asyncData = await GetDataAsync();
                return this;
            }

            private Task<String> GetDataAsync()
            {
                throw new NotImplementedException();
            }

            public static Task<MyClass> CreateAsync()
            {
                var ret = new MyClass();
                return ret.InitializeAsync();
            }
            //private static AsyncLazy<String> resource = new AsyncLazy<String>(async () =>
            //{
            //    string data = await GetResource();
            //    //string ~ ReadOnlySpan<char>
            //    return new String(data);
            //});

            private static Task<String> GetResource()
            {
                return default;
                //throw new NotImplementedException();
            }

            //public static async Task UseResourceAsync()
            //{
            //    String res = await resource;
            //}
        }

        public static async Task UseMyClassAsync()
        {
            MyClass instance = await MyClass.CreateAsync();
            //...
}
        #endregion
    }
}
