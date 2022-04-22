using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class P20_ValidParentheses
    {
        private static HashSet<char> openParentheses = new HashSet<char>(new char[] { '[', '{', '(' });
        private static HashSet<char> closeParentheses = new HashSet<char>(new char[] { ']', '}', ')' });

        public static bool IsValid(string s)
        {
            ParenthesesStack pStack = new ParenthesesStack();

            foreach (char c in s)
            {
                if (IsOpening(c))
                {
                    pStack.Push(c);
                }
                if (IsClosing(c))
                {
                    if (!pStack.IsValidPop(c))
                    {
                        return false;
                    }
                    pStack.Pop();
                }
            }
            return pStack.Empty;
        }

        public static bool IsOpening(char c)
        {
            return openParentheses.Contains(c);
        }

        public static bool IsClosing(char c)
        {
            return closeParentheses.Contains(c);
        }

        private class ParenthesesStack
        {
            Stack<char> charStack = new Stack<char>();

            public void Push(char c)
            {
                charStack.Push(c);
            }

            public bool IsValidPop(char c)
            {
                return !Empty && ParenthesesMatch(charStack.Peek(), c);
            }

            public char Pop() => charStack.Pop();

            public bool Empty => charStack.Count == 0;

            private bool ParenthesesMatch(char openP, char closeP)
            {
                return (openP == '(' && closeP == ')'
                    || openP == '{' && closeP == '}'
                    || openP == '[' && closeP == ']');
            }
        }
    }

    

}
