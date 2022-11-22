using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static class P206_ReverseLinkedList
    {
        public static ListNode ReverseList(ListNode head, ListNode prior=null)
        {
            if (head == null)
                return prior;
            if (head.next == null && prior == null)
                return head;

            // get reference to the next
            var next = head.next;
            // point current to prior
            head.next = prior;
            // call reverse on next with prior as current
            return ReverseList(next, head);
        }
    }
}
