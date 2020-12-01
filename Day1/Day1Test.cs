using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day1
{
    public class Day1Test
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(2, Day1.Star1(12));
            Assert.Equal(2, Day1.Star1(14));
            Assert.Equal(654, Day1.Star1(1969));
            Assert.Equal(33583, Day1.Star1(100756));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Data.txt");
            Assert.Equal(3353880, lines.Select(e => Day1.Star1(int.Parse(e))).Sum());
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(2, Day1.Star2(14));
            Assert.Equal(966, Day1.Star2(1969));
            Assert.Equal(50346, Day1.Star2(100756));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day1Data.txt");
            Assert.Equal(5027950, lines.Select(e => Day1.Star2(int.Parse(e))).Sum());
        }
    }
}
