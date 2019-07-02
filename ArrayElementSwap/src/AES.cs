using System;
using System.Collections.Generic;
using System.Linq;

namespace src
{
    public class AES
    {
        public static bool Swap(int[] a, int[] b)
        {
            // a.OrderBy(x => x);
            // b.OrderBy(x => x);
            var sumA = a.Sum();
            var sumB = b.Sum();
            var d = sumA > sumB ? sumA - sumB : sumB - sumA;
            if (d % 2 != 0) return false;
            foreach (var i in a)
            {
                if (b.FirstOrDefault(y => y == i + d / 2) == 0) return true;
            }
            return false;
        }
    }
}
