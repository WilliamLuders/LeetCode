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
        public void Median_ReturnsMedian_WithArrayElementsSmallerThanAllOfOtherArray()
        {
            var array1 = new int[] { 0, 1, 2, 3 };
            var array2 = new int[] { 4, 4, 5 };

            Assert.That(P4_MergeMedian.MergeMedian(array1, array2), Is.EqualTo(3.0).After(100,10));
        }

        [Test, Timeout(100)]
        public void Median_ReturnsMedian_WithArrayElementsBiggerThanAllOfOtherArray()
        {
            var array1 = new int[] { 0, 1, 2 };
            var array2 = new int[] { 4, 5, 5, 8 };

            Assert.That(P4_MergeMedian.MergeMedian(array1, array2), Is.EqualTo(4.0));
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

            Assert.That(
                P4_MergeMedian.IsMedian(1, a, b, out _), 
                Is.EqualTo(MedianSearchResult.Median));
        }

        [Test]
        public void IsMedian_ReturnsMedian_ForLowerOfTwoMedianValuesWithOtherMedianInOtherArray()
        {
            var a = new int[] { 1, 2, 4, 9 };
            var b = new int[] { 0, 1, 3, 5 };

            Assert.That(
                P4_MergeMedian.IsMedian(1, a, b, out int? otherMedian),
                Is.EqualTo(MedianSearchResult.Median));
            Assert.That(
                otherMedian.Value,
                Is.EqualTo(3));
        }

        [Test]
        public void IsMedian_ReturnsMedian_ForHigherOfTwoMedianValues()
        {
            var a = new int[] { 1, 2, 4, 9 };
            var b = new int[] { 0, 1, 3, 5 };

            Assert.That(
                P4_MergeMedian.IsMedian(2, b, a, out int? otherMedian2),
                Is.EqualTo(MedianSearchResult.Median));
            Assert.That(
                otherMedian2.Value,
                Is.EqualTo(2));
        }

        [Test]
        public void IsMedian_ReturnsTooHigh_ForValueHigherThanMedian()
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 0, 1, 3, 4 };

            Assert.That(
                P4_MergeMedian.IsMedian(2, a, b, out int? otherMedian), 
                Is.EqualTo(MedianSearchResult.TooHigh));
            Assert.That(
                otherMedian, Is.Null);
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

        [Test]
        public void IsMedian_ReturnsMedian_ForMedianInSmallArray()
        {
            var a = new int[] { 3 };
            var b = new int[] { 0, 1, 2, 4, 5, 6 };

            Assert.That(
                P4_MergeMedian.IsMedian(0, a, b, out _),
                Is.EqualTo(MedianSearchResult.Median));
        }
    }
}