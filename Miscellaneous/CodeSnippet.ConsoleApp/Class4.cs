using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.ConsoleApp
{
    public class Class4
    {
        public static void MainDamn()
        {
            new LocalFunctionClass().Method1();
            Console.WriteLine("done!");
            Console.ReadLine();
            var version1 = "1.2.4.5.8";
            var version2 = "1.2.4.5";

            var version1Arr = version1.Split(".");
            var version2Arr = version2.Split(".");

            var len = version1Arr.Length < version2Arr.Length ? version1Arr.Length : version2Arr.Length;
            for(var i = 0; i < len; i++)
            {
                var v1Val = Convert.ToInt32(version1Arr[i]);
                var v2Val = Convert.ToInt32(version2Arr[i]);
                if (v1Val == v2Val)
                {
                    continue;
                }
                else if(v2Val > v1Val)
                {
                    Console.WriteLine("get a new one");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
    public class LocalFunctionClass
    {
        public void Method1()
        {
            void LMethod1()
            {
                Console.WriteLine("Save Me!!");
            }
            LMethod1();
            LMethod1();
            LMethod1();
        }
    }
}
