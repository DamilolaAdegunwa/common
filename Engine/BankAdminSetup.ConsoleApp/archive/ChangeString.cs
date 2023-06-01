using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp.Services
{
    public class ChangeString
    {
        public static void Main_ChangeString()
        {
            var token = "fcYwklxegH";
            var b64str = Base64Encode($"appzoneswitch:{token}");
            var authorization = $"basic {b64str}";
            Console.WriteLine(authorization);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
