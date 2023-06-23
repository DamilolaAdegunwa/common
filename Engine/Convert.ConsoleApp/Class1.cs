using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp
{
	public class LeetcodeListNode
	{
		public int val;
		public LeetcodeListNode next;

		public LeetcodeListNode(int val = 0, LeetcodeListNode next = null)
		{
			this.val = val;
			this.next = next;
		}
	}

	public class Solution
	{
		public LeetcodeListNode RemoveNthFromEnd(LeetcodeListNode head, int n)
		{
			LeetcodeListNode dummy = new LeetcodeListNode(0);
			dummy.next = head;

			LeetcodeListNode fast = dummy;
			LeetcodeListNode slow = dummy;

			// Move the fast pointer n steps ahead
			for (int i = 0; i <= n; i++)
			{
				fast = fast.next;
			}

			// Move the fast and slow pointers simultaneously until the fast pointer reaches the end
			while (fast != null)
			{
				fast = fast.next;
				slow = slow.next;
			}

			// Remove the nth node from the end
			slow.next = slow.next.next;

			return dummy.next;
		}
	}

}
