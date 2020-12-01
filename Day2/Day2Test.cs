using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day2
{
    public class Day2Test
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(2, Day2.Star1("1,0,0,0,99".Split(',').Select(e => int.Parse(e)).ToArray()));
            Assert.Equal(2, Day2.Star1("2,3,0,3,99".Split(',').Select(e => int.Parse(e)).ToArray()));
            Assert.Equal(2, Day2.Star1("2,4,4,5,99,0".Split(',').Select(e => int.Parse(e)).ToArray()));
            Assert.Equal(30, Day2.Star1("1,1,1,4,99,5,6,0,99".Split(',').Select(e => int.Parse(e)).ToArray()));
            Assert.Equal(3500, Day2.Star1("1,9,10,3,2,3,11,0,99,30,40,50".Split(',').Select(e => int.Parse(e)).ToArray()));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadWithSeparator("./Day2DataStar1.txt", ',');
            var input = lines.Select(e => int.Parse(e)).ToArray();
            input[1] = 12;
            input[2] = 2;
            Assert.Equal(4138687, Day2.Star1(input));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadWithSeparator("./Day2DataStar1.txt", ',');
            var input = lines.Select(e => int.Parse(e)).ToArray();
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    input[1] = i;
                    input[2] = j;
                    if (19690720 == Day2.Star1(input))
                    {
                        Assert.Equal(6635, 100 * i + j);
                    }
                }
            }
        }
    }
}
