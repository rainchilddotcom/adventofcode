namespace _0.Tests
{
    public class HeightMapTests
    {
        const string testInput =
@"30373
25512
65332
33549
35390";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void HeightMapCoordinates()
        {
            var heightMap = new HeightMap(input);

            heightMap[0, 0].Z.Should().Be(3);
            heightMap[1, 0].Z.Should().Be(0);
            heightMap[2, 0].Z.Should().Be(3);
            heightMap[3, 0].Z.Should().Be(7);
            heightMap[4, 0].Z.Should().Be(3);

            heightMap[0, 1].Z.Should().Be(2);
            heightMap[1, 1].Z.Should().Be(5);
            heightMap[2, 1].Z.Should().Be(5);
            heightMap[3, 1].Z.Should().Be(1);
            heightMap[4, 1].Z.Should().Be(2);

            heightMap[0, 2].Z.Should().Be(6);
            heightMap[1, 2].Z.Should().Be(5);
            heightMap[2, 2].Z.Should().Be(3);
            heightMap[3, 2].Z.Should().Be(3);
            heightMap[4, 2].Z.Should().Be(2);

            heightMap[0, 3].Z.Should().Be(3);
            heightMap[1, 3].Z.Should().Be(3);
            heightMap[2, 3].Z.Should().Be(5);
            heightMap[3, 3].Z.Should().Be(4);
            heightMap[4, 3].Z.Should().Be(9);

            heightMap[0, 4].Z.Should().Be(3);
            heightMap[1, 4].Z.Should().Be(5);
            heightMap[2, 4].Z.Should().Be(3);
            heightMap[3, 4].Z.Should().Be(9);
            heightMap[4, 4].Z.Should().Be(0);
        }

        [Test]
        public void ScanHeightMap()
        {
            var heightMap = new HeightMap(input);
            var heightMapExplorer = new MapExplorer<Point3D>(heightMap);

            var visited = new int[heightMap.Width, heightMap.Height];

            heightMapExplorer.Explore(new Point2D(0, 0), point =>
            {
                visited[point.X, point.Y]++;
                return true;
            });

            for (int y = 0; y < heightMap.Height; y++)
            {
                for (int x = 0; x < heightMap.Width; x++)
                {
                    visited[x, y].Should().Be(1);
                }
            }
        }
    }
}
