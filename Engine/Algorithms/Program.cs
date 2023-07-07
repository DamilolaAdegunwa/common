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

		#region problem 50
		//public static void Main(string[] args)
		//{
		//	var ans = new Algorithms.Problems.LeetCode.Problem50.Solution().MyPow(2, -2147483648);
		//	Console.WriteLine(ans);
		//	_ = "done";
		//}
		#endregion

		#region Problem 101
		//public static void Main(string[] args)
		//{
		//	//level 3
		//	Algorithms.Problems.LeetCode.Problems101.TreeNode t3a = new Algorithms.Problems.LeetCode.Problems101.TreeNode(3, null, null);
		//	Algorithms.Problems.LeetCode.Problems101.TreeNode t3b = new Algorithms.Problems.LeetCode.Problems101.TreeNode(4, null, null);
		//	Algorithms.Problems.LeetCode.Problems101.TreeNode t3c = new Algorithms.Problems.LeetCode.Problems101.TreeNode(4, null, null);
		//	Algorithms.Problems.LeetCode.Problems101.TreeNode t3d = new Algorithms.Problems.LeetCode.Problems101.TreeNode(3, null, null);

		//	//level 2
		//	Algorithms.Problems.LeetCode.Problems101.TreeNode t2a = new Algorithms.Problems.LeetCode.Problems101.TreeNode(2, t3a, t3b);
		//	Algorithms.Problems.LeetCode.Problems101.TreeNode t2b = new Algorithms.Problems.LeetCode.Problems101.TreeNode(2, t3c, t3d);

		//	//level 1
		//	Algorithms.Problems.LeetCode.Problems101.TreeNode root = new Algorithms.Problems.LeetCode.Problems101.TreeNode(1, t2a, t2b);

		//	var ans = new Algorithms.Problems.LeetCode.Problems101.Solution().IsSymmetric(root);
		//	Console.WriteLine(ans);
		//	_ = "done";
		//}
		#endregion

		#region Problem 102
		//public static void Main(string[] args)
		//{
		//	//level 3
		//	Algorithms.Problems.LeetCode.Problems102.TreeNode t3a = new Algorithms.Problems.LeetCode.Problems102.TreeNode(3, null, null);
		//	Algorithms.Problems.LeetCode.Problems102.TreeNode t3b = new Algorithms.Problems.LeetCode.Problems102.TreeNode(4, null, null);
		//	Algorithms.Problems.LeetCode.Problems102.TreeNode t3c = new Algorithms.Problems.LeetCode.Problems102.TreeNode(4, null, null);
		//	Algorithms.Problems.LeetCode.Problems102.TreeNode t3d = new Algorithms.Problems.LeetCode.Problems102.TreeNode(3, null, null);

		//	//level 2
		//	Algorithms.Problems.LeetCode.Problems102.TreeNode t2a = new Algorithms.Problems.LeetCode.Problems102.TreeNode(2, t3a, t3b);
		//	Algorithms.Problems.LeetCode.Problems102.TreeNode t2b = new Algorithms.Problems.LeetCode.Problems102.TreeNode(2, t3c, t3d);

		//	//level 1
		//	Algorithms.Problems.LeetCode.Problems102.TreeNode root = new Algorithms.Problems.LeetCode.Problems102.TreeNode(1, t2a, t2b);

		//	var ans = new Algorithms.Problems.LeetCode.Problems102.Solution().LevelOrder(root);
		//	Console.WriteLine(ans);
		//	_ = "done";
		//}
		#endregion

		#region ArrayToNode
		//public static void Main(string[] args)
		//{
		//	int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
		//	var ans = new Algorithms.Problems.Others.Solution().ArrayToNode(ints);
		//	Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(ans, Formatting.Indented));
		//	_ = "done";
		//}
		#endregion

		#region Problem 103
		//public static void Main(string[] args)
		//{
		//	//level 3
		//	Algorithms.Problems.LeetCode.Problems103.TreeNode t3a = new Algorithms.Problems.LeetCode.Problems103.TreeNode(3, null, null);
		//	Algorithms.Problems.LeetCode.Problems103.TreeNode t3b = new Algorithms.Problems.LeetCode.Problems103.TreeNode(4, null, null);
		//	Algorithms.Problems.LeetCode.Problems103.TreeNode t3c = new Algorithms.Problems.LeetCode.Problems103.TreeNode(4, null, null);
		//	Algorithms.Problems.LeetCode.Problems103.TreeNode t3d = new Algorithms.Problems.LeetCode.Problems103.TreeNode(3, null, null);

		//	//level 2
		//	Algorithms.Problems.LeetCode.Problems103.TreeNode t2a = new Algorithms.Problems.LeetCode.Problems103.TreeNode(2, t3a, t3b);
		//	Algorithms.Problems.LeetCode.Problems103.TreeNode t2b = new Algorithms.Problems.LeetCode.Problems103.TreeNode(2, t3c, t3d);

		//	//level 1
		//	Algorithms.Problems.LeetCode.Problems103.TreeNode root = new Algorithms.Problems.LeetCode.Problems103.TreeNode(1, t2a, t2b);

		//	var ans = new Algorithms.Problems.LeetCode.Problems103.Solution().ZigzagLevelOrder(root);
		//	Console.WriteLine(ans);
		//	_ = "done";
		//}
		#endregion

		#region Problem 104
		//public static void Main(string[] args)
		//{
		//	//level 5
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t5a = new Algorithms.Problems.LeetCode.Problems104.TreeNode(16, null, null);

		//	//level 4
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t4a = new Algorithms.Problems.LeetCode.Problems104.TreeNode(8, t5a, null);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t4b = new Algorithms.Problems.LeetCode.Problems104.TreeNode(9, null, null);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t4c = new Algorithms.Problems.LeetCode.Problems104.TreeNode(10, null, null);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t4d = new Algorithms.Problems.LeetCode.Problems104.TreeNode(11, null, null);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t4e = new Algorithms.Problems.LeetCode.Problems104.TreeNode(12, null, null);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t4f = new Algorithms.Problems.LeetCode.Problems104.TreeNode(13, null, null);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t4g = new Algorithms.Problems.LeetCode.Problems104.TreeNode(14, null, null);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t4h = new Algorithms.Problems.LeetCode.Problems104.TreeNode(15, null, null);

		//	//level 3
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t3a = new Algorithms.Problems.LeetCode.Problems104.TreeNode(4, t4a, t4b);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t3b = new Algorithms.Problems.LeetCode.Problems104.TreeNode(5, t4c, t4d);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t3c = new Algorithms.Problems.LeetCode.Problems104.TreeNode(6, t4e, t4f);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t3d = new Algorithms.Problems.LeetCode.Problems104.TreeNode(7, t4g, t4h);

		//	//level 2
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t2a = new Algorithms.Problems.LeetCode.Problems104.TreeNode(2, t3a, t3b);
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode t2b = new Algorithms.Problems.LeetCode.Problems104.TreeNode(3, t3c, t3d);

		//	//level 1
		//	Algorithms.Problems.LeetCode.Problems104.TreeNode root = new Algorithms.Problems.LeetCode.Problems104.TreeNode(1, t2a, t2b);

		//	var ans = new Algorithms.Problems.LeetCode.Problems104.Solution().MaxDepth(root);
		//	Console.WriteLine(ans);
		//	_ = "done";
		//}
		#endregion

		#region problem 105
		//public static void Main(string[] args)
		//{
		//	var ans = new Algorithms.Problems.LeetCode.Problems105.Solution()
		//		.BuildTree(new int[] { 1,2,3 }, new int[] { 1,2,3 });
		//	Console.WriteLine(ans);
		//	_ = "done";
		//}
		#endregion

		#region problem 105 B
		public static void Main(string[] args)
		{
			//var ans = new Algorithms.Problems.LeetCode.Problems105.SolutionB().BuildTree(new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 });
			//var ans = new Algorithms.Problems.LeetCode.Problems105.SolutionB().BuildTree(new int[] { 1,2,4,8,9,5,10,11,3,6,12,13,7,14,15}, new int[] { 8,4,9,2,10,5,11,1,12,6,13,3,14,7,15 });
			var ans = new Algorithms.Problems.LeetCode.Problems105.SolutionB().BuildTree(new int[] { 1,2 }, new int[] { 2,1 });

			Console.WriteLine(ans);
			_ = "done";
		}
		#endregion
	}
}
/*
studied-in-order
----------------
1) leetcode 101✔️
2) ArrayToNode✔️
3) leetcode 102✔️
4) leetcode 103✔️
5) leetcode 104✔️
 */