using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.ConsoleApp
{
    public class CSharpGuide
    {
        #region learning about delegates
        public delegate void Simple<T>(T s);
        public class DelegateTest<T>
        {
            public static Simple<string> SimpleStringConsoleDisplay { get; set; }
            public void DelegateTestMethod()
            {
                SimpleStringConsoleDisplay = new Simple<string>(TakeString);
                SimpleStringConsoleDisplay = TakeString;
                SimpleStringConsoleDisplay("boss");
                SimpleStringConsoleDisplay.Invoke("boss");
            }
            public void TakeString(string s)
            {

            }
        }
        //////////////////////////////2
        public delegate string SingleAnswer(int t, int u);
        public class DelegateSecondTest
        {
            public static SingleAnswer Mathematics { get; set; }
            public void Test()
            {
                Mathematics += AddInts;
                Mathematics += AddInts;
                Mathematics += AddInts;
                Mathematics += AddInts;

                string m = Mathematics(10, 20);
            }
            public string AddInts(int a, int b)
            {
                Console.WriteLine(a + b);
                return (a + b).ToString();
            }
        }

        #endregion
    }
}
