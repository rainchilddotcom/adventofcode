namespace _11.Tests
{
    public class Day11Tests
    {
        const string testInput =
@"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1
";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void ParseMonkey()
        {
            var monkey = new MonkeyLoader().ParseMonkey(
@"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3");

            monkey.Id.Should().Be(0);
            monkey.Items.Should().Equal(79, 98);
            monkey.Operation.Should().Be("old * 19");
            monkey.TestDivisible.Should().Be(23);
            monkey.ThrowToIfTrue.Should().Be(2);
            monkey.ThrowToIfFalse.Should().Be(3);
        }

        [Test]
        [TestCase("old * 19", 79, 1501)]
        [TestCase("old + 6", 54, 60)]
        [TestCase("old * old", 79, 6241)]
        [TestCase("old - 6", 54, 48)]
        [TestCase("old / 2", 54, 27)]
        public void MonkeyMath(string operation, int old, int expected)
        {
            Monkey.CalculateWorryLevel(operation, old).Should().Be(expected);
        }

        [Test]
        public void MonkeyRound()
        {
            var monkeys = new MonkeyLoader().LoadMonkeys(input);

            monkeys[0].TakeTurn(monkeys, false);
            monkeys[0].Items.Should().BeEmpty();
            monkeys[3].Items.Should().Equal(74, 500, 620);

            monkeys[1].TakeTurn(monkeys, false);
            monkeys[1].Items.Should().BeEmpty();
            monkeys[0].Items.Should().Equal(20, 23, 27, 26);

            monkeys[2].TakeTurn(monkeys, false);
            monkeys[2].Items.Should().BeEmpty();
            monkeys[1].Items.Should().Equal(2080);
            monkeys[3].Items.Should().Equal(74, 500, 620, 1200, 3136);

            monkeys[3].TakeTurn(monkeys, false);
            monkeys[3].Items.Should().BeEmpty();
            monkeys[1].Items.Should().Equal(2080, 25, 167, 207, 401, 1046);
        }

        [Test]
        public void MonkeyGame()
        {
            var monkeys = new MonkeyLoader().LoadMonkeys(input);

            for (int i = 0; i < 20; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.TakeTurn(monkeys, false);
                }
            }

            monkeys[0].Items.Should().Equal(10, 12, 14, 26, 34);
            monkeys[1].Items.Should().Equal(245, 93, 53, 199, 115);
            monkeys[2].Items.Should().BeEmpty();
            monkeys[3].Items.Should().BeEmpty();

            monkeys[0].Inspections.Should().Be(101);
            monkeys[1].Inspections.Should().Be(95);
            monkeys[2].Inspections.Should().Be(7);
            monkeys[3].Inspections.Should().Be(105);
        }

        [Test]
        public void NotHavingFun()
        {
            var monkeys = new MonkeyLoader().LoadMonkeys(input);

            foreach (var monkey in monkeys)
            {
                monkey.TakeTurn(monkeys, true);
            }

            monkeys[0].Inspections.Should().Be(2);
            monkeys[1].Inspections.Should().Be(4);
            monkeys[2].Inspections.Should().Be(3);
            monkeys[3].Inspections.Should().Be(6);

            for (int i = 1; i < 20; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.TakeTurn(monkeys, true);
                }
            }

            monkeys[0].Inspections.Should().Be(99);
            monkeys[1].Inspections.Should().Be(97);
            monkeys[2].Inspections.Should().Be(8);
            monkeys[3].Inspections.Should().Be(103);

            for (int i = 20; i < 1000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.TakeTurn(monkeys, true);
                }
            }

            monkeys[0].Inspections.Should().Be(5204);
            monkeys[1].Inspections.Should().Be(4792);
            monkeys[2].Inspections.Should().Be(199);
            monkeys[3].Inspections.Should().Be(5192);

            for (int i = 1000; i < 2000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.TakeTurn(monkeys, true);
                }
            }

            monkeys[0].Inspections.Should().Be(10419);
            monkeys[1].Inspections.Should().Be(9577);
            monkeys[2].Inspections.Should().Be(392);
            monkeys[3].Inspections.Should().Be(10391);

            for (int i = 2000; i < 10000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.TakeTurn(monkeys, true);
                }
            }

            monkeys[0].Inspections.Should().Be(52166);
            monkeys[1].Inspections.Should().Be(47830);
            monkeys[2].Inspections.Should().Be(1938);
            monkeys[3].Inspections.Should().Be(52013);
        }
    }
}