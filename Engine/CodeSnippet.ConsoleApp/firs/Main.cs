using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
namespace CodeSnippet.ConsoleApp.firs
{
    public class MainFIRS
    {
        public static void MaMethodinFIRS()
        {
            //var date = DateTimeOffset.Now;
            //var epoch2 = date.ToUnixTimeSeconds();//client ref
            //HMACSHA256 hmac = new HMACSHA256(Encoding.ASCII.GetBytes("Access"));//salt

            //String calc_sig = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes($"Access|{epoch2}")));//HMAC_256 (SIG_FIELDS, CLIENT_SECRET)
            ////Base64 (HMAC_256 (SIG_FIELDS, CLIENT_SECRET) +'.' + Base64 (CLIENT_SECRET ') )
            ////var calc_sig_secret = Base64Encode($"{calc_sig}.{Base64Encode($"Access")}");
            //var calc_sig_secret = $"{Base64Encode( calc_sig)}.{Base64Encode("Access")}";
            //var b64cs = Convert.ToBase64String("Access");
            //Convert.ToBase64String($"{calc_sig}.");

            //d2d1R1krTkx6U2RoVS9DS2ZGalJmejFNbE5ybUtwNlpBWVhVY2RPSktWTT0uUVdOalpYTno=
            //step 1
            var CLIENT_ID = "Access"; var CLIENT_SECRET = "Access"; var CLIENT_REFERENCE = DateTimeOffset.Now.ToUnixTimeSeconds();
            var SIG_FIELDS = $"{CLIENT_ID}+{CLIENT_REFERENCE}";

            HMACSHA256 secret_key = new HMACSHA256(Encoding.ASCII.GetBytes(CLIENT_SECRET));
            String hash = Convert.ToBase64String(secret_key.ComputeHash(Encoding.ASCII.GetBytes($"{SIG_FIELDS}"))); //HMAC_256 (SIG_FIELDS, CLIENT_SECRET)
            var concat_str = $"{hash}.{Base64Encode(CLIENT_SECRET)}";
            var token = Base64Encode(concat_str);
        }

        //encode
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //Decode
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
