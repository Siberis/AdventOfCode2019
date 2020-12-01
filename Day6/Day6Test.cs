using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day6
{
    public class Day6Test
    {
        [Fact]
        public void Test0()
        {
            var input = "COM)B\nB)C\nC)D\nD)E\nE)F\nB)G\nG)H\nD)I\nE)J\nJ)K\nK)L".Split("\n").ToArray();
            Assert.Equal(42, Day6.Star1(input));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6DataStar1.txt").ConfigureAwait(false);
            Assert.Equal(171213, Day6.Star1(lines));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day6DataStar1.txt").ConfigureAwait(false);
            Assert.Equal(292, Day6.Star2(lines, "YOU", "SAN"));
        }
    }
}
