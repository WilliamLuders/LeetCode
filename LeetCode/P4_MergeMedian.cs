using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class P4_MergeMedian
    {
        public static double MergeMedian(int[] a, int[] b)
        {
            if (a.Length > b.Length)
                return MergeMedian(b, a);

            return SearchForMedian(b, a);
        }

        private static double SearchForMedian(int[] a, int[] b)
        {
            bool evenCount = (a.Length + b.Length) % 2 == 0;

            int aCheckIndex = a.Length / 2;
            int aSearchJump = Max(a.Length / 4, 1);
            bool checkIndexUpdated;
            do
            {
                checkIndexUpdated = false;
                var medianSearchResult
                    = IsMedian(aCheckIndex, a, b, out int? otherMedian);
                if (medianSearchResult == MedianSearchResult.Median)
                {
                    if (evenCount)
                        return (a[aCheckIndex] + otherMedian.Value) / 2.0;
                    else
                        return a[aCheckIndex];
                }

                if (medianSearchResult == MedianSearchResult.TooHigh)
                {
                    aCheckIndex -= aSearchJump;
                    if (aSearchJump > 0)
                        checkIndexUpdated = true;
                }
                else
                {
                    aCheckIndex += aSearchJump;
                    if (aSearchJump > 0)
                        checkIndexUpdated = true;
                }
                Console.WriteLine($"Search index: {aCheckIndex}");
                aSearchJump = Max(aSearchJump / 2, 1);
            } while (checkIndexUpdated);
            return SearchForMedian(b, a);
        }

        /// <summary>
        /// Check if the ith element in array a is the median.
        /// </summary>
        /// <param name="i">The index to check in array a.</param>
        /// <param name="a">The first sorted array.</param>
        /// <param name="b">The second sorted array.</param>
        /// <param name="otherMedian">Other median value if i-th value is the median. Null if i-th value is singular median.</param>
        /// <returns>True if ith element of array a is the median value.</returns>
        public static MedianSearchResult IsMedian(int i, int[] a, int[] b, out int? otherMedian)
        {
            bool evenCount = (a.Length + b.Length) % 2 == 0;
            int mergedMedianPosition = (a.Length + b.Length - 1) / 2;
            otherMedian = null;

            int highestInLowSubArray;
            int lowestInHighSubArray;
            int elementToCheck = a[i];

            int highestInLowSubArrayIndex = mergedMedianPosition - i - 1;
            if (highestInLowSubArrayIndex < 0)
                highestInLowSubArray = int.MinValue;
            else if (highestInLowSubArrayIndex >= b.Length)
                highestInLowSubArray = int.MaxValue;
            else
                highestInLowSubArray = b[highestInLowSubArrayIndex];

            int lowestInHighSubArrayIndex = mergedMedianPosition - i;
            if (lowestInHighSubArrayIndex >= b.Length)
                lowestInHighSubArray = int.MaxValue;
            else if (lowestInHighSubArrayIndex < 0)
                lowestInHighSubArray = int.MinValue;
            else
                lowestInHighSubArray = b[lowestInHighSubArrayIndex];

            MedianSearchResult isMedian = 
                InRange(elementToCheck, highestInLowSubArray, lowestInHighSubArray);
            if (isMedian == MedianSearchResult.Median)
            {
                if (evenCount)
                    otherMedian = Min(a[i + 1], lowestInHighSubArray);
            }
            else if (isMedian == MedianSearchResult.TooHigh && evenCount)
            {
                highestInLowSubArrayIndex = mergedMedianPosition - i;
                if (highestInLowSubArrayIndex < 0)
                    highestInLowSubArray = int.MinValue;
                else if (highestInLowSubArrayIndex >= b.Length)
                    highestInLowSubArray = int.MaxValue;
                else
                    highestInLowSubArray = b[highestInLowSubArrayIndex];

                lowestInHighSubArrayIndex = mergedMedianPosition - i + 1;
                if (lowestInHighSubArrayIndex >= b.Length)
                    lowestInHighSubArray = int.MaxValue;
                else if (lowestInHighSubArrayIndex < 0)
                    lowestInHighSubArray = int.MinValue;
                else
                    lowestInHighSubArray = b[lowestInHighSubArrayIndex];

                isMedian = InRange(elementToCheck, highestInLowSubArray, lowestInHighSubArray);
                if (isMedian == MedianSearchResult.Median)
                {
                    otherMedian = Max(a[i-1], highestInLowSubArray);
                }
            }
            return isMedian;
        }

        private static MedianSearchResult InRange(int test, int lowEnd, int highEnd)
        {
            if (lowEnd > highEnd)
                throw new Exception("Low end higher than high end of range");
            if (test < lowEnd)
                return MedianSearchResult.TooLow;
            if (test > highEnd)
                return MedianSearchResult.TooHigh;
            return MedianSearchResult.Median;
        }

        private static int Min(int a, int b)
        {
            return a < b ? a : b;
        }

        private static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
    }

    public enum MedianSearchResult
    {
        Median = 0,
        TooLow = 1,
        TooHigh = 2
    }
}
