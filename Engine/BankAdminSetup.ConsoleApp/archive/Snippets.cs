//using FakeItEasy;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Fabric;
//using System.Fabric.Description;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System.Collections;
//using System.Numerics;
//using System.Runtime.InteropServices;
//using Newtonsoft.Json;
//using System.Linq.Expressions;
//using System.IO;
//using System.Web;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Runtime.CompilerServices;
//using System.Runtime.Loader;
//using System.Reflection;
//using Newtonsoft.Json.Linq;
//using System.Timers;
//using Microsoft.Extensions.Primitives;
//using Microsoft.Extensions.FileProviders;
//using Polly;
//using Polly.Extensions.Http;
//using Microsoft.Extensions.Http;
//using System.Collections.Specialized;
//using static System.Text.StringBuilder;
//using System.Threading.Channels;
//using System.Threading.Tasks;
//using System.Threading.Tasks.Dataflow;
//using System.Collections.Concurrent;
//using System.Threading;
//using System.ComponentModel;
//using Nito.AsyncEx;
////using Microsoft.Tpl.Dataflow;
//using System.Reactive;
////using System.Reactive.Core;
////using System.Reactive.Interfaces;
//using System.Reactive.Linq;
//using System.Reactive.PlatformServices;
//using Microsoft.Reactive.Testing;
//using EO.Base.UI;
//using System.Fabric.Description;
//using System.Fabric;
////using Microsoft.Tpl.Dataflow;
////using Microsoft.Bcl.Immutable;
//using System.Collections.Immutable;
//using System.Drawing.Drawing2D;

//namespace CodeSnippet.ConsoleApp.Services
//{
//    #region ---
//    //ImmutableStack<T> ist = default;
//    ////System.Collections.Immutable includes many others!!

//    //ConcurrentDictionary<string, int> cdtt = default;
//    //BlockingCollection<T> ts = default;
//    ////System.Collections.Concurrent ...

//    //AsyncProducerConsumerQueue<T> asyncpc = default;
//    //AsyncCollection<T> asyncC = default;
//    ////Nito.AsyncEx ...

//    //BufferBlock<T> bb = default;
//    ////System.Threading.Tasks.Dataflow

//    //someService some = Activator.CreateInstance<someService>();
//    //some.MyProperty = 125;
//    //Console.WriteLine(some.MyProperty);

//    #endregion
//    public class someService
//    {
//        public someService()
//        {
//            Console.WriteLine("the constructor was called!");
//        }
//        public int MyProperty { get; set; }
//    }
//    public class Class2
//    {
//        void DoLongOperation()
//        {
//            var operationId = Guid.NewGuid();
//            //CallContext.LogicalSetData("OperationId", operationId);
//            DoSomeStepOfOperation();
//            //CallContext.FreeNamedDataSlot("OperationId");
//        }
//        void DoSomeStepOfOperation()
//        {
//            // Do some logging here.
//            //Trace.WriteLine("In operation: " + CallContext.LogicalGetData("OperationId"));
//        }
//        IEnumerable<int> ParallelMultiplyBy2(IEnumerable<int> values)
//        {
//            return values.AsParallel()
//            .WithDegreeOfParallelism(10)
//            .Select(item => item * 2);
//        }
//        // Using the Parallel class
//        void ParallelRotateMatrices(IEnumerable<Matrix> matrices, float degrees)
//        {
//            var options = new ParallelOptions
//            {
//                MaxDegreeOfParallelism = 10
//            };
//            Parallel.ForEach(matrices, options, matrix => matrix.Rotate(degrees));
//        }
//        public AsyncLazy<int> Data
//        {
//            get { return _data; }
//        }
//        public void Fetch(in int x, int y, in string z)
//        {
//            y = 10 + x;

//            //x = 40; //compile time error!
//        }

