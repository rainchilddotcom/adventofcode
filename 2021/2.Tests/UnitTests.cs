using System;
using System.Collections.Generic;
using Xunit;

namespace _2.Tests
{
    public class UnitTests
    {
        [Fact]
        public void TestPart1()
        {
            var input = new List<string>() {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };

            var result = _2.Program.Part1(input);

            Assert.Equal(150, result);
        }

        [Fact]
        public void TestPart2()
        {
            var input = new List<string>() {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };

            var result = _2.Program.Part2(input);

            Assert.Equal(900, result);
        }
    }
}
