using LeetCode;
using NUnit.Framework;

namespace LeetCodeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Median_ReturnsMedian_WithOneArrayEmptyAndOneArrayWithOddCount()
        {
            var array1 = new int[] { 0, 1, 2};
            var array2 = new int[] { };

            Assert.That(P4_MergeMedian.MergeMedian(array1, array2), Is.EqualTo(1.0));
        }

        [Test]
        public void Median_ReturnsMedian_WithOneArrayEmptyAndOneArrayWithEvenCount()
        {
            var array1 = new int[] { 0, 1, 2, 3 };
            var array2 = new int[] { };

            Assert.That(P4_MergeMedian.MergeMedian(array1, array2), Is.EqualTo(1.5));
        }

        [Test]
        public void Median_ReturnsMedian_WithOddTotalCount()
        {
            var array1 = new int[] { 0, 1, 2, 3 };
            var array2 = new int[] { 3, 4, 5 };

            Assert.That(P4_MergeMedian.MergeMedian(array1, array2), Is.EqualTo(3.0));
        }

        [Test]
        public void Median_ReturnsMedian_WithEvenTotalCount()
        {
            var array1 = new int[] { 0, 1, 2 };
            var array2 = new int[] { 1, 4, 5 };

            Assert.That(P4_MergeMedian.MergeMedian(array1, array2), Is.EqualTo(1.5));
        }

        [Test]
        public void IsMedian_ReturnsTrue_ForMedianElement()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 0, 1, 3, 4 };

            int nextHighest;

            Assert.That(
                P4_MergeMedian.IsMedian(1, a, b, out nextHighest), 
                Is.EqualTo(MedianSearchResult.Median));
        }

        [Test]
        public void IsMedian_ReturnsMedian_ForLowerOfTwoMedianValues()
        {
            var a = new int[] { 1, 2, 3, 9 };
            var b = new int[] { 0, 1, 3, 4 };

            Assert.That(
                P4_MergeMedian.IsMedian(1, a, b, out _),
                Is.EqualTo(MedianSearchResult.Median));
        }

        [Test]
        public void IsMedian_ReturnsTooHigh_ForHigherOfTwoMedianValues()
        {
            var a = new int[] { 1, 2, 3, 9 };
            var b = new int[] { 0, 1, 3, 4 };

            Assert.That(
                P4_MergeMedian.IsMedian(2, a, b, out _),
                Is.EqualTo(MedianSearchResult.TooHigh));
            Assert.That(
                P4_MergeMedian.IsMedian(2, b, a, out _),
                Is.EqualTo(MedianSearchResult.TooHigh));
        }

        [Test]
        public void IsMedian_ProvidesNextHighestValueAfterMedian_WhenDetectingMedianElement()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 0, 1, 6, 4 };

            int nextHighest;

            P4_MergeMedian.IsMedian(1, a, b, out nextHighest);
            Assert.That(nextHighest, Is.EqualTo(3));
        }

        [Test]
        public void IsMedian_ReturnsTooHigh_ForValueHigherThanMedian()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 0, 1, 3, 4 };


            Assert.That(
                P4_MergeMedian.IsMedian(2, a, b, out _), 
                Is.EqualTo(MedianSearchResult.TooHigh));
        }

        [Test]
        public void IsMedian_ReturnsTooLow_ForValueLowerThanMedian()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 0, 1, 3, 4 };


            Assert.That(
                P4_MergeMedian.IsMedian(0, a, b, out _),
                Is.EqualTo(MedianSearchResult.TooLow));
        }
    }
}