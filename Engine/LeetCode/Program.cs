using System;
using System.Collections.Generic;
using System.Linq;
namespace LeetCode
{
	public class Program
	{
		static void Main(string[] args)
		{
			#region problem 1
			var solution1 = new LeetCode.Problems.Problem1.Solution();

			//var ans1 = solution1.TwoSum(new int[] { 2, 7, 11, 15}, 9);
			//var ans1 = solution1.TwoSum(new int[] { 3, 2, 4}, 6);
			var ans1 = solution1.TwoSum2(new int[] { 3, 2, 4}, 6);
			Console.WriteLine($"[{ans1[0]},{ans1[1]}]");
			#endregion
			Console.WriteLine("LeetCode World!");
		}
	}
}