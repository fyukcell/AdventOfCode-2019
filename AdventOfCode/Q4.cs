using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class Q4
    {
        public static int Q4A()
        {

            int k;
            int solutions = 0;
            for (k = 136818; k < 685980; k++)
            {
                bool flag = true;
                int digit = -1;
                int[] digits = new int[10];
                for (int i = 0; i < 10; i++) digits[i]++;

                for (int j = 7; j > 1; j--)
                {
                    int divider = (int)((k % Math.Pow(10, j - 1)) / Math.Pow(10, j - 2));
                    if (digit > divider) flag = false;

                    if (digit == divider)
                    {

                        digits[digit] += 1;

                    }
                    
                    digit = divider;
                    
                }

                if (flag && matchChecker(digits))
                {
                    solutions++;
                }
            }

            return solutions;
        }
        public static bool matchChecker(int[] arr)
        {
            for (int i = 0; i < 10; i++)
            {
                if (arr[i] == 2) return true;
            }

            return false;
        }
    }

  
}
