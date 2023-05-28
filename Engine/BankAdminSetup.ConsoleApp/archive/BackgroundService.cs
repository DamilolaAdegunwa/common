using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.Extensions.Primitives;

namespace CodeSnippet.ConsoleApp.Services
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BackgroundTaskAttribute : Attribute
    {
        public BackgroundTaskAttribute()
        {
            Console.WriteLine("The Background Task Attribute Was Called!!");
        }
        public bool Enable { get; set; } = true;
        public string Schedule { get; set; } = "*/5 * * * *";
        public string Description { get; set; } = String.Empty;
    }
    public interface IBackgroundTask
    {
        Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken);
    }

    [BackgroundTask(Schedule = "* * * * *", Description = "Just some simple test on how stuff works")]
    public class SomeBackgroundTask : IBackgroundTask
    {
        private readonly ILogger<SomeBackgroundTask> _logger;
        public SomeBackgroundTask(ILogger<SomeBackgroundTask> logger)
        {
            _logger = logger;
        }
        public SomeBackgroundTask()
        {
            _logger = new Logger<SomeBackgroundTask>(new LoggerFactory());
        }
        public string GiveDesc()
        {
            _logger.LogDebug("try out logs");
            Console.WriteLine(this.GiveDescription());
            return this.GiveDescription();
        }
        public string GiveMyDescription()
        {
            //var type = new SomeBackgroundTask().GetType();
            _logger.LogDebug("try out logs");
            var type = this.GetType();
            var bgt = type.GetCustomAttribute<BackgroundTaskAttribute>();
            if (bgt == null) { return null; }
            Console.WriteLine($"{type.FullName} {bgt.Description}");
            return bgt.Description;
        }
        public Task DoWorkAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogDebug("Trying my hands on logging & background task!");

                var injectedService = serviceProvider.GetService<SomeUsefulService>();

                var x = Task.FromResult(injectedService.SomeMethod());

                var y = Task.FromResult(injectedService.SomeIterativeMethod().GetAsyncEnumerator(cancellationToken));
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
                var xx = cts.Token;
                IChangeToken cancellationChangeToken = new CancellationChangeToken(cancellationToken);
                var z = Task<int>.Factory.StartNew(() => injectedService.SomeMethod(), cancellationToken);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "some error occured!!");
                return null;
                //throw;
            }
            //throw new NotImplementedException();
        }
    }

    public class SomeUsefulService
    {
        public int SomeMethod()
        {
            return default;
        }
        public async IAsyncEnumerable<int> SomeIterativeMethod()
        {
            yield return default;
        }
        public SomeUsefulClass ReturnThis(SomeUsefulInterface model)
        {
            var type = "".GetType();
            var someProperty = type.GetCustomAttribute<BackgroundTaskAttribute>();
            if (someProperty != null)
            {
                return new SomeUsefulClass
                {
                    MyProperty10 = someProperty.Enable.ToString().Length
                };
            }
            return default;
        }
    }
    public interface SomeUsefulInterface
    {
        public int MyProperty1 { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
        public int MyProperty4 { get; set; }
        public int MyProperty5 { get; set; }
    }

    public class SomeUsefulClass
    {
        public int MyProperty6 { get; set; }
        public int MyProperty7 { get; set; }
        public int MyProperty8 { get; set; }
        public int MyProperty9 { get; set; }
        public int MyProperty10 { get; set; }
    }
    public static class SomeBackgroundTaskExtension
    {
        public static string GiveDescription(this IBackgroundTask background)
        {
            var type = background.GetType();
            var bgt = type.GetCustomAttribute<BackgroundTaskAttribute>();
            if (bgt == null) { return null; }
            return bgt.Description;
        }
    }
}