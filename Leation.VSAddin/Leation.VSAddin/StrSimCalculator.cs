using System;
using System.Collections.Generic;
using System.Text;

namespace Leation.VSAddin
{
    public static class StrSimCalculator
    {
        private static int CalculateLevenshteinDistance(String str1, String str2)
        {
            int n = str1.Length;
            int m = str2.Length;
            if (n == 0)
            {
                return m;
            }
            if (m == 0)
            {
                return n;
            }
            //Distance
            int[,] dis = new int[n + 1, m + 1];
            for (int i = 0; i <= n; i++)
            {
                dis[i, 0] = i;
            }
            for (int j = 0; j <= m; j++)
            {
                dis[0, j] = j;
            }
            for (int i = 1; i <= n; i++)
            {
                char ch1 = str1[i - 1];
                //match str2   
                for (int j = 1; j <= m; j++)
                {
                    int temp;
                    char ch2 = str2[j - 1];
                    if (ch1 == ch2)
                    {
                        temp = 0;
                    }
                    else
                    {
                        temp = 1;
                    }

                    dis[i, j] = CalculateMin(dis[i - 1, j] + 1, dis[i, j - 1] + 1, dis[i - 1, j - 1] + temp);
                }
            }
            return dis[n, m];
        }

        private static int CalculateMin(int one, int two, int three)
        {
            int min = one;
            if (two < min)
            {
                min = two;
            }
            if (three < min)
            {
                min = three;
            }
            return min;
        }

        public static double CalculateSim(String str1, String str2)
        {
            int ld = CalculateLevenshteinDistance(str1, str2);
            return 1 - (double)ld / Math.Max(str1.Length, str2.Length);
        }
    }
}
