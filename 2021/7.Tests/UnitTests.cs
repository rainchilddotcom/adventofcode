using System;
using Xunit;

namespace _7.Tests
{
    public class UnitTests
    {
        [Fact]
        public void MostEfficientPosition()
        {
            string input = "16,1,2,0,4,2,7,1,2,14";

            _7.Program.CalculateMostEfficientPosition(input, out var position, out var fuelCost);

            Assert.Equal(2, position);
            Assert.Equal(37, fuelCost);
        }

        [Fact]
        public void MostEfficientPositionPart2()
        {
            string input = "16,1,2,0,4,2,7,1,2,14";

            _7.Program.CalculateMostEfficientPositionPart2(input, out var position, out var fuelCost);

            Assert.Equal(5, position);
            Assert.Equal(168, fuelCost);
        }
    }
}