//        private readonly AsyncLazy<int> _data =
//        new AsyncLazy<int>(async () =>
//        {
//            await Task.Delay(TimeSpan.FromSeconds(1));
//            return 13;
//        });
//        public static class AsyncInitialization
//        {
//            static Task WhenAllInitializedAsync(params object[] instances)
//            {
//                return Task.WhenAll(Task.FromResult(instances.OfType<string>().Select(x => x)));
//            }
//        }
//    }
//    public class LifetimeManager
//    {
//        FabricClient _client;
//        IReliableStateMangerReplica _stateMgr;
//        public LifetimeManager(IReliableStateMangerReplica stateMgr)
//        {
//            _stateMgr = stateMgr;
//            _client = new FabricClient();
//        }
//        public async Task<GameSession> CreateAsync(string serviceType, string pKey)
//        {
//            //var service = ServiceDescriptorFactory.Get(serviceType);
//            //if (service == null) throw new ArgumentException("cnt be found");
//            StatefulServiceDescription sd = new StatefulServiceDescription();
//            sd.ApplicationName = new Uri("www.DamilolaAdegunwa.com");
//            sd.HasPersistedState = true;
//            sd.MinReplicaSetSize = default;
//            sd.PartitionSchemeDescription = new SingletonPartitionSchemeDescription();
//            new UniformInt64RangePartitionSchemeDescription(1, 0, 0);

//            await _client.ServiceManager.CreateServiceAsync(sd);



//            return default;
//        }
//    }
//    public class GameSession
//    {
//    }

//    public interface IReliableStateMangerReplica
//    {
//    }
//    public class Class1
//    {
//        public static void/*async Task*/ StringInterploationSample1()
//        {
//            var titles = new Dictionary<string, string>()
//            {
//                ["Doyle, Arthur Conan"] = "Hound of the Baskervilles, The",
//                ["London, Jack"] = "Call of the Wild, The",
//                ["Shakespeare, William"] = "Tempest, The"
//            };
//            Console.WriteLine("Author and Title List");
//            Console.WriteLine();
//            Console.WriteLine($"|{"Author",25}|{"Title",30}|");
//            foreach (var title in titles)
//            {
//                Console.WriteLine($"|{title.Key,25}|{title.Value,30}|");
//            }
//            Console.WriteLine($"[{DateTime.Now,-20:d}] Hour [{DateTime.Now,-10:HH}] [{1063.342,15:N2}] feet");
//            Console.ReadLine();
//        }
//    }

//    public interface ISomeInInterface<in T>
//    {
//        //this code deos not compile
//        //Task<T> method1();
//        //T method1();
//        void method2(T t);
//    }

//    public interface ISomeOutInterface<out T>
//    {
//        T method1();
//        //this code deos not compile
//        //void method2(int d, T t, string s);
//    }
//    #region parallel programming (to be cont'd)
//    //public static async Task Main()
//    //{
//    //    Action action = () => { Console.WriteLine("Done!!"); };
//    //    IObservable<string> observable = Observable.Return<string>("Damilola");
//    //    //Observable.Return("stub").Delay(Delay, Scheduler);
//    //    var t = new TaskCompletionSource<string>();
//    //    t.TrySetResult("doom!");
//    //    var tt = await t.Task;
//    //    StatefulServiceDescription d = Activator.CreateInstance<StatefulServiceDescription>();
//    //    var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
//    //    var subtractBlock = new TransformBlock<int, int>(item => item - 2);
//    //    // After linking, values that exit multiplyBlock will enter subtractBlock.
//    //    multiplyBlock.LinkTo(subtractBlock);
//    //}
//    //IEnumerable<bool> PrimalityTest(IEnumerable<int> values)
//    //{
//    //    return values.AsParallel().Select(val => {
//    //        var x = 1;
//    //        var y = 2;
//    //        var z = 3;

