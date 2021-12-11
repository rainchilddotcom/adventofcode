using System;
using System.Threading;
using Xunit;

namespace _5.Tests
{
    public class UnitTests
    {
        string[] input = new string[] {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };

        [Fact]
        public void VerticalVentsExist()
        {
            var field = new HydrothermalVentField(input);
            while (!field.Loaded)
                Thread.Sleep(10);

            Assert.NotNull(field.VentAt(0, 9));
            Assert.NotNull(field.VentAt(1, 9));
            Assert.NotNull(field.VentAt(2, 9));
            Assert.NotNull(field.VentAt(3, 9));
            Assert.NotNull(field.VentAt(4, 9));
            Assert.NotNull(field.VentAt(5, 9));
        }

        [Fact]
        public void HorizontalVentsExist()
        {
            var field = new HydrothermalVentField(input);
            while (!field.Loaded)
                Thread.Sleep(10);

            Assert.NotNull(field.VentAt(9, 4));
            Assert.NotNull(field.VentAt(8, 4));
            Assert.NotNull(field.VentAt(7, 4));
            Assert.NotNull(field.VentAt(6, 4));
            Assert.NotNull(field.VentAt(5, 4));
            Assert.NotNull(field.VentAt(4, 4));
            Assert.NotNull(field.VentAt(3, 4));
        }

        [Fact]
        public void DangerousVentsHorizontalOnly()
        {
            var field = new HydrothermalVentField(input);
            while (!field.Loaded)
                Thread.Sleep(10);

            Assert.Equal(5, field.NumberOfDangerousHorizontalVents);
        }

        [Fact]
        public void DangerousVents()
        {
            var field = new HydrothermalVentField(input);
            while (!field.Loaded)
                Thread.Sleep(10);

            Assert.Equal(12, field.NumberOfDangerousVents);
        }
    }
}
