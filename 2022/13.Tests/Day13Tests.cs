using _0;

namespace _13.Tests
{
    public class Day13Tests
    {
        const string testInput =
@"[1,1,3,1,1]
[1,1,5,1,1]

[[1],[2,3,4]]
[[1],4]

[9]
[[8,7,6]]

[[4,4],4,4]
[[4,4],4,4,4]

[7,7,7,7]
[7,7,7]

[]
[3]

[[[]]]
[[]]

[1,[2,[3,[4,[5,6,7]]]],8,9]
[1,[2,[3,[4,[5,6,0]]]],8,9]";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void LoadPackets()
        {
            var packets = new PacketLoader()
                .LoadPackets(input);

            packets.Count
                .Should().Be(8);

            packets[0].Item1.ToString()
                .Should().Be("[1,1,3,1,1]");
            packets[0].Item2.ToString()
                .Should().Be("[1,1,5,1,1]");
        }

        [Test]
        [TestCase("[]", "[]", 0)]
        [TestCase("[3]", "[3]", 0)]
        [TestCase("[1,1,3,1,1]", "[1,1,5,1,1]", -1)]
        [TestCase("[[1],[2,3,4]]", "[[1],4]", -1)]
        [TestCase("[9]", "[[8,7,6]]", 1)]
        [TestCase("[[4,4],4,4]", "[[4,4],4,4,4]", -1)]
        [TestCase("[7,7,7,7]", "[7,7,7]", 1)]
        [TestCase("[]", "[3]", -1)]
        [TestCase("[3]", "[]", 1)]
        [TestCase("[[[]]]", "[[]]", 1)]
        [TestCase("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", 1)]
        public void ComparePackets(string leftInput, string rightInput, int equality)
        {
            var left = new Packet(NestedList<int>.Parse(leftInput));
            var right = new Packet(NestedList<int>.Parse(rightInput));

            left.CompareTo(right)
                .Should().Be(equality);
        }

        [Test]
        public void CorrectPackets()
        {
            var packets = new PacketLoader()
                .LoadPackets(input);

            var signal = new Signal(packets);
            signal.CorrectPacketNumbers().Sum()
                .Should().Be(13);
        }

        [Test]
        public void DecoderKey()
        {
            var packets = new PacketLoader()
                .LoadPackets(input);

            var signal = new Signal(packets);
            signal.CalculateDecoderKey()
                .Should().Be(140);
        }
    }
}