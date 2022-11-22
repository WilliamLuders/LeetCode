using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode;
using NUnit.Framework;

namespace LeetCodeTests
{
    public class P206_ReverseLinkedListTests
    {
        [Test]
        public void EmptyList_ReturnsEmptyList_WhenReversed()
        {
            ListNode node = null;
            ListNode reversed = P206_ReverseLinkedList.ReverseList(node);

            Assert.That(reversed, Is.Null);
        }

        [Test]
        public void ListWithOneElement_ReturnsOneElement_WhenReversed()
        {
            ListNode node = new ListNode(0, null);
            ListNode reversed = P206_ReverseLinkedList.ReverseList(node);

            Assert.That(reversed.val, Is.EqualTo(0));
            Assert.That(reversed.next, Is.Null);
        }

        [Test]
        public void List_ReturnsReversedList_WhenReversed()
        {
            ListNode lastNode = new ListNode(0, null);
            ListNode middleNode = new ListNode(2, lastNode);
            ListNode firstNode = new ListNode(7, middleNode);

            ListNode reversed = P206_ReverseLinkedList.ReverseList(firstNode);

            Assert.That(reversed.val, Is.EqualTo(0));
            Assert.That(reversed.next.val, Is.EqualTo(2));
            Assert.That(reversed.next.next.val, Is.EqualTo(7));
            Assert.That(reversed.next.next.next, Is.Null);
        }
    }
}
