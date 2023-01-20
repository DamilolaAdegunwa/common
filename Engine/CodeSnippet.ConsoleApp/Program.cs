using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp
{
    public class clsPerson
    {
        public string FirstName;
        public string MI;
        public string LastName;
    }
    public class Program
    {
        public static void MainOld()
        {
            clsPerson p = new clsPerson();
            p.FirstName = "Jeff";
            p.MI = "A";
            p.LastName = "Price";
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
            x.Serialize(Console.Out, p);
            Console.WriteLine();
            Console.ReadLine();
            //Console.WriteLine(CodeSnippet.ConsoleApp.DFB.TimeDataflowComputations(1000,10));
            //new CodeSnippet.ConsoleApp.DFB().NewMethod2();
        }
    }
}
