using System.Numerics;

namespace _11
{
    public class Monkey
    {
        public int Id { get; init; }
        public string Operation { get; init; }
        public int TestDivisible { get; init; }
        public int ThrowToIfTrue { get; init; }
        public int ThrowToIfFalse { get; init; }
        public int Inspections { get; private set; }
        public Queue<long> Items { get; init; } = new Queue<long>();

        public void TakeTurn(List<Monkey> monkeys, bool panicking)
        {
            var moduolo = monkeys
                .Select(x => x.TestDivisible)
                .Aggregate(1, (x, y) => x * y);

            while (Items.Count > 0)
            {
                var worry = Items.Dequeue();
                worry = CalculateWorryLevel(Operation, worry);
                if (!panicking)
                    worry = worry / 3;
                else
                    worry = worry % moduolo;

                if (worry % TestDivisible == 0)
                    monkeys[ThrowToIfTrue].Catch(worry);
                else
                    monkeys[ThrowToIfFalse].Catch(worry);
                Inspections++;
            }
        }

        public void Catch(long item)
        {
            Items.Enqueue(item);
        }

        public static long CalculateWorryLevel(string operation, long old)
        {
            var equation = operation.Replace("old", old.ToString()).Split(' ');

            var left = long.Parse(equation[0]);
            char op = equation[1][0];
            var right = long.Parse(equation[2]);

            switch (op)
            {
                case '+':
                    return left + right;
                case '*':
                    return left * right;
                case '-':
                    return left - right;
                case '/':
                    return left / right;
                default:
                    throw new ArgumentException($"Unknown equation: {equation}");
            }
        }
    }
}
