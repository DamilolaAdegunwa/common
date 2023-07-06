using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.Others
{
	public class TreeNode
	{
		public int Val;
		public TreeNode Left;
		public TreeNode Right;

		public TreeNode(int val)
		{
			Val = val;
		}
	}
	public class Solution
	{
		public TreeNode ArrayToNode(int[] nums)
		{
			if(nums == null || nums.Length <= 0)
			{
				return null;
			}

			TreeNode root = new TreeNode(nums[0]);
			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			int i = 1;
			while(i < nums.Length)
			{
				TreeNode current = queue.Dequeue();

				if(i < nums.Length)
				{
					current.Left = new TreeNode(nums[i]);
					queue.Enqueue(current.Left);
					i++;
				}

				if(i < nums.Length)
				{
					current.Right = new TreeNode(nums[i]);
					queue.Enqueue(current.Right);
					i++;
				}
			}

			return root;
		}
	}
}
