using System;
using System.Text;

namespace EncodeToken
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(EncodeNetSuiteToken("appzoneswitch", "f9dT2102oc"));
        }
        public static string EncodeNetSuiteToken(string opco, string token)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{opco}:{token}"));
        }
    }
}
