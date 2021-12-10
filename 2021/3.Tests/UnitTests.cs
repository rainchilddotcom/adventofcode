using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _3.Tests
{
    public class UnitTests
    {
        readonly List<DiagnosticFlags> diagnostics = new List<int>() {
                0b00100,
                0b11110,
                0b10110,
                0b10111,
                0b10101,
                0b01111,
                0b00111,
                0b11100,
                0b10000,
                0b11001,
                0b00010,
                0b01010
            }.Cast<DiagnosticFlags>().ToList();

        [Fact]
        public void TestPart1()
        {
            var result = _3.Program.Part1(diagnostics, DiagnosticFlags.Flag5);

            Assert.Equal(198, result);
        }

        [Fact]
        public void TestPart2()
        {
            var result = _3.Program.Part2(diagnostics, DiagnosticFlags.Flag5);

            Assert.Equal(230, result);
        }

        [Fact]
        public void TestPart2Oxygen()
        {
            var result = _3.Program.CalculateRating(diagnostics, DiagnosticFlags.Flag5, _3.Program.Oxygen);

            Assert.Equal(23, (int) result);
        }

        [Fact]
        public void TestPart2CO2()
        {
            var result = _3.Program.CalculateRating(diagnostics, DiagnosticFlags.Flag5, _3.Program.CO2);

            Assert.Equal(10, (int)result);
        }
    }
}
