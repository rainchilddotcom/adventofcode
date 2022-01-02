using System.Collections.Generic;
using System.Linq;

namespace _14
{
    public class ReplicatorV2
        : ReplicatorBase
    {
        public ReplicatorV2(string[] input)
            : base(input)
        {
            IncrementValue(PolymerMakeup, PolymerTemplate[0], 1);

            for (int i = 1; i < PolymerTemplate.Length; i++)
            {
                IncrementValue(PolymerMakeup, PolymerTemplate[i], 1);
                IncrementValue(PolymerPairs, $"{PolymerTemplate[i - 1]}{PolymerTemplate[i]}", 1);
            }
        }

        public Dictionary<string, long> PolymerPairs { get; private set; } = new Dictionary<string, long>();
        public Dictionary<char, long> PolymerMakeup { get; private set; } = new Dictionary<char, long>();

        public override long Checksum
        {
            get
            {
                return PolymerMakeup.Max(x => x.Value) - PolymerMakeup.Min(x => x.Value);
            }
        }

        private void IncrementValue<TKey>(Dictionary<TKey, long> dictionary, TKey key, long increment)
        {
            dictionary.TryGetValue(key, out var currentCount);
            dictionary[key] = currentCount + increment;
        }

        public override void Step()
        {
            var newPolymerPairs = new Dictionary<string, long>();

            foreach (var pair in PolymerPairs)
            {
                Insertions.TryGetValue(pair.Key, out var insertion);
                if (!string.IsNullOrWhiteSpace(insertion))
                {
                    // the old pair becomes two new pairs
                    var pair1 = $"{pair.Key[0]}{insertion}";
                    var pair2 = $"{insertion}{pair.Key[1]}";

                    IncrementValue(newPolymerPairs, pair1, pair.Value);
                    IncrementValue(newPolymerPairs, pair2, pair.Value);

                    IncrementValue(PolymerMakeup, insertion[0], pair.Value);
                }
                else
                {
                    // no insertion required
                    IncrementValue(newPolymerPairs, pair.Key, pair.Value);
                }
            }

            PolymerPairs = newPolymerPairs;
        }
    }
}