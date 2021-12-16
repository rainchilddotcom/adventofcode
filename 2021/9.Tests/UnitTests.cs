using System;
using Xunit;

namespace _9.Tests
{
    public class UnitTests
    {
        const string input = 
@"2199943210
3987894921
9856789892
8767896789
9899965678";

        [Fact]
        public void CalculateRiskLevel()
        {
            var heightmap = new Heightmap(input);
            Assert.Equal(15, heightmap.RiskLevel);
        }

        [Fact]
        public void TopThreeBasins()
        {
            var heightmap = new Heightmap(input);
            Assert.Equal(1134, heightmap.LargestBasins);
        }
    }
}
