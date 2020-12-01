using System;

namespace Day1
{
    public class Day1
    {

        public static int Star1(int input) => (int)Math.Floor(((double)input) / 3) - 2;
        public static int Star2(int input)
        {
            var res = (int)Math.Floor(((double)input) / 3) - 2;
            if (res <= 0)
            {
                return 0;
            }
            else
            {
                return res + Star2(res);
            }
        }
    }
}
