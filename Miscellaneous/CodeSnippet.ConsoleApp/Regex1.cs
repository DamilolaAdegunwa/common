using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
namespace CodeSnippet.ConsoleApp
{
    public class Program1
    {
        public static void MainProgram1(string[] args)
        {
            var rand = new Random(1234);
            var strings = new List<string>();
            //10K random strings
            for (var i = 0; i < 10000; i++)
            {
                //Generate random string
                var sb = new StringBuilder();
                for (var c = 0; c < 1000; c++)
                {
                    //Add a-z randomly
                    sb.Append((char)('a' + rand.Next(26)));
                }
                //In roughly 50% of them, put a digit
                if (rand.Next(2) == 0)
                {
                    //Replace one character with a digit, 0-9
                    sb[rand.Next(sb.Length)] = (char)('0' + rand.Next(10));
                }
                strings.Add(sb.ToString());
            }

            var baseTime = testPerfomance(strings, @"\d");
            Console.WriteLine();
            var testTime = testPerfomance(strings, "[0-9]");
            Console.WriteLine("  {0:P2} of first", testTime.TotalMilliseconds / baseTime.TotalMilliseconds);
            testTime = testPerfomance(strings, "[0123456789]");
            Console.WriteLine("  {0:P2} of first", testTime.TotalMilliseconds / baseTime.TotalMilliseconds);
        }
        private static TimeSpan testPerfomance(List<string> strings, string regex)
        {
            var sw = new Stopwatch();

            int successes = 0;

            var rex = new Regex(regex);

            sw.Start();
            foreach (var str in strings)
            {
                if (rex.Match(str).Success)
                {
                    successes++;
                }
            }
            sw.Stop();

            Console.Write("Regex {0,-12} took {1} result: {2}/{3}", regex, sw.Elapsed, successes, strings.Count);

            return sw.Elapsed;
        }
        void regexNumberCheck()
        {
            var sb = new StringBuilder();
            for (UInt16 i = 0; i < UInt16.MaxValue; i++)
            {
                string str = Convert.ToChar(i).ToString();
                if (Regex.IsMatch(str, @"\d"))
                    sb.Append(str);
            }
            Console.WriteLine(sb.ToString());
        }
        public static void AnotherNumberCheck()
        {
            var unicodeEncoding = new UnicodeEncoding(!BitConverter.IsLittleEndian, false);
            Console.InputEncoding = unicodeEncoding;
            Console.OutputEncoding = unicodeEncoding;

            var sb = new StringBuilder();
            for (var codePoint = 0; codePoint <= 1; codePoint++)//0x10ffff
            {
                var isSurrogateCodePoint = codePoint <= UInt16.MaxValue
                       && (char.IsLowSurrogate((char)codePoint)
                          || char.IsHighSurrogate((char)codePoint)
                          );

                if (isSurrogateCodePoint)
                    continue;

                var codePointString = char.ConvertFromUtf32(codePoint);

                foreach (var category in new[]{
                UnicodeCategory.DecimalDigitNumber,
                UnicodeCategory.LetterNumber,
                UnicodeCategory.OtherNumber})
                {
                    sb.AppendLine($"{category}");
                    //Program2.CharInfo[] charInfo = default;
                    //int cat = (int)category;
                    //foreach (var ch in charInfo[cat])//charInfo[category]
                    //{
                    //    sb.Append(ch);
                    //}

                    StringBuilder stringBuilder = new StringBuilder();
                    DateTime? date = default;
                    date.GetValueOrDefault();
                    for (var i = 0; i < 100; i++)
                    {
                        if(CharUnicodeInfo.GetUnicodeCategory(i) == category)
                        {
                            stringBuilder.Append(i);
                        }
                    }
                    Console.WriteLine(stringBuilder);
                    sb.AppendLine();
                }
            }
            Console.WriteLine(sb.ToString());

            Console.ReadKey();
        }
    }
}