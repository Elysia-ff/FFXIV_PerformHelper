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
    }
}
