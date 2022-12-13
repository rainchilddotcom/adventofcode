using _0;
using _12;

namespace _12.Tests
{
    public class Day12Tests
    {
        const string testInput =
@"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void FindPath()
        {
            var terrain = new TerrainLoader()
                .LoadTerrain(input);

            var explorer = new TerrainExplorer(terrain);
            explorer.FindPath().Steps.Count
                .Should().Be(31);
        }

        [Test]
        public void FindHike()
        {
            var terrain = new TerrainLoader()
                .LoadTerrain(input);

            var explorer = new TerrainExplorer(terrain);
            explorer.FindHike().Steps.Count
                .Should().Be(29);
        }

        [Test]
        [TestCase(0, 0, "S", 0, 1, "a", 1)]
        [TestCase(0, 0, "S", 0, 1, "b", 1)]
        [TestCase(0, 0, "a", 0, 1, "a", 1)]
        [TestCase(0, 0, "a", 0, 1, "b", 1)]
        [TestCase(0, 0, "a", 0, 1, "c", MapExplorer<PointAlpha>.MaxValue)]
        [TestCase(0, 0, "b", 0, 1, "a", 1)]
        [TestCase(0, 0, "c", 0, 1, "a", 1)]
        [TestCase(0, 0, "x", 0, 1, "E", MapExplorer<PointAlpha>.MaxValue)]
        [TestCase(0, 0, "y", 0, 1, "E", 1)]
        [TestCase(0, 0, "z", 0, 1, "E", 1)]
        public void TestCosts(int fromX, int fromY, string fromZ, int toX, int toY, string toZ, int expectedCost)
        {
            var from = new PointAlpha(fromX, fromY, fromZ);
            var to = new PointAlpha(toX, toY, toZ);

            var terrain = new TerrainLoader()
                .LoadTerrain(input);

            new TerrainExplorer(terrain)
                .MovementCost(from, to)
                .Should().Be(expectedCost);
        }
    }
}