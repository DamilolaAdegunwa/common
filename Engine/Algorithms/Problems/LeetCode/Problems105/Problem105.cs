using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LeetCode.Problems105
{
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

	public class Solution
	{
		private int preIndex = 0;

		public TreeNode BuildTree(int[] preorder, int[] inorder)
		{
			return ConstructTree(preorder, inorder, 0, inorder.Length - 1);
		}

		private TreeNode ConstructTree(int[] preorder, int[] inorder, int inStart, int inEnd)
		{
			if (inStart > inEnd)
			{
				return null;
			}

			int rootVal = preorder[preIndex++];
			TreeNode root = new TreeNode(rootVal);

			int inIndex = Array.IndexOf(inorder, rootVal);

			root.left = ConstructTree(preorder, inorder, inStart, inIndex - 1);
			root.right = ConstructTree(preorder, inorder, inIndex + 1, inEnd);

			return root;
		}
	}
}
