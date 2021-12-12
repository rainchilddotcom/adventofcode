using System;
using Xunit;

namespace _6.Tests
{
    public class UnitTests
    {
        [Fact]
        public void TestThePond()
        {
            var fish = new short[] { 3, 4, 3, 1, 2 };

            var pond = new Pond(fish);

            pond.TimePasses();
            Assert.Equal(5, pond.NumberOfFish);

            pond.TimePasses();
            Assert.Equal(6, pond.NumberOfFish);

            pond.TimePasses();
            Assert.Equal(7, pond.NumberOfFish);

            pond.TimePasses();
            Assert.Equal(9, pond.NumberOfFish);

            for (int i = 4; i < 18; i++)
                pond.TimePasses();

            Assert.Equal(26, pond.NumberOfFish);

            for (int i = 18; i < 80; i++)
                pond.TimePasses();

            Assert.Equal(5934, pond.NumberOfFish);

            for (int i = 80; i < 256; i++)
                pond.TimePasses();

            Assert.Equal(26984457539, pond.NumberOfFish);
        }
    }
}