//    //        var a = 4;
//    //        var b = 5;
//    //        var c = 6;
//    //        return a == b;
//    //    }/*IsPrime(val)*/);
//    //}
//    //private void Button_Click(object sender, RoutedEventArgs e)
//    //{
//    //    Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
//    //    handler => (s, a) => handler(s, a),
//    //    handler => MouseMove += handler,
//    //    handler => MouseMove -= handler)
//    //    .Select(x => x.EventArgs.GetPosition(this))
//    //    .Sample(TimeSpan.FromSeconds(1))
//    //    .Subscribe(x => Trace.WriteLine(
//    //    DateTime.Now.Second + ": Saw " + (x.X + x.Y)));
//    //}
//    #endregion

//    #region simple parallel programming 2
//    //static List<int> vsint = new int[] { 1, 2, 3, 4, 5, 6 }.ToList();//new List<int>();
//    //public static async Task Main()
//    //{
//    //    List<int> vsint = new List<int>();
//    //    Task.Run(() => { vsint = new int[] { 1, 2, 3, 4, 5, 6 }.ToList(); return "love!"; }).ContinueWith( tk => {
//    //        foreach (var j in vsint)
//    //        {
//    //            Console.WriteLine(j);
//    //        }
//    //    });
//    //    Console.WriteLine("done!");
//    //}
//    #endregion

//    #region simple parallel programming 1
//    //public static async Task Main()
//    //{
//    //    var e = Enumerable.Range(1, 100000);
//    //    //var d = Channel.CreateUnbounded<int>();
//    //    List<int> vs = new List<int>();
//    //    Task.Run(async () =>
//    //    {
//    //        Parallel.ForEach(e, i =>
//    //        {
//    //            Task.Run(async () =>
//    //            {
//    //                //d.Writer.TryWrite(i);
//    //                vs.Add(i);
//    //            });

//    //        });
//    //    });
//    //    while (true)
//    //    {

//    //        Task.Run(async () =>
//    //        {
//    //            //Console.WriteLine(_ = (await d.Reader.ReadAsync()));
//    //            Console.WriteLine(vs.FirstOrDefault());
//    //        });
//    //        //break;
//    //    }
//    //}
//    #endregion

//    #region Channel
//    //public static async Task Main()
//    //{
//    //    //BackgroundWorker backgroundWorker = new BackgroundWorker();

//    //    //var c = new MyQueue<int>();
//    //    var d = Channel.CreateUnbounded<int>();
//    //    _ = Task.Run(async delegate
//    //    {
//    //        for (var i = 0; true; i++)
//    //        {
//    //            await Task.Delay(100);
//    //            //c.Write(i);
//    //            d.Writer.TryWrite(i);
//    //        }
//    //    });
//    //    //var z = await d.Reader.ReadAllAsync().ToListAsync();// if your your aim is to get it all as a list
//    //    while (true)
//    //    {
//    //        //Console.WriteLine((_ = await c.ReadAsync()));
//    //        Console.WriteLine(_ = await d.Reader.ReadAsync());
//    //    }
//    //}

//    #endregion

//    #region Unsafe and Trials!
//    //public static void Main()
//    //{
//    //    
//    //    //public enum AccountType
//    //    //{
//    //    //    Android = 0, IOS = 1, Web = 2, Mobile = Android | IOS
//    //    //}
//    //    //string x = Activator.CreateInstance<string>();  
//    //    ////void x = ;
//    //    //AccountType accountType1 = AccountType.Android;
//    //    //AccountType accountType2 = AccountType.IOS;

//    //    //if(accountType1 == AccountType.Mobile && accountType2 == AccountType.Mobile)
//    //    //{
//    //    //    Console.WriteLine("both accounts are mobile!!");
//    //    //}else
//    //    //{
//    //    //    Console.WriteLine("they are not!!");
//    //    //}
//    //    //unsafe
//    //    //{
//    //    //    int a = 10;
//    //    //    int b = 20;
//    //    //    int c = 30;

//    //    //    int* ptra = &a;
//    //    //    int* ptrb = &b;
//    //    //    int* ptrc = &c;


//    //    //    Console.WriteLine((int)ptra);
//    //    //    Console.WriteLine(*ptra);


//    //    //}

