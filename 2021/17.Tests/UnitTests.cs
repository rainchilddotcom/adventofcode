using System;
using Xunit;

namespace _17.Tests
{
    public class UnitTests
    {
        [Fact]
        public void TargetAreaLoader()
        {
            var targetAreaLoader = new TargetAreaLoader();
            var targetArea = targetAreaLoader.Load("target area: x=20..30, y=-10..-5");

            Assert.Equal(20, targetArea.MinX);
            Assert.Equal(30, targetArea.MaxX);
            Assert.Equal(-10, targetArea.MinY);
            Assert.Equal(-5, targetArea.MaxY);
        }

        [Theory]
        [InlineData(20, -10, true)]
        [InlineData(30, -10, true)]
        [InlineData(20, -5, true)]
        [InlineData(30, -5, true)]
        [InlineData(25, -7, true)]
        [InlineData(19, -7, false)]
        [InlineData(31, -7, false)]
        [InlineData(25, -11, false)]
        [InlineData(25, -4, false)]
        public void WithinTargetArea(int x, int y, bool expected)
        {
            var targetArea = new TargetArea(20, 30, -10, -5);

            Assert.Equal(expected, targetArea.Hit(x, y));
        }

        [Fact]
        public void ProbeMovement()
        {
            var probe = new Probe(7, 2);

            Assert.Equal(0, probe.PositionX);
            Assert.Equal(0, probe.PositionY);
            Assert.Equal(7, probe.VelocityX);
            Assert.Equal(2, probe.VelocityY);

            probe.Step();
            Assert.Equal(7, probe.PositionX);
            Assert.Equal(2, probe.PositionY);
            Assert.Equal(6, probe.VelocityX);
            Assert.Equal(1, probe.VelocityY);

            probe.Step();
            Assert.Equal(13, probe.PositionX);
            Assert.Equal(3, probe.PositionY);
            Assert.Equal(5, probe.VelocityX);
            Assert.Equal(0, probe.VelocityY);

            probe.Step();
            Assert.Equal(18, probe.PositionX);
            Assert.Equal(3, probe.PositionY);
            Assert.Equal(4, probe.VelocityX);
            Assert.Equal(-1, probe.VelocityY);

            probe.Step();
            Assert.Equal(22, probe.PositionX);
            Assert.Equal(2, probe.PositionY);
            Assert.Equal(3, probe.VelocityX);
            Assert.Equal(-2, probe.VelocityY);

            probe.Step();
            Assert.Equal(25, probe.PositionX);
            Assert.Equal(0, probe.PositionY);
            Assert.Equal(2, probe.VelocityX);
            Assert.Equal(-3, probe.VelocityY);

            probe.Step();
            Assert.Equal(27, probe.PositionX);
            Assert.Equal(-3, probe.PositionY);
            Assert.Equal(1, probe.VelocityX);
            Assert.Equal(-4, probe.VelocityY);

            probe.Step();
            Assert.Equal(28, probe.PositionX);
            Assert.Equal(-7, probe.PositionY);
            Assert.Equal(0, probe.VelocityX);
            Assert.Equal(-5, probe.VelocityY);

            probe.Step();
            Assert.Equal(28, probe.PositionX);
            Assert.Equal(-12, probe.PositionY);
            Assert.Equal(0, probe.VelocityX);
            Assert.Equal(-6, probe.VelocityY);

            probe.Step();
            Assert.Equal(28, probe.PositionX);
            Assert.Equal(-18, probe.PositionY);
            Assert.Equal(0, probe.VelocityX);
            Assert.Equal(-7, probe.VelocityY);
        }

        [Theory]
        [InlineData(7, 2, true)]
        [InlineData(6, 3, true)]
        [InlineData(9, 0, true)]
        [InlineData(17, -4, false)]
        public void ProbeHitsTarget(int vx, int vy, bool hits)
        {
            var targetArea = new TargetArea(20, 30, -10, -5);
            var probe = new Probe(vx, vy);

            Assert.Equal(hits, probe.HitsTargetArea(targetArea));
        }

        [Fact]
        public void TrickShotCalcuator()
        {
            var targetArea = new TargetArea(20, 30, -10, -5);
            var trickShotCalculator = new TrickShotCalculator();
            trickShotCalculator.CalculateHighestVerticalVelocity(targetArea, out var vx, out var vy, out var maxy, out var count);

            Assert.Equal(6, vx);
            Assert.Equal(9, vy);
            Assert.Equal(45, maxy);
            Assert.Equal(112, count);
        }
    }
}
