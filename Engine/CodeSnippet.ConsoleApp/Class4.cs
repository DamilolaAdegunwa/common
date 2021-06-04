using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp
{
    public class csharp9
    {
        public class Person
        {
            public string Name { get; set; }
        }
        public static bool IsValid([NotNullWhen(true)] Person? person)
    => person is not null && person.Name is not null;
        public int GoodEnough([NotNullWhen(false)] string x)
        {
            return 5;
        }
    }
    public class Class4
    {
        public static void MainCsharp9()
        {
            var e = new csharp9().GoodEnough(null);
            Console.WriteLine(e);
        }
    }
}
