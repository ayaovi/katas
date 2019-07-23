using System;
using System.Collections.Generic;
using System.Linq;

namespace src {
    public static class Compactor {
        public static int[] Reduce (this int[] x) {
            if (x.Length < 3) return x;
            var i = 0;
            var j = 1;
            var result = new HashSet<int> { x[i] };
            while (j < x.Length) {
                if (x[j] == x[i] + j - i) j++;
                else {
                    if (j >= i + 2) {
                        i = j - 1;
                    } else {
                        i = j;
                        j++;
                    }
                    result.Add (x[i]);
                }
            }
            result.Add (x[--j]);
            return result.ToArray ();
        }
    }
}