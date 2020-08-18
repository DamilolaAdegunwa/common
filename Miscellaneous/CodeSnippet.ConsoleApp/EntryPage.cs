using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public class Solution
{
    public static void Main(String[] args)
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
        string[] inputArr = inputList.ToArray();
        for (var i = 1; i < inputArr.Length; i++)
        {
            string[] nm = inputArr[i].Split(' ');
            int n = Convert.ToInt32(nm[0]);
            int m = Convert.ToInt32(nm[1]);
            var sigma = new Solution().SigmaSumOfGi(n);
            Console.WriteLine(sigma % m);

        }
    }
    public int SigmaSumOfGi(int n)
    {
        // if(n < 1)
        // {
        //     throw new Exception("\'n\' shouldn\'t be less than one!!");
        // }
        int sigma = 0;
        for (var i = 1; i <= n; i++)
        {
            var gi = SmallestPositiveIntegerNSuchThatSfnEqualsGi(i);
            var sgi = SumOfDigits(gi);

            sigma += sgi;
        }
        return sigma;
    }

    public int SmallestPositiveIntegerNSuchThatSfnEqualsGi(int givenSfn)
    {
        int n = 1;
        int gi = -1;
        while (gi == -1)
        {
            var fn = SumOfFactorialsOfDigitsOfN(n);
            var sfn = SumOfDigits(fn);
            if (sfn == givenSfn)
            {
                gi = n;
                break;
            }
            n++;
        }
        return gi;
    }
    public int SumOfDigits(int number)//sf(n), sg(i)
    {
        char[] numberCharArr = number.ToString().ToArray();
        int sum = 0;
        for (var i = 0; i < numberCharArr.Length; i++)
        {
            sum += Convert.ToInt32(numberCharArr[i].ToString());
        }
        return sum;
    }
    public int SumOfFactorialsOfDigitsOfN(int n)
    {
        //Define f(n) as the sum of the factorials of the digits of n. For example, 
        //f(342) = 3! + 4! + 2! = 32.
        char[] ncharArr = n.ToString().ToArray();
        int fOfn = 0;
        for (var i = 0; i < ncharArr.Length; i++)
        {
            fOfn += Factorial(Convert.ToInt32(ncharArr[i].ToString()));

        }
        return fOfn;
    }
    public int Factorial(int x)
    {
        // if(x<0)
        // {
        //     throw new Exception("This \'Factorial\' function does not cater for negative values of x");
        // }
        if (x == 0 || x == 1)
        {
            return 1;
        }
        var result = x * Factorial(x - 1);
        return result;
    }
}