//    //    ////string ptr = Convert.ToInt32(&x);
//    //    //byte[] byt = new byte[] { };
//    //    //BitConverter.ToInt32(byt);
//    //    //BinaryReader binaryReader = default;
//    //    

//    //    Console.WriteLine("done!");
//    //    Console.ReadLine();
//    //}
//    #endregion
//    #region orchard
//    //[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
//    //public class BackgroundTaskAttribute : Attribute
//    //{
//    //    public bool Enable { get; set; } = true;
//    //    public string Schedule { get; set; } = "*/5 * * * *";
//    //    public string Description { get; set; } = String.Empty;
//    //}
//    //[BackgroundTask]
//    //public class BGTest
//    //{

//    //}
//    #endregion
//    #region fake it easy
//    ////Model
//    //public class Request
//    //{
//    //    public string Param { get; set; }
//    //}
//    ////Repository
//    //public class MyRepository : IMyRepository
//    //{
//    //    public string Get(Expression<Func<Request, bool>> query) { return default; }
//    //}
//    ////Service
//    //public class MyService
//    //{
//    //    private readonly IMyRepository _myRepository;
//    //    public MyService(IMyRepository myRepository)
//    //    {
//    //        _myRepository = myRepository;
//    //    }
//    //    public string Search(string searchText)
//    //    {
//    //        return _myRepository.Get(x => x.Param == searchText);
//    //    }
//    //}
//    //[TestClass]
//    //public class DashboardServiceTest
//    //{
//    //    MyService service;
//    //    IMyRepository _fakeMyRepository;
//    //    public void Initialize()
//    //    {
//    //        _fakeMyRepository = A.Fake<IMyRepository>();
//    //        service = new MyService(_fakeMyRepository);
//    //    }
//    //    [TestMethod]
//    //    public void GetFilteredRfqs_FilterBy_RfqId()
//    //    {
//    //        //var result = service.Search("abc");
//    //        //A.CallTo(() => _fakeMyRepository.Get(A<Expression<Func<Request, bool>>>._)).MustHaveHappened();
//    //        //A.CallTo(() => _fakeMyRepository.Get(x => x.Param == "abc")).MustHaveHappened();
//    //        //A.CallTo(() => _fakeMyRepository.Get(x => x.Param == "abc")).WhenArgumentsMatch(default);
//    //        //A.CallTo(() => _fakeMyRepository.Get(x => x.Param == "abc")).WhenArgumentsMatch((Expression<Func<Request, bool>> query) => true).Returns("Correctly worked!!");
//    //        //A.CallTo(() => _fakeMyRepository.Get(x => x.Param == "abc")).WhenArgumentsMatch((Expression<Func<Request, bool>> query) => query.ReturnType.Name == "xyz").Throws<Exception>();
//    //        //var s = A<string>.That.Matches(s => s.Length == 3 && s[1] == 'X');
//    //        //query.Equals(default)
//    //        var req = new Request
//    //        {
//    //            Param = "My Soul"
//    //        };
//    //        Expression<Func<Request, bool>> ExReq = req => req.Param.Contains("q");
//    //        A.CallTo(() => _fakeMyRepository.Get(A<Expression<Func<Request, bool>>>.That.Matches(ExReq => ExReq.Body.ToString() == "req.Param.Contains(\"q\")"))).MustHaveHappened();
//    //    }
//    //}
//    //public interface IMyRepository
//    //{
//    //    public string Get(Expression<Func<Request, bool>> query);
//    //}
//    #endregion

//    #region Smaller numbers than current
//    /*
//     public class Solution
//    {
//        public int[] SmallerNumbersThanCurrent(int[] nums)
//        {

//            var groups = nums
//                .Select((val, index) => new { index, val })
//                .GroupBy(x => x.val)
//                .OrderBy(g => g.Key)
//                .Select(g => g.Select(x => x.index).ToArray());

//            var arr = new int[nums.Length];

//            int numSmaller = 0;

//            foreach (var indices in groups)
//            {
//                foreach (var index in indices)
//                {
//                    arr[index] = numSmaller;
//                }

