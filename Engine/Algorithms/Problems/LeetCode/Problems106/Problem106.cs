using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LeetCode.Problems106
{
	//internal class Problem106
	//{
	//}
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}
	public class Solution
	{
		public TreeNode BuildTree(int[] inorder, int[] postorder)
		{
			TreeNode root = null;
			inorder = inorder?.Distinct().ToArray();
			postorder = postorder?.Distinct().ToArray();

			if(inorder == null || postorder == null ||
			inorder.Length <= 0 || postorder.Length <= 0 ||
			inorder.Length != postorder.Length)
			{
				return null;
			}

			//NB:
			//inorder array divide into 3: Left,  Node, Root (LNR)
			//postorder array divide into 3: Left, Right, Node (LRN)

			int rootNodeValue = postorder[postorder.Length - 1];//the last value
			root = new TreeNode(rootNodeValue);
			int indexNi = Array.IndexOf(inorder, rootNodeValue);

			int[] leftIn = inorder.Where((x,i)=> i < indexNi).ToArray();
			int[] rightIn = inorder.Where((x,i)=> i > indexNi).ToArray();

			int[] leftPost = postorder.Where((x,i) => i < leftIn.Length).ToArray();
			int[] rightPost = postorder.Where((x,i) => i >= leftIn.Length && i < (leftIn.Length + rightIn.Length)).ToArray();

			//left
			if(leftIn == null || leftIn.Length <= 0)
			{
				root.left = null;
			}
			else if(leftIn.Length == 1)
			{
				root.left = new TreeNode(leftIn[0]);
			}
			else
			{
				root.left = BuildTree(leftIn, leftPost);
			}

			//right
			if (rightIn == null || rightIn.Length <= 0)
			{
				root.right = null;
			}
			else if (rightIn.Length == 1)
			{
				root.right = new TreeNode(rightIn[0]);
			}
			else
			{
				root.right = BuildTree(rightIn, rightPost);
			}
			return root;
		}
	}
}
