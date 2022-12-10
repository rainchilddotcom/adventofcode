namespace _0.Tests
{
    public class DynamicMapTests
    {
        const string testInput =
@"30373
25512
65332
33549
35390";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void MapDimensions()
        {
            var map = new DynamicMap<Point3D>((x,y) => new Point3D(x,y,0));
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    map[x, y].Z = input[y][x];
                }
            }

            map.Width.Should().Be(5);
            map.Height.Should().Be(2);
        }
    }
}
