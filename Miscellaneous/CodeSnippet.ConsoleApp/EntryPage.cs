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
    //using System.Dynamic.Runtime;
    using Microsoft.CSharp;
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Configuration;
    using System.Collections.Specialized;
    using Microsoft.Extensions.Configuration;
    //using Microsoft.NETCore.Runtime.CoreCLR;
    using TextCopy;
    struct Tester
    {
        public Tester(string data)
        {
            Console.WriteLine("from the struct!!");
        }
    }
    public class EntryPage
    {
        public static void MainEntryPage(string[] args)
        {
            if (false)
            {
                //TestEnum.MainTest();
                //Program1.AnotherNumberCheck();
                //string hex = "0x00ff00";
                //var ans = Enumerable.Range(0, hex.Length).Where(x => x % 2 == 0 && x != 0);
                //var sel = ans.Select(x => Convert.ToByte(hex.Substring(x,2), 16)).ToArray();
                //foreach(var a in sel)
                //{
                //    Console.WriteLine(a);
                //}
                #region a test snippet
                foreach (string s in ConfigurationManager.AppSettings.AllKeys)
                {
                    Console.WriteLine(s);
                    System.Diagnostics.Debug.WriteLine(s);
                }
                //Outputs 7 as expected
                Console.WriteLine(ConfigurationManager.AppSettings.AllKeys.Length);
                #endregion

                // In your global setup:
                string configFile = $"{Assembly.GetExecutingAssembly().Location}.config";
                    string outputConfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
                    File.Copy(configFile, outputConfigFile, true);
                string outputConfigFile2 = Path.Combine(Path.GetDirectoryName(configFile), $"{Path.GetFileName(Assembly.GetEntryAssembly().Location)}.config");
                var appSettingValFromStatic = ConfigurationManager.AppSettings["mySetting"];
                var appSettingValFromInstance = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).AppSettings.Settings["mySetting"].Value;
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettingValFromStatic2 = ConfigurationManager.AppSettings["mySetting"];
                var appSettingValFromInstance2 = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).AppSettings.Settings["mySetting"].Value;

                var valFromStatic = ((NameValueCollection)ConfigurationManager.GetSection("customNameValueSectionHandlerSection"))["customKey"];
                var valFromInstance = ((AppSettingsSection)ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).GetSection("customAppSettingsSection")).Settings["customKey"].Value;

                string path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;


                //var s = new EntryPage() + 10;
                //Console.WriteLine(s);
                //dynamic greet = "Hello World!";
            }
            Console.ReadLine();
        }
        void TestQuery()
        {
            IQueryable<string> sarr = default;//new[] { "Reflector", "John", "Paul" };
            IQueryable<string> query = from p in sarr
                                       where p == "Reflector"
                                       select p;

            IEnumerable<bool> q = query.Select(c => c.EndsWith("Reflector "));
            Console.WriteLine("LINQ to Entities returns: " + q.First());
            Console.WriteLine("CLR returns: " + "Reflector".EndsWith("Reflector "));
        }
        #region overloading an operator
        public static int  operator +(EntryPage a, int b)
        {
            Console.WriteLine("hello world!");
            return 4;
        }
        #endregion
    }
    
}