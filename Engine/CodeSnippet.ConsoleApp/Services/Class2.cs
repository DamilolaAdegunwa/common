using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSnippet.ConsoleApp
{
    public enum cloth
    {
        shirt, trouser, boxers, sweaters, hoodie,
    }
    public class Class2
    {
        public static void MainClass2()
        {
            var suits = Enum.GetValues(typeof(cloth)).Cast<cloth>();
            List<int> vs = new List<int>() {1,2,3,4,5 };
            var x = vs.OfType<long>().ToList();
            foreach(var y in x)
            {
                Console.WriteLine(y);
            }
            Console.ReadLine();
            foreach (var cloth in (cloth[])Enum.GetValues(typeof(cloth)))
            {
                Console.WriteLine(cloth);
            }
            foreach (var cloth in Enum.GetNames(typeof(cloth)))
            {
                Console.WriteLine(cloth);
            }
            foreach(cloth cloth in Enum.GetValues(typeof(cloth)).OfType<cloth>().ToArray())
            {
                Console.WriteLine(cloth);
            }
            Console.ReadLine();
        }
    }
}
