using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day7
{
    public class Day7
    {

        public static List<int> Star1(int[] inputSource, int[] inputNumber)
        {
            BlockingCollection<int> input1 = new BlockingCollection<int> { 0 };
            var prev = Execute((int[])inputSource.Clone(), new BlockingCollection<int> { inputNumber[0], 0 }, input1).Last();
            prev = Execute((int[])inputSource.Clone(), new BlockingCollection<int> { inputNumber[1], prev }, input1).Last();
            prev = Execute((int[])inputSource.Clone(), new BlockingCollection<int> { inputNumber[2], prev }, input1).Last();
            prev = Execute((int[])inputSource.Clone(), new BlockingCollection<int> { inputNumber[3], prev }, input1).Last();
            return Execute((int[])inputSource.Clone(), new BlockingCollection<int> { inputNumber[4], prev }, input1);
        }
        public static List<int> Star2(int[] inputSource, int[] inputNumber)
        {
            BlockingCollection<int> input1 = new BlockingCollection<int> { inputNumber[0], 0 };
            BlockingCollection<int> input2 = new BlockingCollection<int> { inputNumber[1] };
            BlockingCollection<int> input3 = new BlockingCollection<int> { inputNumber[2] };
            BlockingCollection<int> input4 = new BlockingCollection<int> { inputNumber[3] };
            BlockingCollection<int> input5 = new BlockingCollection<int> { inputNumber[4] };
            var list = new List<Task>();
            list.Add(Task.Run(() => Execute((int[])inputSource.Clone(), input1, input2)));
            list.Add(Task.Run(() => Execute((int[])inputSource.Clone(), input2, input3)));
            list.Add(Task.Run(() => Execute((int[])inputSource.Clone(), input3, input4)));
            list.Add(Task.Run(() => Execute((int[])inputSource.Clone(), input4, input5)));
            list.Add(Task.Run(() => Execute((int[])inputSource.Clone(), input5, input1)));
            Task.WaitAll(list.ToArray());
            return input1.ToList();
        }
        public static List<int> Execute(int[] inputSource, BlockingCollection<int> inputNumber, BlockingCollection<int> outputNumbers)
        {
            int pos = 0;
            int usedInput = 0;
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
                    input[input[pos + 1]] = inputNumber.Take();
                    usedInput++;
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
                    outputNumbers.Add(par1);
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
            int par1;
            if (input[pos] / 100 % 10 == 0)
            {
                par1 = input[input[pos + 1]];
            }
            else
            {
                par1 = input[pos + 1];
            }
            int par2;
            if (input[pos] / 1000 % 100 == 0)
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
