using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode;
using NUnit.Framework;

namespace LeetCodeTests
{
    public class P20_ValidParenthesesTests
    {
        [Test]
        public void Parentheses_AreValid_ForEmptyString()
        {
            Assert.That(P20_ValidParentheses.IsValid(""), Is.EqualTo(true));
        }

        [Test]
        public void Parentheses_AreValid_ForSimpleOpenClose()
        {
            Assert.That(P20_ValidParentheses.IsValid("()"), Is.EqualTo(true));
        }

        [Test]
        public void Parentheses_AreValid_ForRepeatedOpenClose()
        {
            Assert.That(P20_ValidParentheses.IsValid("(){}"), Is.EqualTo(true));
        }

        [Test]
        public void Parentheses_AreValid_ForNestedOpenClose()
        {
            Assert.That(P20_ValidParentheses.IsValid("({[]})"), Is.EqualTo(true));
        }

        [Test]
        public void Parentheses_AreValid_ForNestedAndRepeatedOpenClose()
        {
            Assert.That(P20_ValidParentheses.IsValid("((){[]})[]{((()))}"), Is.EqualTo(true));
        }

        [Test]
        public void Parentheses_AreInvalid_ForSingleOpeningParenthesis()
        {
            Assert.That(P20_ValidParentheses.IsValid("("), Is.EqualTo(false));
        }

        [Test]
        public void Parentheses_AreInvalid_ForSingleClosingParenthesis()
        {
            Assert.That(P20_ValidParentheses.IsValid(")"), Is.EqualTo(false));
        }

        [Test]
        public void Parentheses_AreInvalid_ForNonMatchingParentheses()
        {
            Assert.That(P20_ValidParentheses.IsValid("(}"), Is.EqualTo(false));
        }

        [Test]
        public void Parentheses_AreInvalid_ForNestedNonMatchingParentheses()
        {
            Assert.That(P20_ValidParentheses.IsValid("([{]})"), Is.EqualTo(false));
        }
    }
}
