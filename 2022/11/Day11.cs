using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    public class Day11
        : Puzzle
    {
        public override string Part1Caption() => "Monkey Business";

        public override string Part1Answer()
        {
            var input = LoadInput();

            var monkeys = new MonkeyLoader()
                .LoadMonkeys(input);

            for (int i = 0; i < 20; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.TakeTurn(monkeys, false);
                }
            }

            return monkeys
                .OrderByDescending(x => x.Inspections)
                .Take(2)
                .Select(x => x.Inspections)
                .Aggregate(1, (x, y) => x * y)
                .ToString();
        }

        public override string Part2Caption() => "Monkey Sadness";

        public override string Part2Answer()
        {
            var input = LoadInput();

            var monkeys = new MonkeyLoader()
                .LoadMonkeys(input);

            for (int i = 0; i < 10000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.TakeTurn(monkeys, true);
                }
            }

            return monkeys
                .OrderByDescending(x => x.Inspections)
                .Take(2)
                .Select(x => (long)x.Inspections)
                .Aggregate(1, (long x, long y) => x * y)
                .ToString();
        }
    }
}
