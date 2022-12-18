namespace _0.Tests
{
    public class LineTests
    {
        [Test]
        [TestCase(0, 0, 1, 0, 1)]
        [TestCase(0, 0, 2, 0, 2)]
        [TestCase(1, 1, 2, 2, 1.414214)]
        public void Length(int startX, int startY, int endX, int endY, double expectedLength)
        {
            var line = new Line(startX, startY, endX, endY);
            line.Length
                .Should().BeApproximately(expectedLength, 4);
        }

        [Test]
        [TestCase(-1, 0, 1, 0, 0, -1, 0, 1, true, 0, 0)]
        [TestCase(-2, 0, 2, 0, 1, -1, 1, 1, true, 1, 0)]
        [TestCase(-2, 0, 2, 0, 5, -1, 5, 1, false, 0, 0)]
        [TestCase(-2, 0, 2, 0, 5, 1, -5, 1, false, 0, 0)]
        public void IntersectsWith(int line1StartX, int line1StartY, int line1EndX, int line1EndY, int line2StartX, int line2StartY, int line2EndX, int line2EndY, bool shouldIntersect, double expectedX, double expectedY)
        {
            var line1 = new Line(line1StartX, line1StartY, line1EndX, line1EndY);
            var line2 = new Line(line2StartX, line2StartY, line2EndX, line2EndY);

            var intersection = line1.IntersectWith(line2);
            if (shouldIntersect)
            {
                intersection.Should().NotBeNull();
                intersection.X.Should().Be((int)expectedX);
                intersection.Y.Should().Be((int)expectedY);
            }
            else
            {
                intersection.Should().BeNull();
            }
        }
    }
}
