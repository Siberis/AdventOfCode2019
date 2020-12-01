using System;
using System.Collections.Generic;

namespace Day5
{
    public class Day5
    {

        public static List<int> Star1(int[] inputSource, int inputNumber)
        {
            int pos = 0;
            var input = (int[])inputSource.Clone();
            List<int> outputs = new List<int>();
            while (input[pos] != 99)
            {
                if (input[pos] % 10 == 1)
                {
                    var (par1, par2) = GetParams(input, pos);
                    input[input[pos + 3]] = par1 + par2;
                    pos += 4;
                }
                else if (input[pos] % 10 == 2)
                {
                    var (par1, par2) = GetParams(input, pos);
                    input[input[pos + 3]] = par1 * par2;
                    pos += 4;
                }
                else if (input[pos] % 10 == 3)
                {
                    input[input[pos + 1]] = inputNumber;
                    pos += 2;
                }
                else if (input[pos] % 10 == 4)
                {
                    var par1 = 0;
                    if ((input[pos] / 100) % 10 == 0)
                    {
                        par1 = input[input[pos + 1]];
                    }
                    else
                    {
                        par1 = input[pos + 1];
                    }
                    outputs.Add(par1);
                    pos += 2;
                }
                else if (input[pos] % 10 == 5)
                {
                    var (par1, par2) = GetParams(input, pos);
                    if (par1 != 0)
                    {
                        pos = par2;
                    }
                    else
                    {
                        pos += 3;
                    }
                }
                else if (input[pos] % 10 == 6)
                {
                    var (par1, par2) = GetParams(input, pos);
                    if (par1 == 0)
                    {
                        pos = par2;
                    }
                    else
                    {
                        pos += 3;
                    }
                }
                else if (input[pos] % 10 == 7)
                {
                    var (par1, par2) = GetParams(input, pos);
                    if (par1 < par2)
                    {
                        input[input[pos + 3]] = 1;
                    }
                    else
                    {
                        input[input[pos + 3]] = 0;
                    }
                    pos += 4;
                }
                else if (input[pos] % 10 == 8)
                {
                    var (par1, par2) = GetParams(input, pos);
                    if (par1 == par2)
                    {
                        input[input[pos + 3]] = 1;
                    }
                    else
                    {
                        input[input[pos + 3]] = 0;
                    }
                    pos += 4;
                }

            }
            return outputs;
        }

        public static (int, int) GetParams(int[] input, int pos)
        {
            var par1 = 0;
            var par2 = 0;
            if ((input[pos] / 100) % 10 == 0)
            {
                par1 = input[input[pos + 1]];
            }
            else
            {
                par1 = input[pos + 1];
            }
            if ((input[pos] / 1000) % 100 == 0)
            {
                par2 = input[input[pos + 2]];
            }
            else
            {
                par2 = input[pos + 2];
            }
            return (par1, par2);
        }
    }
}
