using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp
{
    public class ProjectEuler254
    {
        public static Dictionary<long, long> GiTable { get; set; } = new Dictionary<long, long>();
        public class NtoSfn
        {
            public long N { get; set; }
            public long FN { get; set; }
            public long SFN { get; set; }
        }
        public static List<NtoSfn> ntoSfns { get; set; } = new List<NtoSfn>();
        public ProjectEuler254()
        {

        }
        public static void Run(String[] args)
        {
            //for (var i = 1_999_999_999_999_999_000; i < 1_999_999_999_999_999_999; i++)
            //{
            //    var x = new Solution().SumOfFactorialsOfDigitsOfN(i);
            //    var y = new Solution().SumOfDigits(x);
            //    Console.Write($"{y,10}");
            //}
            //Console.WriteLine("done");
            //new Solution().MethodThatCreatesGiTable();

            TypedGiTable();
            RunProjectEuler254();
            Console.ReadLine();
        }
        public static Dictionary<long, long> TypedGiTable()
        {
            GiTable = new Dictionary<long, long>
            {
                [1] = 1,
                [2] = 2,
                [6] = 3,
                [3] = 5,
                [9] = 6,
                [27] = 9,
                [7] = 13,
                [4] = 15,
                [10] = 16,
                [28] = 19,
                [8] = 23,
                [5] = 25,
                [11] = 26,
                [29] = 29,
                [15] = 36,
                [33] = 39,
                [12] = 44,
                [24] = 49,
                [18] = 67,
                [30] = 129,
                [16] = 136,
                [34] = 139,
                [13] = 144,
                [25] = 149,
                [19] = 167,
                [31] = 229,
                [17] = 236,
                [35] = 239,
                [26] = 249,
                [14] = 256,
                [20] = 267,
                [21] = 349,
                [32] = 1229,
                [36] = 1239,
                [22] = 1349,
                [23] = 2349,
                [39] = 4479,
                [37] = 13339,
                [40] = 14479,
                [38] = 23599,
                [42] = 344479,
                [43] = 1344479,
                [41] = 2355679,
                [44] = 2378889,
                [45] = 12378889,
                [46] = 133378889,
            };
            return GiTable;
        }
        public Task MethodThatCreatesGiTable()
        {
            /*
             first the key is the gi (n) and value is n
             second make the key & value unique
             foreach time you do the n => sfn thing, if you get a value equal to a previous ignore
             every you have n%20 == 0, check what n is missing
             */
            //Console.WriteLine(SumOfDigits(SumOfFactorialsOfDigitsOfN(1_999_999_999_999_999_999)));
            const long nMax = 1_000_000_000_000_000_000;
            var startfor = DateTime.Now;
            for (long n = 1; n <= nMax; n++)
            {
                var sfn = SumOfDigits(SumOfFactorialsOfDigitsOfN(n));
                if (!GiTable.ContainsKey(sfn))
                {
                    GiTable.Add(sfn, n);
                    Console.WriteLine($"[{sfn}] = {n},");
                }

            }
            Console.WriteLine($" time taken: {DateTime.Now - startfor}");
            return default;
        }
        public static void RunProjectEuler254()
        {
            /*
            Enter your code here. Read input from STDIN. Print output to STDOUT. 
            Your class should be named Solution 
            */
            List<string> inputList = new List<string>();//taking in inputs, line after line
            bool keepingGetting = true;
            while (keepingGetting)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                inputList.Add(input);
            }
            //var start = DateTime.Now;
            string[] inputArr = inputList.ToArray();
            for (long i = 1; i < inputArr.Length; i++)
            {
                string[] nm = inputArr[i].Split(' ');
                long n = Convert.ToInt64(nm[0]);
                long m = Convert.ToInt64(nm[1]);
                long sigma = new ProjectEuler254().SigmaSumOfGi(n);
                Console.WriteLine(sigma % m);
            }
            //var end = DateTime.Now;
            //Console.WriteLine(end - start);
            Console.ReadLine();
        }
        public long SigmaSumOfGi(long n)
        {
            // if(n < 1)
            // {
            //     throw new Exception("\'n\' shouldn\'t be less than one!!");
            // }
            long sigma = 0;
            for (long i = 1; i <= n; i++)
            {

                long gi = 0;
                var sfn = SumOfDigits(SumOfFactorialsOfDigitsOfN(n));
                gi = GiTable[sfn];
                //try
                //{
                //    gi = GiTable[i];//SmallestPositiveIntegerNSuchThatSfnEqualsGi(i);
                //}
                //catch (Exception)
                //{

                //}
                long sgi = SumOfDigits(gi);

                sigma += sgi;
            }
            return sigma;
        }
        public long SmallestPositiveIntegerNSuchThatSfnEqualsGi(long givenSfn)
        {
            long n = 1;
            long gi = -1;
            while (gi == -1)
            {
                long fn = SumOfFactorialsOfDigitsOfN(n);
                long sfn = SumOfDigits(fn);
                if (sfn == givenSfn)
                {
                    gi = n;
                    break;
                }
                n++;
            }
            return gi;
        }
        public long SumOfDigits(long number)//sf(n), sg(i)
        {
            char[] numberCharArr = number.ToString().ToArray();
            long sum = 0;
            for (long i = 0; i < numberCharArr.Length; i++)
            {
                sum += Convert.ToInt32(numberCharArr[i].ToString());
            }
            return sum;
        }
        public long SumOfFactorialsOfDigitsOfN(long n)
        {
            //Define f(n) as the sum of the factorials of the digits of n. For example, 
            //f(342) = 3! + 4! + 2! = 32.
            char[] ncharArr = n.ToString().ToArray();
            long fOfn = 0;
            for (long i = 0; i < ncharArr.Length; i++)
            {
                fOfn += Factorial(Convert.ToInt32(ncharArr[i].ToString()));

            }
            return fOfn;
        }
        public long Factorial(long x)
        {
            // if(x<0)
            // {
            //     throw new Exception("This \'Factorial\' function does not cater for negative values of x");
            // }
            if (x == 0 || x == 1)
            {
                return 1;
            }
            long result = x * Factorial(x - 1);
            return result;
        }
    }
}