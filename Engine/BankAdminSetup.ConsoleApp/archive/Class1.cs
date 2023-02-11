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
using System.Threading;
using System.Threading.Tasks;
class Solution
{
    

    // Complete the minimumSwaps function below.
    static int minimumSwaps(int[] arr)
    {
        var arrlist = arr.ToList();
        var n = arrlist.Count;
        //var i = 0;
        var temp = 0;
        var index = 0;
        var swap = 0;
        Parallel.For(0, arrlist.Count, i => {
            if (arrlist[i] != i + 1)
            {
                //find the index of i+1
                index = arrlist.IndexOf(i + 1);
                temp = arrlist[i];
                arrlist[i] = i + 1;
                arrlist[index] = temp;
                swap++;
            }
        });
        return swap;
    }
    public static string ConstructCorpCode(string str)
    {
        var splitedStr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var joinedStr = string.Join("", splitedStr);
        var strlen = joinedStr.Length;
        if (strlen <= 6)
        {
            return joinedStr;
        }
        else
        {
            var incremetor = Math.Floor((decimal)(strlen / 6));
            var newStr = "";
            for (var i = 0; i < 6; i++)
            {
                newStr += joinedStr[Convert.ToInt32(incremetor) * i];
            }
            return newStr;
        }
    }
    static void OldMain(string[] args)
    {
        var x1 = ConstructCorpCode("SAUDAHNG");
        var x2 = ConstructCorpCode("SAUDADAM");

        Console.WriteLine($"{x1} :: {x2}");
        Console.ReadLine();
        //int[] vs = new int[7] {7,5,6,4,3,2,1 };
        //var x = minimumSwaps(vs);
        //var y = "";
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //int n = Convert.ToInt32(Console.ReadLine());

        //int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        //;
        //int res = minimumSwaps(arr);

        //textWriter.WriteLine(res);

        //textWriter.Flush();
        //textWriter.Close();
        //async void Method1()
        //{
        //    while (true)
        //    {

        //    }
        //}
        //Task.Run(() => {
        //    while (true)
        //    {

        //    }
        //});
        //Console.WriteLine("This  will print");
        //Method1();
        //Console.WriteLine("This won't");

    }


    //public async void Method1()
    //{ 
    //    while(true)
    //    {

    //    }
    //}
}



public class SomeClass
{
    
}

