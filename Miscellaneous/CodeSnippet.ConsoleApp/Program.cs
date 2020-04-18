using CodeSnippet.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.IO;
using System.Web;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace CodeSnippet.ConsoleApp
{
    public sealed class Program
    {
        public static void Main()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            //C:\Users\DamilolaAdegunwa\source\repos\common\Miscellaneous\CodeSnippet.ConsoleApp\bin\Debug\netcoreapp3.1\
            var enviroment = Environment.CurrentDirectory;
            //C:\Users\DamilolaAdegunwa\source\repos\common\Miscellaneous\CodeSnippet.ConsoleApp\bin\Debug\netcoreapp3.1
            string currentDirectory = Directory.GetCurrentDirectory();
            //C:\Users\DamilolaAdegunwa\source\repos\common\Miscellaneous\CodeSnippet.ConsoleApp\bin\Debug\netcoreapp3.1
            string projectDirectory = Directory.GetParent(enviroment).Parent.Parent.FullName;

            var processes = Process.GetProcesses();
            var processesCount = processes.Count();
            var processNumber = 0;
            foreach (var p in processes)
            {
                var processName = p.ProcessName;
                var threadsInProcess = p.Threads.Count;
                Console.WriteLine($"Process {++processNumber}: {processName} having {threadsInProcess} thread(s)\n");
                for (var t = 0; t < threadsInProcess; ++t)
                {
                    var eachThread = p.Threads[t];
                    //Console.WriteLine();
                }
            }
        }
        
    }
    public static class myExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NoWarning(this Task task) { }
    }
}
