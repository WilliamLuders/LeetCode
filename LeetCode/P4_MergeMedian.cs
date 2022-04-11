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
            return SearchForMedian(a, b);
        }


        /// <summary>
        /// Check if the ith element in array a is the median.
        /// </summary>
        /// <param name="i">The index to check in array a.</param>
        /// <param name="a">The first sorted array.</param>
        /// <param name="b">The second sorted array.</param>
        /// <param name="otherMedian">
        /// Other median value if there are an even number of elements and 
        /// i-th value is the lower median. Null if there is an odd number of elements.
        /// </param>
        /// <returns>
        /// True if i-th element of array a is the median value and there is an odd number of elements.
        /// True if i-th element of array a is the lower median value and there is an even number of elements.
        /// </returns>
        public static MedianSearchResult IsMedian(int i, int[] a, int[] b, out int? otherMedian)
        {
            bool evenCount = (a.Length + b.Length) % 2 == 0;
            int mergedMedianPosition = (a.Length + b.Length - 1) / 2;
            otherMedian = null;

            int lowArrayEndValue;
            int highArrayStartValue;
            int valueToCheck = a[i];

            int lowArrayEnd = mergedMedianPosition - i - 1;
            int highArrayStart = mergedMedianPosition - i;
            
            if (lowArrayEnd < 0)
                lowArrayEndValue = int.MinValue;
            else if (lowArrayEnd >= b.Length)
                lowArrayEndValue = int.MaxValue;
            else
                lowArrayEndValue = b[lowArrayEnd];

            if (highArrayStart >= b.Length)
                highArrayStartValue = int.MaxValue;
            else if (highArrayStart < 0)
                highArrayStartValue = int.MinValue;
            else
                highArrayStartValue = b[highArrayStart];

            if (lowArrayEndValue <= valueToCheck && valueToCheck <= highArrayStartValue)
            {
                if (evenCount)
                {
                    if (i + 1 < a.Length)
                        otherMedian = Min(a[i + 1], highArrayStartValue);
                    else
                        otherMedian = highArrayStartValue;
                }
                return MedianSearchResult.Median;
            }
            else if (valueToCheck > highArrayStartValue)
            {
                return MedianSearchResult.TooHigh;
            }
            else
            {
                return MedianSearchResult.TooLow;
            }
        }

        private static double SearchForMedian(int[] a, int[] b)
        {
            bool evenCount = (a.Length + b.Length) % 2 == 0;

            int mid;
            int l = 0;
            int r = a.Length - 1;

            while (l <= r)
            {
                mid = l + (r - l) / 2;
                var medianSearchResult = IsMedian(mid, a, b, out int? otherMedian);
                if (medianSearchResult == MedianSearchResult.Median)
                    if (evenCount)
                        return (a[mid] + otherMedian.Value) / 2.0;
                    else
                        return a[mid];
                else if (medianSearchResult == MedianSearchResult.TooHigh)
                    r = mid - 1;
                else
                    l = mid + 1;
            }
            
            return SearchForMedian(b, a);
        }

        private static int Min(int a, int b)
        {
            return a < b ? a : b;
        }
    }

    public enum MedianSearchResult
    {
        Median = 0,
        TooLow = 1,
        TooHigh = 2
    }
}
