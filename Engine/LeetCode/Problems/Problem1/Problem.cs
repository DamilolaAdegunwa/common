using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems.Problem1
{
	public class Solution
	{
		public int[] TwoSum(int[] nums, int target)//Beats 79.2% time and 40.33% space usage submissions
		{
			int[] res = new int[2];
			for (var i = 0; i < nums.Length; i++)
			{
				for (var j = i + 1; j < nums.Length; j++)
				{
					if (nums[i] + nums[j] == target)
					{
						res[0] = i;
						res[1] = j;
						return res;
					}
				}
			}
			return res;
		}
		public int[] TwoSum2(int[] nums, int target)//Beats 75.84% time and 20.73% space usage submissions
		{
			Dictionary<int, int> map = new Dictionary<int, int>();
			for (int i = 0; i < nums.Length; i++)
			{
				int complement = target - nums[i];
				if (map.ContainsKey(complement))
				{
					return new int[] { map[complement], i };
				}
				map[nums[i]] = i;
			}
			throw new Exception("No two sum solution");
		}
	}
}