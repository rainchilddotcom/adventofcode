using _0;

namespace _15.Tests
{
    public class Day15Tests
    {
        const string testInput =
@"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        [TestCase("Sensor at x=2, y=18: closest beacon is at x=-2, y=15", 2, 18, -2, 15)]
        [TestCase("Sensor at x=-12, y=-418: closest beacon is at x=215, y=-1415", -12, -418, 215, -1415)]
        public void ParseSensors(string sensorDefinition, int sensorX, int sensorY, int beaconX, int beaconY)
        {
            var sensor = new SensorGridLoader().ParseSensor(sensorDefinition);
            sensor.Position.X.Should().Be(sensorX);
            sensor.Position.Y.Should().Be(sensorY);
            sensor.ClosestBeacon.X.Should().Be(beaconX);
            sensor.ClosestBeacon.Y.Should().Be(beaconY);
        }

        [Test]
        [TestCase("Sensor at x=8, y=7: closest beacon is at x=2, y=10", -1, 7, 8, -2, 17, 7, 8, 16)]
        public void SensorPolygon(string sensorDefinition, int p1x, int p1y, int p2x, int p2y, int p3x, int p3y, int p4x, int p4y)
        {
            var sensor = new SensorGridLoader().ParseSensor(sensorDefinition);
            sensor.Polygon.Should().Contain(x => x.Start.X == p1x && x.Start.Y == p1y && x.End.X == p2x && x.End.Y == p2y);
            sensor.Polygon.Should().Contain(x => x.Start.X == p2x && x.Start.Y == p2y && x.End.X == p3x && x.End.Y == p3y);
            sensor.Polygon.Should().Contain(x => x.Start.X == p3x && x.Start.Y == p3y && x.End.X == p4x && x.End.Y == p4y);
            sensor.Polygon.Should().Contain(x => x.Start.X == p4x && x.Start.Y == p4y && x.End.X == p1x && x.End.Y == p1y);
        }

        [Test]
        [TestCase("Sensor at x=8, y=7: closest beacon is at x=2, y=10", -25, 10, 25, 10, 2, 10, 14, 10)]
        [TestCase("Sensor at x=0, y=11: closest beacon is at x=2, y=10", -25, 11, 25, 11, -3, 11, 3, 11)]
        public void SensorLineIntersections(string sensorDefinition, int p1x, int p1y, int p2x, int p2y, int p3x, int p3y, int p4x, int p4y)
        {
            var sensor = new SensorGridLoader().ParseSensor(sensorDefinition);
            var line = new Line(p1x, p1y, p2x, p2y);
            var intersections = sensor.IntersectsWith(line);
            intersections.Count().Should().Be(2);
            intersections.Should().Contain(x => x.X == p3x && x.Y == p3y);
            intersections.Should().Contain(x => x.X == p4x && x.Y == p4y);
        }

        [Test]
        [TestCase("Sensor at x=8, y=7: closest beacon is at x=2, y=10", -25, 10, 25, 10, 12)] // 13
        public void SingleSensorLineCoverage(string sensorDefinition, int p1x, int p1y, int p2x, int p2y, int expectedCoverage)
        {
            var sensorGrid = new SensorGrid();
            sensorGrid.Add(new SensorGridLoader().ParseSensor(sensorDefinition));
            var line = new Line(p1x, p1y, p2x, p2y);
            sensorGrid.CalculateCoverage(line)
                .Should().Be(expectedCoverage);
        }

        [Test]
        [TestCase(-10, -10, 90, -10, 0)] // 1
        [TestCase(-10, -1, 90, -1, 28)]  // 31
        [TestCase(-10, 9, 90, 9, 24)]    // 25
        [TestCase(-10, 10, 90, 10, 26)]  // 27
        [TestCase(-10, 11, 90, 11, 26)]  // 28
        [TestCase(-10, 12, 90, 12, 27)]  // 29
        public void SensorGridLineCoverage(int p1x, int p1y, int p2x, int p2y, int expectedCoverage)
        {
            var sensorGrid = new SensorGridLoader().LoadSensorGrid(input);
            var line = new Line(p1x, p1y, p2x, p2y);
            sensorGrid.CalculateCoverage(line)
                .Should().Be(expectedCoverage);
        }

        [Test]
        public void SensorGridBoundingCoordinates()
        {
            var sensorGrid = new SensorGridLoader().LoadSensorGrid(input);
            sensorGrid.MinX.Should().Be(-8);
            sensorGrid.MinY.Should().Be(-10);
            sensorGrid.MaxX.Should().Be(28);
            sensorGrid.MaxY.Should().Be(26);
        }
    }
}
