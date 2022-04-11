using LeetCode;
using NUnit.Framework;
using System;

namespace LeetCodeTests
{
    public class P5_LongestPalindromicSubstringTests
    {

        [Test]
        public void LongestPalindrome_ReturnsSingleCharacter_ForSingleCharacterInput()
        {
            Assert.That(
                P5_LongestPalindromicSubstring.LongestPalindrome("a"),
                Is.EqualTo("a"));
        }

        [Test]
        public void LongestPalindrome_ReturnsAnySingleCharacter_ForInputWithNoPalindromes()
        {
            Assert.That(
                P5_LongestPalindromicSubstring.LongestPalindrome("ab"),
                Is.EqualTo("a").Or.EqualTo("b"));
        }

        [Test]
        public void GrowPalindromeFromPairOfLetters_ReturnsEvenCountPalindrome_ForInputStartingAtMiddleLettersOfPalindrome()
        {
            int palindromeStart = 2;
            int palindromeLength = 4;
            Assert.That(
                P5_LongestPalindromicSubstring.GrowPalindromeFromPairOfLetters("abvvvvab", 3),
                Is.EqualTo(new StringSpan(palindromeStart, palindromeLength)));
        }

        [Test]
        public void GrowPalindromeFromSingleLetter_ReturnsOddCountPalindrome_ForInputStartingAtMiddleLettersOfPalindrome()
        {
            int palindromeStart = 2;
            int palindromeLength = 3;
            Assert.That(
                P5_LongestPalindromicSubstring.GrowPalindromeFromSingleLetter("abvvvab", 3),
                Is.EqualTo(new StringSpan(palindromeStart, palindromeLength)));
        }

        [Test]
        public void LongestPalindrome_ReturnsLongestPalindrome_WithOddNumberedPalindrome()
        {
            Assert.That(
                P5_LongestPalindromicSubstring.LongestPalindrome("XabcbaY"),
                Is.EqualTo("abcba"));
        }

        [Test]
        public void LongestPalindrome_ReturnsLongestPalindrome_WithEvenNumberedPalindrome()
        {
            Assert.That(
                P5_LongestPalindromicSubstring.LongestPalindrome("XabccbaY"),
                Is.EqualTo("abccba"));
        }
    }
}
