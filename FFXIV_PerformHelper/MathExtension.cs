using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_PerformHelper
{
    public static class MathExtension
    {
        public static int Lerp(int a, int b, double t)
        {
            if (t <= 0)
                return a;
            if (t >= 1)
                return b;

            return (int)(a + (b - a) * t);
        }

        public static int Max(int[] v)
        {
            int max = v[0];
            for (int i = 1; i < v.Length; i++)
            {
                if (max < v[i])
                    max = v[i];
            }

            return max;
        }
    }
}
