using System;
using System.Collections.Generic;
using System.Text;
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
using System.Net.Http;
using Newtonsoft.Json;

public class ResultFairMoney
{

    /*
     * Complete the 'fizzBuzz' function below.
     *
     * The function accepts INTEGER n as parameter.
     */
    public static string breakPalindrome(string palindromeStr)
    {
        var result = "IMPOSSIBLE";
        palindromeStr = palindromeStr.ToLower();
        char[] pArr = palindromeStr.ToArray();
        for (var i = 0; i < pArr.Length; i++)
        {
            if (pArr[i].ToString() != "a")
            {
                pArr[i] = 'a';
                var res = "";
                foreach (var p in pArr)
                {
                    res += p;
                }
                return res;
            }
        }
        return result;
    }
    public static void fizzBuzz(int n)
    {
        if (n <= 0 || n >= (2 * 100000))
        {
            return;
        }
        for (var i = 1; i <= n; i++)
        {
            if (i % 15 == 0)
            {
                Console.WriteLine("FizzBuzz");
                continue;
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
                continue;
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
                continue;
            }
            else
            {
                Console.WriteLine(i);
            }

        }
    }
    public static List<string> topArticles(string username, int limit)
    {
        var url = $"https://jsonmock.hackerrank.com/api/articles?author={username}&page={limit}";
        HttpClient httpClient = new HttpClient();
        var result = httpClient.GetAsync(url).Result;
        var content = result.Content.ReadAsStringAsync().Result;
        var rObj = JsonConvert.DeserializeObject<Mydata>(content);
        var rTitle = rObj.data.OrderByDescending(ro => ro.num_comments).Select(r =>
        {
            if (r.title != null)
            {
                return r.title;
            }
            else
            {
                return r.story_title;
            }
        }).Take(1).ToList();
        return rTitle;
    }
    [JsonObject]
    public class Mydata
    {
        public string page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        [JsonProperty]
        public data[] data { get; set; }
    }
    public class data
    {
        public string title { get; set; }
        public string url { get; set; }
        public string author { get; set; }
        public int? num_comments { get; set; }
        public string story_id { get; set; }
        public string story_title { get; set; }
        public string story_url { get; set; }
        public string parent_id { get; set; }
        public string created_at { get; set; }
    }
    //int n = Convert.ToInt32(Console.ReadLine().Trim());

    //Result.fizzBuzz(n);
    //var r = Result.breakPalindrome("mom");
    //Console.WriteLine(r);
    //var r = Result.topArticles("epaga", 5);
    //foreach(var rr in r)
    //{
    //    Console.WriteLine(rr);
    //}
    //Console.ReadKey();
}