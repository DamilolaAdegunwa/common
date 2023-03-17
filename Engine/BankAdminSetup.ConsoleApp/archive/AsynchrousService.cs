//#nullable enable
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using CodeSnippet.ConsoleApp.Models;
//using Microsoft.Extensions.DependencyInjection;
////using System.Windows.Threading;
//namespace CodeSnippet.ConsoleApp.Services
//{
//    //public async class AsynchrousService // lesson 1: you cannot async a class
//    public class AsynchrousService
//    {
//        public Task<Customer> GetCustomersAsync()
//        {
//            return default;
//        }
//    }
//    public class NonAsynchrousService
//    {
//        private readonly AsynchrousService Service;

//        public NonAsynchrousService()
//        {
//            this.Service = new AsynchrousService();
//        }

//        static ServiceProvider GetContainer()
//        {
//            var services = new ServiceCollection();
//            //services.AddTransient<IGreetingService, GreetingService>();
//            //services.AddTransient<HelloController>();
//            return services.BuildServiceProvider();
//        }

//        public async Task<Customer> GetCustomers()
//        {
//            await Task.Yield();
//            return _ = await Service.GetCustomersAsync();
//        }
//        public void Execute()
//        {
//            TaskScheduler scheduler = default;

//            Task<Customer> task1 = GetCustomers();
//            task1.Wait();

//            Task<Customer> task2 = GetCustomers();
//            task2.RunSynchronously();

//            Task<Customer> task3 = GetCustomers();
//            //Task<Customer?> T = default;
//            while (task3.Status != TaskStatus.RanToCompletion) { }
//        }
//        public async void CSharpEightNewFeatures()
//        {
//            //Span<string> ss = new string[] { "","","", "", "", "", "", "", "", "", "", "" };
//            //var ssv = ss[2..];
//            IAsyncEnumerable<Customer?> GetCustomersAsync(Span<Customer?> args)
//            {
                
//                return default;
//            }
//            Span<Customer?> SpanOfCustomers()
//            {
//                Span<Customer?> args = new Customer?[] { new Customer(), new Customer(), new Customer(), new Customer(), new Customer() };
//                return args;
//            }
//            //Span<Customer?> args = new Customer?[] { new Customer(), new Customer(), new Customer(), new Customer(), new Customer()};
//            IAsyncEnumerable<Customer?> customers = GetCustomersAsync(SpanOfCustomers()[2..]);
//            await foreach(Customer? customer in customers)
//            {
//                string? name = customer switch
//                {
//                    null => null,
//                    (null, string last) => $"Ms/Mr {last}",
//                    (string first, string last) => $"{first[0]}. {last}",
//                    (string first, string last, string middle) => $"{first[0]}. {last}",
//                    _ => null
//                };
//                if (name != null) { Console.WriteLine(name); }
//            }
//        }
//    }
//    public static class TaskExtension
//    {
//        public static void WaitWithPumping(this Task task)
//        {
//            if (task == null) throw new ArgumentNullException("task");
//            //var nestedFrame = new DispatcherFrame();
//            //task.ContinueWith(_ => nestedFrame.Continue = false);
//            //Dispatcher.PushFrame(nestedFrame);
//            task.Wait();
//        }
//    }
//    public enum Rainbow
//    {
//        Red,
//        Orange,
//        Yellow,
//        Green,
//        Blue,
//        Indigo,
//        Violet
//    }
//    //public static RGBColor FromRainbow(Rainbow colorBand) =>
//    //colorBand switch
//    //{
//    //    Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
//    //    Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
//    //    Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
//    //    Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
//    //    Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
//    //    Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
//    //    Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
//    //    _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
//    //};
//    public readonly ref struct WebConstants
//    {
//        public static int Id { get; set; } = 1;
//        public static string Name { get; set; } = "Dammy";
//        public static DateTime? CreationDate { get; set; } = DateTime.Now;
//        public void Dispose()
//        {

//        }
//    }
//    public class CL : IDisposable
//    {
//        public void Dispose()
//        {
//        }
//    }
//    public class SomeFreakingClass
//    {
//        public void M()
//        {
//            using var mp = new WebConstants();

//            using CL d = new CL();

//            Span<Coords<int>> coordinates = stackalloc[]
//{
//                new Coords<int> { X = 0, Y = 0 },
//                new Coords<int> { X = 0, Y = 3 },
//                new Coords<int> { X = 4, Y = 0 }
//            };

//            Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
//            var ind = numbers.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
//            Console.WriteLine(ind);  // output: 1
//        }
        
//    }
//    public struct Coords<T>
//    {
//        public T X;
//        public T Y;

//        public static double Calculate(double sLatitude, double sLongitude, double eLatitude, double eLongitude)
//        {
//            var radiansOverDegrees = (Math.PI / 180.0);

//            var sLatitudeRadians = sLatitude * radiansOverDegrees;
//            var sLongitudeRadians = sLongitude * radiansOverDegrees;
//            var eLatitudeRadians = eLatitude * radiansOverDegrees;
//            var eLongitudeRadians = eLongitude * radiansOverDegrees;

//            var dLongitude = eLongitudeRadians - sLongitudeRadians;
//            var dLatitude = eLatitudeRadians - sLatitudeRadians;

//            var result1 = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
//                          Math.Cos(sLatitudeRadians) * Math.Cos(eLatitudeRadians) *
//                          Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

//            // Using 3956 as the number of miles around the earth
//            //var result2 = 3956.0 * 2.0 * Math.Atan2(Math.Sqrt(result1), Math.Sqrt(1.0 - result1));

//            //in km 
//            var result2 = 6366.56486 * 2.0 * Math.Atan2(Math.Sqrt(result1), Math.Sqrt(1.0 - result1));
//            return result2;
//        }
//    }
//}
