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
            //if (a.Length == 0)
            //    return Median(b);
            bool evenCount = (a.Length + b.Length) % 2 == 0;

            return SearchForMedian(b, a);
        }

        private static double SearchForMedian(int[] a, int[] b)
        {
            bool evenCount = (a.Length + b.Length) % 2 == 0;
            int aCheck;
            if (evenCount)
                aCheck = a.Length / 2 - 1;
            else
                aCheck = a.Length / 2;
            int aSearchJump = Max(a.Length / 4, 1);
            while (aSearchJump > 0)
            {
                var medianSearchResult = IsMedian(aCheck, a, b, out int nextHighest);
                if (medianSearchResult == MedianSearchResult.Median)
                {
                    if (evenCount)
                        return (a[aCheck] + nextHighest) / 2.0;
                    else
                        return a[aCheck];
                }

                if (medianSearchResult == MedianSearchResult.TooHigh)
                    aCheck -= aSearchJump;
                else
                    aCheck += aSearchJump;
                aSearchJump /= 2;
            }
            return SearchForMedian(b, a);
        }

        /// <summary>
        /// Check if the ith element in array a is the median.
        /// </summary>
        /// <param name="i">The index to check in array a.</param>
        /// <param name="a">The first sorted array.</param>
        /// <param name="b">The second sorted array.</param>
        /// <param name="nextHighest">Next highest value if i-th value is the median. Ignore otherwise</param>
        /// <returns>True if ith element of array a is the median value.</returns>
        public static MedianSearchResult IsMedian(int i, int[] a, int[] b, out int nextHighest)
        {
            int medianPosition = (a.Length + b.Length - 1) / 2;
            nextHighest = 0;

            int highestInLowSubArray;
            int lowestInHighSubArray;
            int elementToCheck = a[i];
            if (b.Length == 0)
            {
                if (i == medianPosition)
                {
                    nextHighest = a[i + 1];
                    return MedianSearchResult.Median;
                }
                if (i < medianPosition)
                    return MedianSearchResult.TooLow;
                if (i > medianPosition)
                    return MedianSearchResult.TooHigh;
            }

            highestInLowSubArray = b[medianPosition - i - 1];
            lowestInHighSubArray = b[medianPosition - i];

            if (elementToCheck >= highestInLowSubArray)
            {
                if (elementToCheck <= lowestInHighSubArray)
                {
                    nextHighest = Min(a[i + 1], lowestInHighSubArray);
                    return MedianSearchResult.Median;
                }
                return MedianSearchResult.TooHigh;
            }
            return MedianSearchResult.TooLow;
        }

        private static int Min(int a, int b)
        {
            return a < b ? a : b;
        }

        private static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        private static double Median(int[] array)
        {
            if (array.Length % 2 == 0)
                return (array[array.Length / 2]
                    + array[array.Length / 2 - 1]) / 2.0;
            else
                return (array[array.Length / 2]);
        }
    }

    public enum MedianSearchResult
    {
        Median = 0,
        TooLow = 1,
        TooHigh = 2
    }
}
