using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class P5_LongestPalindromicSubstring
    {
        public static string LongestPalindrome(string v)
        {
            StringSpan bestPalindrome = new StringSpan(0, 0);
            for (int i = 0; i< v.Length; i++)
            {
                var palindromeFromSeed = GrowPalindromeFromSingleLetter(v, i);
                if (palindromeFromSeed.Length > bestPalindrome.Length)
                    bestPalindrome = palindromeFromSeed;

                palindromeFromSeed = GrowPalindromeFromPairOfLetters(v, i);
                if (palindromeFromSeed.Length > bestPalindrome.Length)
                    bestPalindrome = palindromeFromSeed;
            }

            return v.Substring(bestPalindrome.StartIndex, bestPalindrome.Length);
        }

        public static StringSpan GrowPalindromeFromSingleLetter(string s, int i)
        {
            return GrowPalindromeFromCenterSeed(s, i - 1, 3);
        }

        public static StringSpan GrowPalindromeFromPairOfLetters(string s, int firstIndex)
        {
            if (firstIndex + 1 >= s.Length)
                return new StringSpan(firstIndex, 1);
            if (s[firstIndex] != s[firstIndex + 1])
                return new StringSpan(firstIndex, 1);
            return GrowPalindromeFromCenterSeed(s, firstIndex - 1, 4);
        }

        private static StringSpan GrowPalindromeFromCenterSeed(string s, int start, int length)
        {
            if (start < 0 || start + length - 1 >= s.Length)
                return new StringSpan(start + 1, length - 2);
            if (s[start] != s[start + length - 1])
                return new StringSpan(start + 1, length - 2);
            return GrowPalindromeFromCenterSeed(s, start - 1, length + 2);
        }
    }
    
    public record StringSpan
    {
        public StringSpan(int startIndex, int length)
        {
            StartIndex = startIndex;
            Length = length;
        }

        public int StartIndex { get; }
        public int Length{ get; }
    }
}
