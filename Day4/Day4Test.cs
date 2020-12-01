using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Day4
{
    public class Day4Test
    {
        [Fact]
        public void Star1()
        {
            Assert.Equal(594, Day4.Star1(347312, 805915));
        }
        [Fact]
        public void Star2()
        {
            Assert.Equal(196, Day4.Star2(347312, 805915));
        }
    }
}
