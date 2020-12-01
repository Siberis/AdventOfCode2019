using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class Day4
    {

        public static int Star1(int start, int end)
        {
            var stStr = start.ToString();
            var enStr = end.ToString();
            var counter = 0;
            Inc(stStr.Select(e => int.Parse($"{e}")).ToArray(), 0, int.Parse($"{stStr[0]}"), start, end, ref counter);
            return counter;
        }
        public static void Inc(int[] numb, int length, int max, int start, int end, ref int counter)
        {
            var tmp = numb[length];
            for (int i = max; i < 10; i++)
            {
                if (length < 5)
                {
                    numb[length] = i;
                    Inc(numb, length + 1, Math.Max(max, i), start, end, ref counter);
                    numb[length] = tmp;
                }
                else
                {
                    numb[length] = i;
                    if (Enumerable.Range(1, 5).All(i => numb[i - 1] <= numb[i]))
                    {
                        if (Enumerable.Range(1, 5).Any(i => numb[i - 1] == numb[i]))
                        {
                            if (int.Parse(string.Join("", numb)) < end && int.Parse(string.Join("", numb)) > start)
                            {
                                counter++;
                            }
                        }
                    }
                    numb[length] = tmp;
                }
            }
        }
        public static int Star2(int start, int end)
        {
            var stStr = start.ToString();
            var enStr = end.ToString();
            var counter = 0;
            Inc2(stStr.Select(e => int.Parse($"{e}")).ToArray(), 0, int.Parse($"{stStr[0]}"), start, end, ref counter);
            return counter;
        }
        public static void Inc2(int[] numb, int length, int max, int start, int end, ref int counter)
        {
            var tmp = numb[length];
            for (int i = max; i < 10; i++)
            {
                if (length < 5)
                {
                    numb[length] = i;
                    Inc2(numb, length + 1, Math.Max(max, i), start, end, ref counter);
                    numb[length] = tmp;
                }
                else
                {
                    numb[length] = i;
                    if (Enumerable.Range(1, 5).All(i => numb[i - 1] <= numb[i]))
                    {
                        bool doubleNumber = Enumerable.Range(1, 5).Where(i => numb[i - 1] == numb[i]).Any(x =>
                                                       ((x - 2) >= 0 ? numb[x - 2] != numb[x] : true) &&
                                                       ((x + 1) <= 5 ? numb[x + 1] != numb[x] : true));
                        if (doubleNumber)
                        {
                            if (int.Parse(string.Join("", numb)) < end && int.Parse(string.Join("", numb)) > start)
                            {
                                counter++;
                            }
                        }
                    }
                    numb[length] = tmp;
                }
            }
        }
    }
    public static class LinqExtensions
    {
        public static bool None<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) => !source.Any(predicate);
    }
}
