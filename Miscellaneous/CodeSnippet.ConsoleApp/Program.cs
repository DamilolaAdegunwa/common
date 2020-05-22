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
//using Microsoft.Extensions.Http.Polly;
using Polly;
using Polly.Extensions.Http;
using Microsoft.Extensions.Http;
using System.Device.Location;
using System.Collections.Specialized;
using static System.Text.StringBuilder;

namespace CodeSnippet.ConsoleApp
{
    public sealed class Program
    {
        public static void Main()
        {
            NameValueCollection v;
            //KeyValueMapping
            ChunkEnumerator ce = default;
            //Microsoft.
            foreach(var s in "1234567890")
            {
                Console.WriteLine("this would show!");
                continue;
                Console.WriteLine("this would not show!");
            }
            //new GeoCoordinate();
            //the distance between okota & aba
            //Console.WriteLine(Calculate(6.5088, 3.3137, 5.1216, 7.3733));

            //distance between lagos and abuja is (698.7 km) (distance)
            //Console.WriteLine(Calculate(6.5236, 3.6006, 9.0765, 7.3986)); //505.23466046853935 (displacement)

            //the distance between lagos and kaduna is (770.4 km) (distance)
            //Console.WriteLine(Calculate(6.5236, 3.6006, 10.3764 , 7.7095));//622.2162062356526 (displacement)

            //okota and mile 2 (9.8 km), 8, 7.8, 6 (distance)
            //Console.WriteLine(Calculate(6.4659, 3.3198, 6.5088, 3.3137));//4.839564161881872 | 4.8142811141800745 (displacement)

            //Console.WriteLine(new List<string>().FirstOrDefault().Length);

            Console.WriteLine("done");
            Console.ReadLine();
        }
        public static double Calculate(double sLatitude, double sLongitude, double eLatitude, double eLongitude)
        {
            var radiansOverDegrees = (Math.PI / 180.0);

            var sLatitudeRadians = sLatitude * radiansOverDegrees;
            var sLongitudeRadians = sLongitude * radiansOverDegrees;
            var eLatitudeRadians = eLatitude * radiansOverDegrees;
            var eLongitudeRadians = eLongitude * radiansOverDegrees;

            var dLongitude = eLongitudeRadians - sLongitudeRadians;
            var dLatitude = eLatitudeRadians - sLatitudeRadians;

            var result1 = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                          Math.Cos(sLatitudeRadians) * Math.Cos(eLatitudeRadians) *
                          Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Using 3956 as the number of miles around the earth
            //var result2 = 3956.0 * 2.0 * Math.Atan2(Math.Sqrt(result1), Math.Sqrt(1.0 - result1));

            //in km 
            var result2 = 6366.56486 * 2.0 * Math.Atan2(Math.Sqrt(result1), Math.Sqrt(1.0 - result1));
            return result2;
        }

    }

}