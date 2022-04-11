using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class P343_IntegerBreak
    {
        public static int IntegerBreak(int n)
        {
            int minN = 2;
            int maxN = n;
            int maxK = n / 2 + 1;

            int[][] maxProductMemo = MakeMemo(maxK, maxN);

            for (int i = 0; i <= maxN; i++)
            {
                maxProductMemo[0][i] = i;
            }

            int maxProductForN = 0;

            for (int k = 1; k < maxK; k++)
            {
                for (int i = minN; i <= n; i++)
                {
                    var priorMaxProducts = maxProductMemo[k - 1];
                    int[] kPlusOneMaxProducts = new int[maxN];
                    for (int j = 1; j < i; j++)
                    {
                        kPlusOneMaxProducts[j] = priorMaxProducts[i - j] * j;
                    }
                    maxProductMemo[k][i] = kPlusOneMaxProducts.Max();
                }
                if (maxProductMemo[k][n] > maxProductForN)
                    maxProductForN = maxProductMemo[k][n];
                else
                    return maxProductForN;
            }
            return maxProductForN;
        }

        private static int[][] MakeMemo(int rows, int columns)
        {
            int[][] memo = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                memo[i] = new int[columns + 1];
            }
            return memo;
        }
    }
}
