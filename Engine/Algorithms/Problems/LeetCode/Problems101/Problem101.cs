using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LeetCode.Problems101
{
	//internal class Problem101
	//{
	//}
	public class TreeNode
	{
		public TreeNode left;
		public TreeNode right;
		public int val;
		public TreeNode(int val, TreeNode left = null, TreeNode right = null) 
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}
	public class Solution
	{
		public bool IsSymmetric(TreeNode root)
		{
			if(root == null) return false;
			return IsMirror(root.left, root.right);
		}
		public bool IsMirror(TreeNode left, TreeNode right)
		{
			if(left == null && right == null)
			{
				return true;
			}

			if(left == null ||  right == null)
			{
				return false;
			}
			if(left.val != right.val)
			{
				return false;
			}

			return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
		}
	}
}