//                numSmaller += indices.Length;
//            }

//            return arr;
//        }

//        public int[] SmallerNumbersThanCurrentShorter(int[] nums)
//        {
//            return (from x in nums select (from y in nums where y < x select y).Count()).ToArray();
//        }
//    }
//    */
//    #endregion

//    #region sqlconnection snippet
//    /*
//    SqlConnection con = new SqlConnection("Data Source=MCNDESKTOP03;Initial Catalog=pulkit;User ID=sa;Password=wintellect@123");
//    SqlCommandBuilder cmd;
//    SqlDataAdapter da;
//    DataSet ds;

//    private void Form1_Load(object sender, EventArgs e)
//    {
//     con.Open();
//     da = new SqlDataAdapter("select *from emp5", con);
//     cmd = new SqlCommandBuilder(da);
//     ds = new DataSet();
//     da.Fill(ds);
//     dataGridView1.DataSource = ds.Tables[0];
//     con.Close();
//    }
//     */
//    #endregion

//    #region writting to the event log (event viewer)
//    /*
//     using System;  
//using System.Collections.Generic;  
//using System.Linq;  
//using System.Text;  
//using System.Diagnostics;  
//using System.IO;  
//using System.Security.Permissions;  
  
//namespace Common {  
//    //This Class is used for logging messages to either a custom EventViewer or in a plain text file located on web server.

//    public class Logging
//    {
//        #region "Variables"  

//        private string sLogFormat;
//        private string sErrorTime;

//        #endregion


//        #region "Local methods"  

//        //Write to Txt Log File
//        public void WriteToLogFile(string sErrMsg)
//        {
//            try
//            {
//                //sLogFormat used to create log format :  
//                // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message  
//                sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

//                //this variable used to create log filename format "  
//                //for example filename : ErrorLogYYYYMMDD  
//                string sYear = DateTime.Now.Year.ToString();
//                string sMonth = DateTime.Now.Month.ToString();
//                string sDay = DateTime.Now.Day.ToString();
//                sErrorTime = sYear + sMonth + sDay;

//                //writing to log file  
//                string sPathName = "C:\\Logs\\ErrorLog" + sErrorTime;
//                StreamWriter sw = new StreamWriter(sPathName + ".txt", true);
//                sw.WriteLine(sLogFormat + sErrMsg);
//                sw.Flush();
//                sw.Close();
//            }
//            catch (Exception ex)
//            {
//                WriteToEventLog("MySite", "Logging.WriteToLogFile", "Error: " + ex.ToString(), EventLogEntryType.Error);
//            }
//        }
        
//    public void WriteToEventLog(string sLog, string sSource, string message, EventLogEntryType level) {  
//    //RegistryPermission regPermission = new RegistryPermission(PermissionState.Unrestricted);  
//    //regPermission.Assert();  
  
//    if (!EventLog.SourceExists(sSource)) EventLog.CreateEventSource(sSource, sLog);  
  
//    EventLog.WriteEntry(sSource, message, level);  
//    }  
 
//    #endregion
//    }  
//    } 
//     */
//    #endregion

//    #region Parameter Lines Sorter
//    /*
//     public class ParameterLinesSorter : IParameterLinesSorter
//    {
//        private int identiferIndex;
//        private IEnumerable<string[]> parameterLines;

//        public IEnumerable<IEnumerable<string[]>> Sort(IEnumerable<string[]> parameterLines, int identiferIndex)
//        {
//            this.identiferIndex = identiferIndex;
//            this.parameterLines = parameterLines;

//            return IsNotNullAndNotEmpty() ? FilterAndSort() : new List<IEnumerable<string[]>>();
//        }

//        private bool IsNotNullAndNotEmpty()
//        {
//            return parameterLines != null && parameterLines.Any();
//        }

