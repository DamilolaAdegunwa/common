using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LeetCode.Problems41
{
	//internal class Problem41
	//{
	//}
	public class Solution
	{
		public int FirstMissingPositive(int[] nums)
		{
			//remove 0 or less
			nums = nums.Where(x => x > 0).ToArray();
			Array.Sort(nums);
			if (nums.Length == 0)
			{
				return 1;
			}
			int upper = nums.Length <= nums[nums.Length - 1] ? nums.Length : nums[nums.Length - 1];
			// for(int i = 1; i <= upper; i++)
			// {
			//     var index = Array.IndexOf(nums,i);
			//     if(index == -1)
			//     {
			//         return i;
			//     }
			// }
			for (int i = 1; i <= upper; i++)
			{
				if (nums[i - 1] != i)
				{
					return i;
				}
			}
			return upper + 1;
		}
	}

}
