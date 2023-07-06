﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LeetCode.Problems102
{
	public class TreeNode
	{
		public int val;
		public TreeNode left; 
		public TreeNode right;

		public TreeNode(int val, TreeNode left, TreeNode right)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}

		
	}
	public class Solution
	{
		public IList<IList<int>> LevelOrder(TreeNode root)
		{
			var result = new List<IList<int>>();
			if (root == null) { return result; }

			Queue<TreeNode> queue = new Queue<TreeNode>();
			queue.Enqueue(root);

			while (queue.Count > 0)
			{
				int levelSize = queue.Count;
				IList<int> currentLevel = new List<int>();

				for (int i = 0; i < levelSize; i++)
				{
					TreeNode node = queue.Dequeue();
					currentLevel.Add(node.val);

					if (node.left != null)
					{
						queue.Enqueue(node.left);
					}
					if (node.right != null)
					{
						queue.Enqueue(node.right);
					}
				}
				result.Add(currentLevel);
			}
			return result;
		}
	}
}
