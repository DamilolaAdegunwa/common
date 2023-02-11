using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp
{
    public class TestStatic
    {
        internal int MyProperty { get; set; }
        static int MyProperty2 { get; set; }


    }
    //once a class is static, you cannot derive it, you cannot inherit it!
    public class testpublic : TestStatic
    {

    }
    public class ProgramConsole
    {
        public static void MainProgramConsole()
        {
            //new TestStatic().MyProperty;
        }
    }
}
