using _0;
using System.Text.RegularExpressions;

namespace _5
{
    public partial class SupplyManifest
    {
        private readonly Crane _crane;

        public SupplyManifest(Crane crane)
        {
            _crane = crane;
        }

        public Dictionary<int, Stack<string>> Stacks { get; init; } = new Dictionary<int, Stack<string>>();

        public Stack<string> Moves { get; init; } = new Stack<string>();

        public string TopCrates
        {
            get
            {
                string topCrates = "";
                foreach (var stack in Stacks)
                {
                    if (stack.Value.Count == 0)
                    {
                        topCrates += " ";
                    }
                    else
                    {
                        topCrates += stack.Value.Peek();
                    }
                }
                return topCrates;
            }
        }

        public void ProcessMove()
        {
            var move = Moves.Pop();
            var match = Regex.Match(move, @"move (\d+) from (\d+) to (\d+)");
            if (!match.Success)
                throw new InvalidDataException($"Illegal move entry: {move}");

            int quantity = int.Parse(match.Groups[1].Value);
            int fromStack = int.Parse(match.Groups[2].Value);
            int toStack = int.Parse(match.Groups[3].Value);

            _crane.ProcessMove(this, quantity, fromStack, toStack);
        }
    }
}
