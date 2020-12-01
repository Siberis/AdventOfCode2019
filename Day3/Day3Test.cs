using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day3
{
    public class Day3Test
    {
        [Fact]
        public void Test0()
        {
            Assert.Equal(6, Day3.Star1(
                "R8,U5,L5,D3".Split(','),
                "U7,R6,D4,L4".Split(',')
                ));
        }
        [Fact]
        public void Test1()
        {
            Assert.Equal(159, Day3.Star1(
                "R75,D30,R83,U83,L12,D49,R71,U7,L72".Split(','),
                "U62,R66,U55,R34,D71,R55,D58,R83".Split(',')
                ));
        }
        [Fact]
        public void Test2()
        {
            Assert.Equal(135, Day3.Star1(
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51".Split(','),
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(',')
                ));
        }
        [Fact]
        public async Task Star1()
        {
            var lines = await ReadUtils.ReadAllLines("./Day3DataStar1.txt");
            Assert.Equal(651, Day3.Star1(lines[0].Split(','), lines[1].Split(',')));
        }

        public void Test4()
        {
            Assert.Equal(30, Day3.Star2(
                "R8,U5,L5,D3".Split(','),
                "U7,R6,D4,L4".Split(',')
                ));
        }
        [Fact]
        public void Test5()
        {
            Assert.Equal(610, Day3.Star2(
                "R75,D30,R83,U83,L12,D49,R71,U7,L72".Split(','),
                "U62,R66,U55,R34,D71,R55,D58,R83".Split(',')
                ));
        }
        [Fact]
        public void Test6()
        {
            Assert.Equal(410, Day3.Star2(
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51".Split(','),
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(',')
                ));
        }
        [Fact]
        public async Task Star2()
        {
            var lines = await ReadUtils.ReadAllLines("./Day3DataStar1.txt");
            Assert.Equal(7534, Day3.Star2(lines[0].Split(','), lines[1].Split(',')));
        }
    }
}
