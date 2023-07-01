using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace LeetCode
{
	public class Program
	{
		#region problem 1
		//static void Main(string[] args)
		//{

		//	var solution1 = new LeetCode.Problems.Problem1.Solution();

		//	//var ans1 = solution1.TwoSum(new int[] { 2, 7, 11, 15}, 9);
		//	//var ans1 = solution1.TwoSum(new int[] { 3, 2, 4}, 6);
		//	var ans1 = solution1.TwoSum2(new int[] { 3, 2, 4}, 6);
		//	Console.WriteLine($"[{ans1[0]},{ans1[1]}]");

		//	Console.WriteLine("LeetCode World!");
		//}
		#endregion

		#region problem 2
		//public static void Main()
		//{
		//	var l1 = new LeetCode.Problems.Problem2.ListNode { 
		//		val = 1,
		//		next = new LeetCode.Problems.Problem2.ListNode
		//		{
		//			val = 1,
		//			next = new LeetCode.Problems.Problem2.ListNode
		//			{
		//				val = 9,
		//				next = null
		//			}
		//		}
		//	};

		//	var l2 = new LeetCode.Problems.Problem2.ListNode
		//	{
		//		val = 9,
		//		next = new LeetCode.Problems.Problem2.ListNode
		//		{
		//			val = 2,
		//			next = new LeetCode.Problems.Problem2.ListNode
		//			{
		//				val = 7,
		//				next = null
		//			}
		//		}
		//	};

		//	var ans = new LeetCode.Problems.Problem2.Solution().AddTwoNumbers(l1, l2);
		//	//var ans = new LeetCode.Problems.Problem2.Solution().Continuous();
		//	Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(ans));
		//	_ = "done";
		//}
		#endregion

		#region problem 3
		//public static void Main(string[] args)
		//{
		//	//var ans = new LeetCode.Problems.Problem3.Solution().LengthOfLongestSubstring("acbdddasasasasasdasasasabcdefghi");//10
		//	var ans = new LeetCode.Problems.Problem3.Solution().LengthOfLongestSubstring("acbdddasasasasasdasasasab");//4
		//	//var ans = new LeetCode.Problems.Problem3.Solution().LengthOfLongestSubstring("12341234123456");//6 6
		//	Console.WriteLine(ans);
		//	_ = "done";
		//}
		#endregion

		#region problem 4
		//public static void Main(string[] args)
		//{
		//	var ans = new LeetCode.Problems.Problem4.Solution().FindMedianSortedArrays("12341234123456");
		//	Console.WriteLine(ans);
		//	_ = "done";
		//}
		#endregion
	}
}