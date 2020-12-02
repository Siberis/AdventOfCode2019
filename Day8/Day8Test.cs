using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day8
{
    public class Day8Test
    {
        [Fact]
        public void Test0()
        {
            var input = "123456789012".ToArray().Select(e => int.Parse($"{e}")).ToArray();
            Assert.Equal(1, Day8.Star1(input, 3, 2));
        }

        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadWithSeparator("./Day8DataStar1.txt", ',').ConfigureAwait(false);
            var input = lines[0].ToArray().Select(e => int.Parse($"{e}")).ToArray();
            Assert.Equal(2176, Day8.Star1(input, 25, 6));
        }
        [Fact]
        public void Test1()
        {
            var input = "0222112222120000".ToArray().Select(e => int.Parse($"{e}")).ToArray();
            Assert.Equal("01\n10\n", Day8.Star2(input, 2, 2));
        }

        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadWithSeparator("./Day8DataStar1.txt", ',').ConfigureAwait(false);
            var input = lines[0].ToArray().Select(e => int.Parse($"{e}")).ToArray();
            Assert.Equal("0110010001100101110010001\n0001100101110010001100101\n0101110010001100101000110\n0010001100101000110100100\n1100101000110100100101000\n1000110100100101000110000\n", Day8.Star2(input, 25, 6));
        }
    }
}
