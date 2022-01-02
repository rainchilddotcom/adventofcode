using System.Collections.Generic;

namespace _14
{
    public abstract class ReplicatorBase
    {
        public ReplicatorBase(string[] input)
        {
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                else if (line.Contains("->"))
                {
                    var split = line.Split(" -> ");
                    Insertions[split[0]] = split[1];
                }
                else
                {
                    PolymerTemplate = line;
                }
            }
        }

        public virtual string PolymerTemplate { get; }
        public virtual Dictionary<string, string> Insertions { get; } = new Dictionary<string, string>();

        public abstract long Checksum { get; }
        public abstract void Step();
    }
}