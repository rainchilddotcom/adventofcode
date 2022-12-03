using FluentAssertions;
using NUnit.Framework;

namespace _1.Tests
{
    public class DayOneTests
    {
        const string testInput =
@"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

        private List<Elf> LoadTestElves()
        {
            return new ElfLoader().LoadElves(testInput.Split(Environment.NewLine));
        }

        [Test]
        public void LoadElvesWithInventory()
        {
            var elf1 = new Elf
            {
                Items = new List<decimal>() { 1000, 2000, 3000 }
            };

            var elf2 = new Elf
            {
                Items = new List<decimal>() { 4000 }
            };

            var elf3 = new Elf
            {
                Items = new List<decimal>() { 5000, 6000 }
            };

            var elf4 = new Elf
            {
                Items = new List<decimal>() { 7000, 8000, 9000 }
            };

            var elf5 = new Elf
            {
                Items = new List<decimal>() { 10000 }
            };

            var expectedElves = new List<Elf>() { elf1, elf2, elf3, elf4, elf5 };
            var actualElves = LoadTestElves();

            actualElves.Should().BeEquivalentTo(expectedElves);
        }

        [Test]
        public void FindElfWithMostCalories()
        {
            var expedition = new Expedition(LoadTestElves());
            expedition
                .ElfWithMostCalories
                .TotalCalories
                .Should().Be(24000);
        }

        [Test]
        public void FindTopThreeElvesWithMostCalories()
        {
            var expedition = new Expedition(LoadTestElves());
            expedition
                .ElvesWithMostCalories(3)
                .Sum(x => x.TotalCalories)
                .Should().Be(45000);
        }
    }
}