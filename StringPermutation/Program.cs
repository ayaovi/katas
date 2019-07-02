using System;
using System.Collections.Generic;
using System.Linq;

namespace StringPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = GetPermutations("abalo").ToList();
            Console.WriteLine("Hello World!");
        }

        static IEnumerable<string> GetPermutations(string s)
        {
            if (s.Length == 1) return new List<string>{ s };
            return GetPermutations(s.Substring(0, s.Length - 1)).Select(x =>
                Enumerable.Range(0, x.Length + 1)
                          .Select(y => (y, x.ToCharArray().ToList()))
                          .Select(y => {
                              var arr = y.Item2;
                              arr.Insert(y.Item1, s.Last());
                              return arr;
                          })
                )
                .SelectMany(x => x)
                .Select(x => string.Concat(x));
        }
    }
}
