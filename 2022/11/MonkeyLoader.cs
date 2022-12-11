using _0;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _11
{
    public class MonkeyLoader
    {
        public MonkeyLoader()
        {
        }

        public List<Monkey> LoadMonkeys(string[] input)
        {
            var monkeyDefs = string.Join(Environment.NewLine, input).Split($"{Environment.NewLine}{Environment.NewLine}");
            var monkeys = new List<Monkey>();

            foreach (var monkeyDef in monkeyDefs)
            {
                monkeys.Add(ParseMonkey(monkeyDef));
            }

            return monkeys;
        }

        public Monkey ParseMonkey(string monkeyDef)
        {
            var match = Regex.Match(monkeyDef, @"^Monkey (\d+):\s*Starting items: (.+)\s*Operation: new = (.+?)\s*Test: divisible by (\d+)\s*If true: throw to monkey (\d+)\s*If false: throw to monkey (\d+)\s*");

            if (!match.Success)
                throw new InvalidDataException($"Illegal monkey definition: {monkeyDef}");

            int id = int.Parse(match.Groups[1].Value);
            var startingItems = new Queue<long>(match.Groups[2].Value.ParseIntList().Select(x => (long)x));
            string operation = match.Groups[3].Value;
            int test = int.Parse(match.Groups[4].Value);
            int throwToIfTrue = int.Parse(match.Groups[5].Value);
            int throwToIfFalse = int.Parse(match.Groups[6].Value);

            var monkey = new Monkey
            {
                Id = id,
                Items = startingItems,
                Operation = operation,
                TestDivisible = test,
                ThrowToIfTrue = throwToIfTrue,
                ThrowToIfFalse = throwToIfFalse,
            };

            return monkey;
        }
    }
}