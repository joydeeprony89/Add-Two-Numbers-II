using System;
using System.Collections.Generic;

namespace Add_Two_Numbers_II
{
    class Program
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

        static void Main(string[] args)
        {
            ListNode l1 = new ListNode(7);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(4);
            l1.next.next.next = new ListNode(3);

            ListNode l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);

            var result = AddTwoNumbers(l1, l2);

            while(result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();
            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }

            int carry = 0;
            ListNode head = null;
            while(s1.Count > 0 || s2.Count > 0 || carry != 0)
            {
                int sum = 0;
                if (s1.Count > 0) sum += s1.Pop();
                if (s2.Count > 0) sum += s2.Pop();
                sum += carry;
                ListNode current = new ListNode(sum % 10);
                current.next = head;
                head = current;

                carry = sum / 10;
            }

            return head;
        }
    }
}