//        private IEnumerable<IEnumerable<string[]>> FilterAndSort()
//        {
//            var resp = parameterLines
//                .Where(parameterLine => parameterLine.Any())
//                .GroupBy(parameterLine => parameterLine.ElementAt(identiferIndex));
//            return resp;
//        }
//        [Test]
//        public void ShouldReturnListWithTwoGroupsOfOneElement()
//        {
//            IEnumerable<string[]> parameterLines = new List<string[]>() {
//                new string[]{ "C", "3", "3" },
//                new string[]{ "M", "3", "5" }
//            };

//            #region hand tested q and a
//            IEnumerable<string[]> parameterLines2 = new List<string[]>() {
//                new string[]{ "A", "5", "2" },
//                new string[]{ "A", "3", "0" },
//                new string[]{ "A", "1", "2" },
//                new string[]{ "B", "3", "4" },
//                new string[]{ "B", "5", "6" },
//                new string[]{ "B", "7", "8" },
//                new string[]{ "B", "9", "10" },
//                new string[]{ "B", "11", "12" },
//                new string[]{ "B", "12", "14" },
//            };

//            var answer = new List<IEnumerable<string[]>>()//using parameter2
//            {
//                new List<string[]>()
//                {
//                    new string[]{ "A", "5", "2" },
//                    new string[]{ "A", "3", "0" },
//                    new string[]{ "A", "1", "2" },
//                },
//                new List<string[]>()
//                {
//                    new string[]{ "B", "3", "4" },
//                    new string[]{ "B", "5", "6" },
//                    new string[]{ "B", "7", "8" },
//                    new string[]{ "B", "9", "10" },
//                    new string[]{ "B", "11", "12" },
//                    new string[]{ "B", "12", "14" },
//                },
//            };
//            #endregion

//            IEnumerable<IEnumerable<string[]>> expectedGroups = new List<IEnumerable<string[]>>() {
//                new List<string[]>(){ new string[]{ "C", "3", "3" }},
//                new List<string[]>(){ new string[]{ "M", "3", "5" }}
//            };

//            Assert.AreEqual(expectedGroups, Sort(parameterLines, 0));
//        }
//    }

//    public interface IParameterLinesSorter
//    {
//    }
//    */
//    #endregion

//    #region I didn't make out time to organize it
//    //public static class myExtension
//    //{
//    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
//    //    public static void NoWarning(this Task task) { }
//    //}
//    //    string path = AppDomain.CurrentDomain.BaseDirectory;
//    //    //C:\Users\DamilolaAdegunwa\source\repos\common\Miscellaneous\CodeSnippet.ConsoleApp\bin\Debug\netcoreapp3.1\
//    //    var enviroment = Environment.CurrentDirectory;
//    //    //C:\Users\DamilolaAdegunwa\source\repos\common\Miscellaneous\CodeSnippet.ConsoleApp\bin\Debug\netcoreapp3.1
//    //    string currentDirectory = Directory.GetCurrentDirectory();
//    //    //C:\Users\DamilolaAdegunwa\source\repos\common\Miscellaneous\CodeSnippet.ConsoleApp\bin\Debug\netcoreapp3.1
//    //    string projectDirectory = Directory.GetParent(enviroment).Parent.Parent.FullName;

//    //    var processes = Process.GetProcesses();
//    //    var processesCount = processes.Count();
//    //    var processNumber = 0;
//    //            foreach (var p in processes)
//    //            {
//    //                var processName = p.ProcessName;
//    //    var threadsInProcess = p.Threads.Count;
//    //    Console.WriteLine($"Process {++processNumber}: {processName} having {threadsInProcess} thread(s)\n");
//    //                for (var t = 0; t<threadsInProcess; ++t)
//    //                {
//    //                    var eachThread = p.Threads[t];
//    //    //Console.WriteLine();
//    //}
//    //            }
//    //public class MyContext : AssemblyLoadContext
//    //{
//    //    private AssemblyDependencyResolver _resolver;
//    //    public MyContext(string path)
//    //    {
//    //        _resolver = new AssemblyDependencyResolver(path);
//    //    }
//    //    protected override Assembly Load(AssemblyName assemblyName)
//    //    {
//    //        var path = _resolver.ResolveAssemblyToPath(assemblyName);
//    //        if (path != null)
//    //        {
//    //            return LoadFromAssemblyPath(path);
//    //        }
//    //        return base.Load(assemblyName);
//    //    }
//    //}
//    //public class TupleTest
//    //{
//    //    public TupleTest()
//    //    {
//    //        (int x, int y) = (10, 20);
//    //        (int x, int y) p = (10, 20);
//    //        var p2 = (10, 20);
//    //        _ = (10, 20);
//    //    }
//    //}
//    //public class SwitchTest : IDisposable
//    //{
//    //    public void Dispose()
//    //    {
//    //        throw new NotImplementedException();
//    //    }

