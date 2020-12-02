using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day8
{
    public class Day8
    {

        public static int Star1(int[] inputSource, int width, int height)
        {
            List<(int, int)> groups = new List<(int, int)>();
            for (int j = 0; j < inputSource.Length; j += width * height)
            {
                var countZero = 0;
                var countOne = 0;
                var countTwo = 0;
                for (int i = 0; i < width * height; i++)
                {
                    if (inputSource[j + i] == 0) countZero++;
                    if (inputSource[j + i] == 1) countOne++;
                    if (inputSource[j + i] == 2) countTwo++;
                }
                groups.Add((countZero, countOne * countTwo));
            }
            var max = groups.Min(e => e.Item1);
            return groups.Where(e => e.Item1 == max).First().Item2;
        }
        public static string Star2(int[] inputSource, int width, int height)
        {
            var tab = new int[width, height];

            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    tab[k, i] = 2;
                }
            }
            for (int j = 0; j < inputSource.Length; j += width * height)
            {
                for (int i = 0; i < height; i++)
                {
                    for (int k = 0; k < width; k++)
                    {
                        if (tab[k, i] == 2)
                        {
                            tab[k, i] = inputSource[j + (i * height) + k];
                        }
                    }
                }
            }
            var res = "";
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    res += tab[k, i];

                }
                res += "\n";
            }
            return res;
        }
    }

}
