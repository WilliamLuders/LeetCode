using LeetCode;
using NUnit.Framework;

namespace LeetCodeTests
{
    public class P343_IntegerBreakTests
    {

        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 4)]
        [TestCase(5, 6)]
        [TestCase(6, 9)]
        [TestCase(7, 12)]
        [TestCase(8, 18)]
        [TestCase(9, 27)]
        [TestCase(10, 36)]
        [TestCase(11, 54)]
        [TestCase(20, 1458)]
        public void IntegerBreakTest(int n, int product)
        {
            Assert.That(
                P343_IntegerBreak.IntegerBreak(n),
                Is.EqualTo(product));
        }
    }
}