//    //    public void SwitchTestMethod()
//    //    {
//    //        Dummy dummy = new Dummy { Id = 1, BarCode = "12345", DateCreated = DateTime.Now.AddDays(-50), Name = "Bon-Boy" };
//    //        string result = dummy switch
//    //        {
//    //            //Dummy { Id: 1 } d => "fine"
//    //            Dummy(string Id) d => "fine"
//    //            //Dummy { Id: 1, BarCode : "12345"} d => "fine"
//    //        };
//    //    }
//    //    public class Dummy
//    //    {
//    //        public int Id { get; set; }
//    //        public string Name { get; set; }
//    //        public string BarCode { get; set; }
//    //        public DateTime DateCreated { get; set; }

//    //        public void Deconstruct(out string MyP)
//    //        {
//    //            MyP = "12";
//    //        }
//    //    }
//    //}
//    //var context = new MyContext(typeof(Program).Assembly.Location);
//    ////var context = new MyContext();
//    //var jsonInContext = context.LoadFromAssemblyName(new AssemblyName("Newtonsoft.Json"));
//    //var jObjectType = jsonInContext.GetType(typeof(JObject).FullName);
//    //var jobj = Activator.CreateInstance(jObjectType);
//    //var jObjectInContext = (JObject)jobj;
//    //Console.WriteLine("");
//    ////new AssemblyDependencyResolver("").
//    ////await? 
//    ////int? df ??= 3;
//    ////var sd = ["name":2];
//    ////using string xx = null!;
//    ////Span<int> data = new int[] {0,1,2,3,4,5,6,7,8,9,10 };
//    ////foreach(var n in data[^6..])
//    ////{
//    ////    Console.WriteLine(n);
//    ////}
//    ////var slice = data.Slice(5..^1);
//    //await foreach(var n in GetAsync())
//    //{

//    //}
//    //public static async IAsyncEnumerable<int> GetAsync()
//    //{

//    //    string ss = "fish";
//    //    ss ??= "hmm...";
//    //    //if!(true){ }
//    //    //if(int is not int){ }
//    //    //unless(true){ }
//    //    //bool exist = false;

//    //    //exist &&= true;
//    //    //exist ||= true;

//    //    //var sd = ["name":2];
//    //    using (var st = new SwitchTest()) ;
//    //    for (var i = 0; i < 10; i++)
//    //    {
//    //        yield return await Task.FromResult(i);
//    //    }
//    //}
//    #endregion

//    #region learning to write implicit/explicit with ConvertAll and extension method
//    //List<Person> person = new List<Human>().ConvertAll(h => (Person)h).ToList();
//    public static class EnumerableExtension
//    {
//        public static List<Human> Humen(this List<Human> humen)
//        {
//            return default;
//        }
//    }
//    public class Human
//    {
//        public int Id { get; set; }
//        public string BotanicalName { get; set; }
//        public int BioAge { get; set; }
//    }
//    public class Person
//    {
//        public int Reference { get; set; }
//        public string FullName { get; set; }
//        public int Age { get; set; }

//        public static explicit operator Person(Human human)
//        {
//            var p = new Person
//            {
//                Reference = human.Id,
//                FullName = human.BotanicalName,
//                Age = human.BioAge
//            };
//            return p;
//        }
//    }
//    #endregion

