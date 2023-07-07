using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problems.LeetCode.Problems105
{
	//internal class Problem105b
	//{
	//}
	public class SolutionB
	{
		public TreeNode BuildTree(int[] preorder, int[] inorder)
		{
			TreeNode root = new TreeNode();
			#region checks
			if(preorder == null && inorder == null) 
			{
				return null;
			}

			if (preorder == null || inorder == null)
			{
				throw new Exception("bad array(s)/request(s)");
			}

			if (preorder.Length != inorder.Length)
			{
				throw new Exception("bad array(s)/request(s)");
			}

			if (preorder.Length == 0 && inorder.Length == 0)
			{
				return null;
				//throw new Exception("bad array(s)/request(s)");
			}

			if (preorder.Length == 0 || inorder.Length == 0)
			{
				return null;
				//throw new Exception("bad array(s)/request(s)");
			}
			root.val = preorder[0];
			if (preorder.Length == 1 && inorder.Length == 1) 
			{ 
				
				return root;
			}
			#endregion

			int rootNode = preorder[0];

			int inmidLength = Array.IndexOf(inorder, rootNode);

			//lefts
			int[] preLeft = preorder.Where((o, i) => i > 0 && i <= inmidLength).ToArray();
			int[] preRight = preorder.Where((o, i) => i > inmidLength).ToArray();

			//right
			int[] inleft = inorder.Where((o, i) => i < inmidLength).ToArray();
			int[] inright = inorder.Where((o, i) => i > inmidLength).ToArray();

			root.left = BuildTree(preLeft, inleft);
			root.right = BuildTree(preRight, inright);

			return root;
		}
	}
}
