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
            var s = new EntryPage() + 10;
            Console.WriteLine(s);
            Console.ReadLine();
        }
        public static int  operator +(EntryPage a, int b)
        {
            Console.WriteLine("hello world!");
            return 4;
        }

        public static int Add(EntryPage left, EntryPage right)
        {
            throw new NotImplementedException();
        }
    }
}