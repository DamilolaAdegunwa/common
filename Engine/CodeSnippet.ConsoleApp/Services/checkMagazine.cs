using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace CodeSnippet.ConsoleApp
{
    public class checkMagazine
    {
        public static void MaincheckMagazine()
        {
            //case 1
            string[] m1 = "give me one grand today night".Split(' ');
            string[] n1 = "give one grand today".Split(' ');
            //answer : Yes
            CheckMagazine(m1, n1);

            //case 2
            string[] m2 = "two times three is not four".Split(' ');
            string[] n2 = "two times two is four".Split(' ');
            //answer : No
            CheckMagazine(m2, n2);

            //case 3
            string[] m3 = "ive got a lovely bunch of coconuts".Split(' ');
            string[] n3 = "ive got some coconuts".Split(' ');
            //answer : No
            CheckMagazine(m3, n3);
        }
        static void CheckMagazine(string[] magazine, string[] note)
        {
            int index = -1;
            List<string> mlist = magazine.ToList();
            foreach (var w in note)
            {
                if (mlist.Contains(w))
                {
                    index = mlist.IndexOf(w);
                    mlist.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
        static string isValid(string s)
        {
            var sarr = s.ToList();
            var ds = s.Distinct().ToList();
            int i = 0;
            while (sarr.Count != 0 && sarr.Count != 1)
            {
                foreach (var x in ds)
                {
                    i = sarr.IndexOf(x);
                    sarr.RemoveAt(i);
                }
                if (sarr.Count > 1 && sarr.Count < ds.Count())
                {
                    return "NO";
                }
            }
            return "YES";
        }
    }
}
