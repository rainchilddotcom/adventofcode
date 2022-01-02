using System;
using Xunit;

namespace _14.Tests
{
    public class UnitTests
    {
        const string testData = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

        [Fact]
        public void Test1()
        {
            var replicator = new Replicator(testData.Split(Environment.NewLine));
            Assert.Equal("NNCB", replicator.Polymer);

            replicator.Step();
            Assert.Equal("NCNBCHB", replicator.Polymer);

            replicator.Step();
            Assert.Equal("NBCCNBBBCBHCB", replicator.Polymer);

            replicator.Step();
            Assert.Equal("NBBBCNCCNBBNBNBBCHBHHBCHB", replicator.Polymer);

            replicator.Step();
            Assert.Equal("NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB", replicator.Polymer);

            replicator.Step();
            Assert.Equal(97, replicator.Polymer.Length);

            replicator.Step();
            replicator.Step();
            replicator.Step();
            replicator.Step();
            replicator.Step();
            Assert.Equal(3073, replicator.Polymer.Length);

            Assert.Collection(replicator.PolymerMakeup,
                p => Assert.True(p.Key == 'B' && p.Value == 1749),
                p => Assert.True(p.Key == 'N' && p.Value == 865),
                p => Assert.True(p.Key == 'C' && p.Value == 298),
                p => Assert.True(p.Key == 'H' && p.Value == 161)
            );

            Assert.Equal(1588, replicator.Checksum);
        }

        [Fact]
        public void Test2()
        {
            var replicatorV2 = new ReplicatorV2(testData.Split(Environment.NewLine));
            Assert.Collection(replicatorV2.PolymerMakeup,
                p => Assert.True(p.Key == 'N' && p.Value == 2),
                p => Assert.True(p.Key == 'C' && p.Value == 1),
                p => Assert.True(p.Key == 'B' && p.Value == 1)
            );
            Assert.Equal(1, replicatorV2.Checksum);

            replicatorV2.Step();
            Assert.Collection(replicatorV2.PolymerMakeup,
                p => Assert.True(p.Key == 'N' && p.Value == 2),
                p => Assert.True(p.Key == 'C' && p.Value == 2),
                p => Assert.True(p.Key == 'B' && p.Value == 2),
                p => Assert.True(p.Key == 'H' && p.Value == 1)
            );
            Assert.Equal(1, replicatorV2.Checksum);

            replicatorV2.Step();
            Assert.Collection(replicatorV2.PolymerMakeup,
                p => Assert.True(p.Key == 'N' && p.Value == 2),
                p => Assert.True(p.Key == 'C' && p.Value == 4),
                p => Assert.True(p.Key == 'B' && p.Value == 6),
                p => Assert.True(p.Key == 'H' && p.Value == 1)
            );
            Assert.Equal(5, replicatorV2.Checksum);

            replicatorV2.Step();
            Assert.Collection(replicatorV2.PolymerMakeup,
                p => Assert.True(p.Key == 'N' && p.Value == 5),
                p => Assert.True(p.Key == 'C' && p.Value == 5),
                p => Assert.True(p.Key == 'B' && p.Value == 11),
                p => Assert.True(p.Key == 'H' && p.Value == 4)
            );
            Assert.Equal(7, replicatorV2.Checksum);

            replicatorV2.Step();
            Assert.Collection(replicatorV2.PolymerMakeup,
                p => Assert.True(p.Key == 'N' && p.Value == 11),
                p => Assert.True(p.Key == 'C' && p.Value == 10),
                p => Assert.True(p.Key == 'B' && p.Value == 23),
                p => Assert.True(p.Key == 'H' && p.Value == 5)
            );
            Assert.Equal(18, replicatorV2.Checksum);

            for (int i = 5; i <= 10; i++)
                replicatorV2.Step();

            Assert.Collection(replicatorV2.PolymerMakeup,
                p => Assert.True(p.Key == 'N' && p.Value == 865),
                p => Assert.True(p.Key == 'C' && p.Value == 298),
                p => Assert.True(p.Key == 'B' && p.Value == 1749),
                p => Assert.True(p.Key == 'H' && p.Value == 161)
            );

            Assert.Equal(1588, replicatorV2.Checksum);

            for (int i = 11; i <= 40; i++)
                replicatorV2.Step();

            Assert.Equal(2188189693529, replicatorV2.Checksum);
        }
    }
}
