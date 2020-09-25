namespace CodeSnippet.ConsoleApp
{
    using System;
    using System.Reactive;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Reactive.Linq;
    using System.Text;
    using System.Reactive.Concurrency;
    using System.Reflection;
    public class EntryPage
    {
        public static void Main(string[] args)
        {
            //new CSharpGuide.DelegateSecondTest().Test();
            //new UseLoggerContoller(new ConsoleLogger()).Index();
            //new UseLoggerService().Log("you all need to see this", Logger.WriteMessage);
            //new UseLoggerService().Log(Severity.Critical, "EntryPage", "You all need to see this!", new Logger().LogMessage);
            //new UseLoggerService().Log(Severity.Critical, "EntryPage", "You all need to see this!", new Logger().LogMessage);
            new LinqTest();
            Console.ReadLine();
        }
        
    }
}