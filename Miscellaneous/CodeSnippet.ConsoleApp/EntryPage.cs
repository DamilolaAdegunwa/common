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
    public class EntryPage
    {
        public static void Main(string[] args)
        {
            new CSharpGuide.DelegateSecondTest().Test();
            Console.ReadLine();
        }
        
    }
}