using System.IO;
using System.Net;
using System.Net.Mail;
using System;
using System.Text;
using Oracle.ManagedDataAccess.Types;
using Microsoft.VisualBasic;
//using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System.Windows.Forms;
//using DotNext.Buffers;
using System.Reflection;
using System.Threading;
using System.Collections;
using System.Security.Policy;
using System.Security;
using System.Security.Permissions;
using System.Linq;
using System.Collections.Generic;

namespace CodeSnippet.ConsoleApp
{
    public class Program22 : MarshalByRefObject
    {
        [SecurityPermission(SecurityAction.Demand, ControlDomainPolicy = true)]
        public static void Main2(string[] args)
        {

            IAsyncResult asyncResult;
            
            List<int> list = new List<int>();
            ArraySegment<int> ts = new ArraySegment<int>();
            
            //Console.WriteLine("Full name = " +
            //    AppDomain.CurrentDomain.ActivationContext.Identity.FullName);
            //Console.WriteLine("Code base = " +
            //    AppDomain.CurrentDomain.ActivationContext.Identity.CodeBase);
            //ApplicationSecurityInfo asi = new ApplicationSecurityInfo(AppDomain.CurrentDomain.ActivationContext);

            //Console.WriteLine("ApplicationId.Name property = " + asi.ApplicationId.Name);
            //if (asi.ApplicationId.Culture != null)
            //    Console.WriteLine("ApplicationId.Culture property = " + asi.ApplicationId.Culture.ToString());
            //Console.WriteLine("ApplicationId.ProcessorArchitecture property = " + asi.ApplicationId.ProcessorArchitecture);
            //Console.WriteLine("ApplicationId.Version property = " + asi.ApplicationId.Version);
            //// To display the value of the public key, enumerate the Byte array for the property.
            //Console.Write("ApplicationId.PublicKeyToken property = ");
            //byte[] pk = asi.ApplicationId.PublicKeyToken;
            //for (int i = 0; i < pk.GetLength(0); i++)
            //    Console.Write("{0:x}", pk[i]);

            Console.Read();
        }

        public void Run()
        {
            Main2(new string[] { });
            Console.ReadLine();
        }
    }
    public class EntryPage
    {

        #region main3
        // The following attribute indicates to the loader that assemblies
        // in the global assembly cache should be shared across multiple
        // application domains.
        [LoaderOptimizationAttribute(LoaderOptimization.MultiDomainHost)]
        public static void Main3()
        {
            // Show information for the default application domain.
            ShowDomainInfo();

            // Create a new application domain and display its information.
            AppDomain newDomain = AppDomain.CreateDomain("MyMultiDomain");
           // newDomain.DoCallBack(new CrossAppDomainDelegate(ShowDomainInfo));
        }

        // This method has the same signature as the CrossAppDomainDelegate,
        // so that it can be executed easily in the new application domain.
        //
        public static void ShowDomainInfo()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            Console.WriteLine();
            Console.WriteLine("FriendlyName: {0}", ad.FriendlyName);
            Console.WriteLine("Id: {0}", ad.Id);
            Console.WriteLine("IsDefaultAppDomain: {0}", ad.IsDefaultAppDomain());
        }
        #endregion
        public static void Main2()
        {
            // appdomain setup information
            AppDomain currentDomain = AppDomain.CurrentDomain;//✔

            //Create a new value pair for the appdomain
            currentDomain.SetData("ADVALUE", "Example value");//✔

            //get the value specified in the setdata method
            Console.WriteLine("ADVALUE is: " + currentDomain.GetData("ADVALUE"));

            //get a system value specified at appdomainsetup
            Console.WriteLine("System value for loader optimization: {0}", currentDomain.GetData("LOADER_OPTIMIZATION"));
            Console.WriteLine("System value for APPBASE: {0}", currentDomain.GetData("APPBASE"));
            Console.WriteLine("System value for APP_CONFIG_FILE: {0}", currentDomain.GetData("APP_CONFIG_FILE"));
            Console.WriteLine("System value for APP_LAUNCH_URL: {0}", currentDomain.GetData("APP_LAUNCH_URL"));
            Console.WriteLine("System value for APP_NAME: {0}", currentDomain.GetData("APP_NAME"));
            Console.WriteLine("System value for BINPATH_PROBE_ONLY: {0}", currentDomain.GetData("BINPATH_PROBE_ONLY"));
            Console.WriteLine("System value for CACHE_BASE: {0}", currentDomain.GetData("CACHE_BASE"));
            Console.WriteLine("System value for CODE_DOWNLOAD_DISABLED: {0}", currentDomain.GetData("CODE_DOWNLOAD_DISABLED"));
            Console.WriteLine("System value for DEV_PATH: {0}", currentDomain.GetData("DEV_PATH"));
            Console.WriteLine("System value for DISALLOW_APP: {0}", currentDomain.GetData("DISALLOW_APP"));
            Console.WriteLine("System value for DISALLOW_APP_BASE_PROBING: {0}", currentDomain.GetData("DISALLOW_APP_BASE_PROBING"));
            Console.WriteLine("System value for DISALLOW_APP_REDIRECTS: {0}", currentDomain.GetData("DISALLOW_APP_REDIRECTS"));
            Console.WriteLine("System value for DYNAMIC_BASE: {0}", currentDomain.GetData("DYNAMIC_BASE"));
            Console.WriteLine("System value for FORCE_CACHE_INSTALL: {0}", currentDomain.GetData("FORCE_CACHE_INSTALL"));
            Console.WriteLine("System value for LICENSE_FILE: {0}", currentDomain.GetData("LICENSE_FILE"));
            Console.WriteLine("System value for LOCATION_URI: {0}", currentDomain.GetData("LOCATION_URI"));
            Console.WriteLine("System value for PRIVATE_BINPATH: {0}", currentDomain.GetData("PRIVATE_BINPATH"));
            Console.WriteLine("System value for REGEX_DEFAULT_MATCH_TIMEOUT: {0}", currentDomain.GetData("REGEX_DEFAULT_MATCH_TIMEOUT"));
            Console.WriteLine("System value for SHADOW_COPY_DIRS: {0}", currentDomain.GetData("SHADOW_COPY_DIRS"));
            //AppDomain currentDomain = AppDomain.CurrentDomain;
            //AppDomain otherDomain = AppDomain.CreateDomain("otherDomain");

            //currentDomain.ExecuteAssembly("MyExecutable.exe");
            //// Prints "MyExecutable running on [default]"

            //otherDomain.ExecuteAssembly("MyExecutable.exe");
            // Prints "MyExecutable running on otherDomain"
            //AppDomain.Unload(AppDomain.CurrentDomain);
            //Console.WriteLine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            //Console.WriteLine(Assembly.GetEntryAssembly().FullName);
        }
    }
}