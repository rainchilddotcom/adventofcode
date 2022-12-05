namespace _5.Tests
{
    public class Day5Tests
    {
        const string testInput =
@"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2
";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void TestPart1()
        {
            var manifest = new SupplyManifestLoader()
                .LoadSupplies(new CrateMover9000(), input);

            manifest.Stacks.Count()
                .Should().Be(3);

            manifest.Moves.Count()
                .Should().Be(4);

            manifest.TopCrates
                .Should().Be("NDP");

            manifest.ProcessMove();
            manifest.TopCrates
                .Should().Be("DCP");

            manifest.ProcessMove();
            manifest.TopCrates
                .Should().Be(" CZ");

            manifest.ProcessMove();
            manifest.TopCrates
                .Should().Be("M Z");

            manifest.ProcessMove();
            manifest.TopCrates
                .Should().Be("CMZ");

            manifest.Moves.Count()
                .Should().Be(0);
        }

        [Test]
        public void TestPart2()
        {
            var manifest = new SupplyManifestLoader()
                .LoadSupplies(new CrateMover9001(), input);

            manifest.Stacks.Count()
                .Should().Be(3);

            manifest.Moves.Count()
                .Should().Be(4);

            manifest.TopCrates
                .Should().Be("NDP");

            manifest.ProcessMove();
            manifest.TopCrates
                .Should().Be("DCP");

            manifest.ProcessMove();
            manifest.TopCrates
                .Should().Be(" CD");

            manifest.ProcessMove();
            manifest.TopCrates
                .Should().Be("C D");

            manifest.ProcessMove();
            manifest.TopCrates
                .Should().Be("MCD");

            manifest.Moves.Count()
                .Should().Be(0);
        }
    }
}