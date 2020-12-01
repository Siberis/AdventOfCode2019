using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day5
{
    public class Day5Test
    {
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadWithSeparator("./Day5DataStar1.txt", ',').ConfigureAwait(false);
            var input = lines.Select(e => int.Parse(e)).ToArray();
            Assert.Equal(7988899, Day5.Star1(input, 1).Last());
        }
        [Fact]
        public void Test0()
        {
            var input = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99".Split(",").Select(e => int.Parse(e)).ToArray();
            Assert.Equal(1000, Day5.Star1(input, 8).Last());
            Assert.Equal(999, Day5.Star1(input, 7).Last());
            Assert.Equal(1001, Day5.Star1(input, 9).Last());
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadWithSeparator("./Day5DataStar1.txt", ',').ConfigureAwait(false);
            var input = lines.Select(e => int.Parse(e)).ToArray();
            Assert.Equal(13758663, Day5.Star1(input, 5).Last());
        }
    }
}
