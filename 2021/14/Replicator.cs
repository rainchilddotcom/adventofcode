using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14
{
    public class Replicator
        : ReplicatorBase
    {
        public Replicator(string[] input)
            : base(input)
        {
            Polymer = PolymerTemplate;
        }

        public string Polymer { get; private set; }

        public Dictionary<char, int> PolymerMakeup
        {
            get
            {
                var summary = Polymer
                    .ToCharArray()
                    .GroupBy(c => c)
                    .OrderByDescending(group => group.Count())
                    .ToDictionary(group => group.Key, group => group.Count());

                return summary;
            }
        }

        public override long Checksum
        {
            get
            {
                return PolymerMakeup.Max(x => x.Value) - PolymerMakeup.Min(x => x.Value);
            }
        }

        public override void Step()
        {
            var newPolymer = new StringBuilder();
            newPolymer.Append(Polymer[0]);

            for (int i = 1; i < Polymer.Length; i++)
            {
                Insertions.TryGetValue($"{Polymer[i - 1]}{Polymer[i]}", out var insertion);
                if (!string.IsNullOrWhiteSpace(insertion))
                    newPolymer.Append(insertion);

                newPolymer.Append(Polymer[i]);
            }

            Polymer = newPolymer.ToString();
        }
    }
}