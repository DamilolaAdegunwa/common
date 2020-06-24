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
using System.Runtime.Loader;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Timers;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.FileProviders;
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.Http;
using System.Collections.Specialized;
using static System.Text.StringBuilder;
using System.Threading.Channels;
namespace CodeSnippet.ConsoleApp
{
    public sealed class Program
    {
        public enum AccountType
        {
            Android = 0, IOS = 1, Web = 2, Mobile = Android | IOS
        }
        public static void Main()
        {
            //void x = ;
            AccountType accountType1 = AccountType.Android;
            AccountType accountType2 = AccountType.IOS;

            if(accountType1 == AccountType.Mobile || accountType2 == AccountType.Mobile)
            {
                Console.WriteLine("both accounts are mobile!!");
            }else
            {
                Console.WriteLine("they are not!!");
            }
            //unsafe
            //{
            //    int a = 10;
            //    int b = 20;
            //    int c = 30;

            //    int* ptra = &a;
            //    int* ptrb = &b;
            //    int* ptrc = &c;


            //    Console.WriteLine((int)ptra);
            //    Console.WriteLine(*ptra);

                
            //}

            ////string ptr = Convert.ToInt32(&x);
            //byte[] byt = new byte[] { };
            //BitConverter.ToInt32(byt);
            //BinaryReader binaryReader = default;



            Console.WriteLine("done!");
            Console.ReadLine();
        }
        

    }

}