//    #region task speed test
//    //public enum Boys { kolade, mayowa, adefarati}
//    //Activator.CreateInstance<string>();
//    //Type CardType = typeof(VISA);
//    //public class VISA { }
//    //public class MasterCard { }
//    //public class LayeredTask
//    //{
//    //    public static void OuterLayer()
//    //    {
//    //        Console.ReadLine();
//    //        //var watch = System.Diagnostics.Stopwatch.StartNew();
//    //        ////Task.Run(() => {
//    //        //    for (var x = 1; x < 100_000_000; x++){}
//    //        //    SecondLayer();
//    //        ////});

//    //        //var elapsedTime = watch.ElapsedMilliseconds;
//    //        ////without task 791ms, 918ms, 870ms, 756ms,807ms
//    //        ////with task 279ms
//    //        ////with nested task 70ms, 63ms, 63ms, 59, 68, 55, 55, 71, 67, 64, 61, 60, 48 (with first async 61, 54, 59, 65, 63 | all async 68, 50, 85, 54, 74, 68, 67 | all await)

//    //        ////conclusions
//    //        ////1) as much as possible, wrap your work in a Task.Run,
//    //        ////2) await affects speed, use wisely!!
//    //        ////3) async on method makes little difference in speed
//    //        //watch.Stop();
//    //    }
//    //    //public static void SecondLayer()
//    //    //{
//    //    //    Task.Run(() => {
//    //    //        for (var x = 1; x < 100_000_000; x++)
//    //    //        {
//    //    //            //Console.WriteLine("");
//    //    //        }
//    //    //        ThirdLayer();
//    //    //    });

//    //    //}
//    //    //public static void ThirdLayer()
//    //    //{
//    //    //    Task.Run(() => {
//    //    //        for (var x = 1; x < 100_000_000; x++)
//    //    //        {
//    //    //            //Console.WriteLine("");
//    //    //        }
//    //    //    });

//    //    //}
//    //}
//    #endregion

//    //new Partitioning().ForEachPartition();
//    //var a = Enumerable.Range(1, 300);
//    //var b = Enumerable.Repeat("Win", 10);
//    //var c = Enumerable.Cast<string>(new int[] { 1, 2, 3 }).ToList();
//    //var fileInfo = new FileInfo(Path.Combine(""));
//    //String S = "SSSSSS";
//    //string s = "ssssss";
//    //var Str = new String(new char[] { 'I','L','Y' });
//    //var Str2 = new String('I',10);
//    //var str = new string(new char[] { 'I', 'L', 'Y' });
//    //Equals(1, 1);
//    //ReferenceEquals(1,1);
//    //NameValueCollection v;
//    ////KeyValueMapping
//    //ChunkEnumerator ce = default;
//    ////Microsoft.
//    //foreach(var s in "1234567890")
//    //{
//    //    Console.WriteLine("this would show!");
//    //    continue;
//    //    Console.WriteLine("this would not show!");
//    //}
//    //new GeoCoordinate();
//    //the distance between okota & aba
//    //Console.WriteLine(Calculate(6.5088, 3.3137, 5.1216, 7.3733));

//    //distance between lagos and abuja is (698.7 km) (distance)
//    //Console.WriteLine(Calculate(6.5236, 3.6006, 9.0765, 7.3986)); //505.23466046853935 (displacement)

//    //the distance between lagos and kaduna is (770.4 km) (distance)
//    //Console.WriteLine(Calculate(6.5236, 3.6006, 10.3764 , 7.7095));//622.2162062356526 (displacement)

//    //okota and mile 2 (9.8 km), 8, 7.8, 6 (distance)
//    //Console.WriteLine(Calculate(6.4659, 3.3198, 6.5088, 3.3137));//4.839564161881872 | 4.8142811141800745 (displacement)

//    //Console.WriteLine(new List<string>().FirstOrDefault().Length);
//}

///*
//I'd write out my task here 
//*/
