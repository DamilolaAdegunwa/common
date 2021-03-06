﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using Oracle.ManagedDataAccess.Types;
using System.IO;
using System.Net;
using System.Net.Mail;
using System;
using System.Text;
namespace CodeSnippet.ConsoleApp
{
    public class Emailtest
    {
        public static void MainEmail2()
        {
            Email2("string htmlString");
        }
        public static void Email1()
        {
            string to = "dammy.adegunwa@gmail.com"; //To address    
            string from = "damee1993@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("damee1993@gmail.com", "Damilola@123");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Email2(string htmlString)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("damee1993@gmail.com");
                message.To.Add(new MailAddress("dammy.adegunwa@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 465;//587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("damee1993@gmail.com", "Damilola@123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) { }
        }
    }
    public class Class7
    {
        public static void MainEEE()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            var thirdItem = array[2];    // array[2]
            var lastItem = array[^1];    // array[new Index(1, fromEnd: true)]
            var lastItem2 = array[..^1];    // array[new Index(1, fromEnd: true)]
            var vss = array[0^4];
            //System.Range;
            int[] vs = new int[] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            var v = vs[..^0];
            var v2 = vs[0..6].Concat(vs[4..6]).Concat(vs[4..6]).Concat(vs[4..6]).Concat(vs[4..6]).Concat(vs[4..6]).Concat(vs[4..6]);
            var v3 = vs[0..5];
            var v4 = vs[..5];
        }
    }
    struct Tester
    {
        public Tester(string data)
        {
            Console.WriteLine("from the struct!!");
        }
    }
    public class GetBillersResponse
    {

