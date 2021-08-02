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
using System.Threading.Tasks;
namespace CodeSnippet.ConsoleApp
{
    public class arrayManipulation
    {
        public static void MainarrayManipulation()
        {
            //int[,] queries = new int[200000, 3];
            //var n = 10_000_000;
            //for(var i = 0; i < 200000; i++)
            //{

            //    for(var j = 0; j < 3; j++)
            //    {
            //        if(j == 0)
            //        {
            //            queries[i, j] = n;
            //        }
            //        else if(j == 1)
            //        {
            //            queries[i, j] = n;
            //        }
            //        else if(j == 2)
            //        {
            //            queries[i, j] = 1_000_000_000;
            //        }
            //    }
            //}

            int[][] queries = new int[200000][];
            var n = 10_000_000;
            for (var i = 0; i < 200000; i++)
            {
                queries[i] = new int[3] { 1, n, 1_000_000_000 };
                
            }
            ArrayManipulation(n, queries);

            var x = "done";
            while(true)
            {

            }
        }
        static async Task<long> ArrayManipulation(int n, int[][] queries)
        {
            long[] am = new long[n + 1];
            List<Task> tasks = new List<Task>();
            foreach (var row in queries)
            {
                var task = Task.Run(() => {
                    for (var i = row[0]; i <= row[1]; i++)
                    {
                        am[i] += row[2];
                    }
                });
                tasks.Add(task);
            }
            var t = Task.WhenAll(tasks);
            await t;
            if(t.Status == TaskStatus.RanToCompletion)
            {
                var result = am.Max();
                Console.WriteLine(result);
                return result;
            }
            else
            {
                throw new Exception("bad stuff!");
            }
            
        }
    }
}
