using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LeetCode.Problem4
{
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length, n = nums2.Length;
            if (m > n)
            {
                int[] temp = nums1; nums1 = nums2; nums2 = temp;
                int tmp = m; m = n; n = tmp;
            }
            int i_min = 0, i_max = m, half_len = (m + n + 1) / 2;
            while (i_min <= i_max)
            {
                int i = (i_min + i_max) / 2;
                int j = half_len - i;
                if (i < m && nums2[j - 1] > nums1[i])
                {
                    i_min = i + 1;
                }
                else if (i > 0 && nums1[i - 1] > nums2[j])
                {
                    i_max = i - 1;
                }
                else
                {
                    double max_left;
                    if (i == 0) { max_left = nums2[j - 1]; }
                    else if (j == 0) { max_left = nums1[i - 1]; }
                    else { max_left = Math.Max(nums1[i - 1], nums2[j - 1]); }
                    if ((m + n) % 2 == 1) { return max_left; }
                    double min_right;
                    if (i == m) { min_right = nums2[j]; }
                    else if (j == n) { min_right = nums1[i]; }
                    else { min_right = Math.Min(nums1[i], nums2[j]); }
                    return (max_left + min_right) / 2.0;
                }
            }
            return 0.0;
        }
    }
}
