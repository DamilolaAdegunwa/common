using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp.DesignPatterns.SingletonPatterns
{
    public class MyDatabaseContext
    {
        private static MyDatabaseContext _instance = new MyDatabaseContext();

        public static MyDatabaseContext GetInstance()
        {
            return _instance;
        }
        public bool IsRunning()
        {
            return true;
        }
    }
}