        public string auditId { get; set; }
        public bool status { get; }
        public int errorCode { get; set; }
        public string message { get; set; }
    }
    public class Person
    {
        [Required]
        public long Id { get; set; }
        [Range(0, 200, ErrorMessage = "Please enter valid integer Number")]
        public int Age { get; set; }
        [DataType(DataType.Text)]
        [StringLength(2000, ErrorMessage = "Max 2 digits")]
        public string profilePicturePath { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(1000, ErrorMessage = "not more than 1000 characters are allowed")]
        [MinLength(2, ErrorMessage = "not more than 2 characters are allowed")]
        public string Email { get; set; }
        [Required]
        public int MyProperty { get; set; }
    }
    public class EntryPageqqq
    {
        public static bool/*Dictionary<string, string>*/ GetDisplayNameList<T>(string pName)
        {
            var info = TypeDescriptor.GetProperties(typeof(T))
                .Cast<PropertyDescriptor>()
                .Where(p => p.Attributes.Cast<Attribute>().Any(a => a.GetType() == typeof(RequiredAttribute)))
                .ToDictionary(p => p.Name, p => p.DisplayName);
            bool isRequired = info.Where(kv => kv.Key == pName).FirstOrDefault().Key != null;
            //return info;
            return isRequired;
        }
        public static void MainDictionary(string[] args)
        {
            var x = (OracleDate)(DateTime.MinValue);
            DateTime? dateTime = null;
            var y = (OracleDate)(null);
            var z = (OracleDate)("06/07/2021 05:30:33 AM");

            PropertyInfo[] ps = typeof(GetBillersResponse).GetProperties();
            GetBillersResponse gbr = new GetBillersResponse();
            gbr.auditId = "111222"; gbr.errorCode = 369; gbr.message = "I have figured it out!"; //gbr.status = true;
            foreach (var p in ps)
            {
                //var def = p.GetValue(new GetBillersResponse()) == null;
                //p.SetValue(gbr, null);
                //var x = p.Attributes.
                var pName = p.Name;
                var PropertyTypeName = p.PropertyType.Name;
                var GetValue = p.GetValue(gbr);
                var CanWrite = p.CanWrite.ToString();
                var CanRead = p.CanRead.ToString();
                //var GetTypeName = p.GetType().Name;
                bool isNullable = p.GetValue(new GetBillersResponse()) == null;//false;//System.Nullable.GetUnderlyingType(p.PropertyType) != null;
                                                                               //if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                                                               //{
                                                                               //    // If it is NULLABLE, then get the underlying type. eg if "Nullable<int>" then this will return just "int"
                                                                               //    //columnType = p.PropertyType.GetGenericArguments()[0];
                                                                               //    isNullable = true;
                                                                               //}
                Console.WriteLine($"property name::{pName}  property type::{PropertyTypeName} the value of the prop::{GetValue}  can read?::{CanRead}  can write?::{CanWrite}  nullable {isNullable}");
                Console.WriteLine("\n\n\n");
            }
            //var pdx = TypeDescriptor.GetProperties(typeof(Person))
            //    .Cast<PropertyDescriptor>();

            //var d = "done";
            //var ddd = typeof(DataTypeAttribute);
            //PropertyInfo[] prs = typeof(Person).GetProperties();
            //Person person = new Person();
            //foreach (var p in prs)
            //{
            //    var pd = TypeDescriptor.GetProperties(typeof(Person))
            //    .Cast<PropertyDescriptor>().Where(property => property.Name == p.Name).FirstOrDefault().Attributes.GetEnumerator();
            //    while(pd.MoveNext())
            //    {
            //        if(pd.Current.GetType() == typeof(DataTypeAttribute))
            //        {
            //            //return ((DataTypeAttribute)pd.Current).DataType;
            //            //if(((DataTypeAttribute)pd.Current).DataType.ToString() == DataType.Text.ToString())
            //            //{

            //            //}
            //        }
            //    }
            //    var hasRequired = GetDisplayNameList<Person>(p.Name);
            //    if (hasRequired)
            //    {
            //        Console.WriteLine($"{p.Name} is required!");
            //    }

            //}
            //var pe = GetDisplayNameList<Person>();
            //foreach(var kv in pe)
            //{
            //    Console.WriteLine(kv.Key + " :: " +kv.Value);
            //}
            //MemberInfo memberInfo = typeof(Person);
            //object[] attributes = memberInfo.GetCustomAttributes(true);

            //foreach (object attribute in attributes)
            //{
            //    CustomAttribute customAttribute = attribute as CustomAttribute;

            //    if (customAttribute != null)
            //        Console.WriteLine("Text = {0}", customAttribute.Text);
            //    else
            //        Console.WriteLine();
            //}
            //////////////////////////////////////////////////////

            if (false)
            {
                //PropertyInfo[] ps = typeof(GetBillersResponse).GetProperties();
                //GetBillersResponse gbr = new GetBillersResponse();
                //gbr.auditId = "111222"; gbr.errorCode = 369; gbr.message = "I have figured it out!"; //gbr.status = true;
                foreach (var p in ps)
                {
                    //var def = p.GetValue(new GetBillersResponse()) == null;
                    //p.SetValue(gbr, null);
                    //var x = p.Attributes.
                    var pName = p.Name;
                    var PropertyTypeName = p.PropertyType.Name;
                    var GetValue = p.GetValue(gbr);
                    var CanWrite = p.CanWrite.ToString();
                    var CanRead = p.CanRead.ToString();
                    //var GetTypeName = p.GetType().Name;
                    bool isNullable = p.GetValue(new GetBillersResponse()) == null;//false;//System.Nullable.GetUnderlyingType(p.PropertyType) != null;
                                                                                   //if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                                                                   //{
                                                                                   //    // If it is NULLABLE, then get the underlying type. eg if "Nullable<int>" then this will return just "int"
                                                                                   //    //columnType = p.PropertyType.GetGenericArguments()[0];
                                                                                   //    isNullable = true;
                                                                                   //}
                    Console.WriteLine($"property name::{pName}  property type::{PropertyTypeName} the value of the prop::{GetValue}  can read?::{CanRead}  can write?::{CanWrite}  nullable {isNullable}");
                    Console.WriteLine("\n\n\n");
                }
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
        public static int operator +(EntryPageqqq a, int b)
        {
            Console.WriteLine("hello world!");
            return 4;
        }
        #endregion
    }
}
