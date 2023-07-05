using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LeetCode.Problem3
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int maxLength = 0;
            int start = 0;
            Dictionary<char, int> charMap = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (charMap.ContainsKey(s[i]) && charMap[s[i]] >= start)
                {
                    start = charMap[s[i]] + 1;
                }
                charMap[s[i]] = i;
                maxLength = Math.Max(maxLength, i - start + 1);
            }
            return maxLength;
        }
    }
}
