using System;
using Xunit;

namespace _15.Tests
{
    public class UnitTests
    {
        const string testInput =
@"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";

        [Fact]
        public void Test1()
        {
            var heightmap = new Heightmap(testInput.Split(Environment.NewLine));

            Assert.Equal(40, heightmap.SafestPath.Danger);
        }

        [Fact]
        public void Test2()
        {
            var heightmap = new Heightmap(testInput.Split(Environment.NewLine));
            heightmap.Extrapolate(5, 5);

            Assert.Equal(315, heightmap.SafestPath.Danger);
        }
    }
}
