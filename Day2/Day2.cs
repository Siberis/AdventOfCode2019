using System;

namespace Day2
{
    public class Day2
    {

        public static int Star1(int[] inputSource)
        {
            int pos = 0;
            var input = (int[])inputSource.Clone();
            while (input[pos] != 99)
            {
                if (input[pos] == 1)
                {
                    input[input[pos + 3]] = input[input[pos + 1]] + input[input[pos + 2]];
                    pos += 4;
                }
                else if (input[pos] == 2)
                {
                    input[input[pos + 3]] = input[input[pos + 1]] * input[input[pos + 2]];
                    pos += 4;
                }

            }
            return input[0];
        }
    }
}
