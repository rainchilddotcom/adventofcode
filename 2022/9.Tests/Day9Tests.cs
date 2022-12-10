using _0;

namespace _9.Tests
{
    public class Day9Tests
    {
        const string testInput =
@"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        // drag in a single direction
        [TestCase(0, 0, 1, 0, "L 1", -1, 0, 0, 0)]
        [TestCase(0, 0, -1, 0, "R 1", 1, 0, 0, 0)]
        [TestCase(0, 0, 0, 1, "U 1", 0, -1, 0, 0)]
        [TestCase(0, 0, 0, -1, "D 1", 0, 1, 0, 0)]

        // move to overlap
        [TestCase(1, 0, 0, 0, "L 1", 0, 0, 0, 0)]
        [TestCase(0, 0, 1, 0, "R 1", 1, 0, 1, 0)]
        [TestCase(0, 1, 0, 0, "U 1", 0, 0, 0, 0)]
        [TestCase(0, 0, 0, 1, "D 1", 0, 1, 0, 1)]

        // diagonally follow into the correct column
        [TestCase(0, 0, 1, 1, "L 1", -1, 0, 0, 0)]
        [TestCase(0, 0, 1, -1, "L 1", -1, 0, 0, 0)]
        [TestCase(4, -4, 4, -3, "L 1", 3, -4, 4, -3)]
        [TestCase(3, -4, 4, -3, "L 1", 2, -4, 3, -4)]
        [TestCase(1, 0, 0, 1, "R 1", 2, 0, 1, 0)]
        [TestCase(1, 0, 0, -1, "R 1", 2, 0, 1, 0)]
        [TestCase(0, 0, 1, 1, "U 1", 0, -1, 0, 0)]
        [TestCase(0, 0, -1, 1, "U 1", 0, -1, 0, 0)]
        [TestCase(0, 1, 1, 0, "D 1", 0, 2, 0, 1)]
        [TestCase(0, 1, -1, 0, "D 1", 0, 2, 0, 1)]

        public void TestRopeMovementSingleStep(int headX, int headY, int tailX, int tailY, string move, int expectedHeadX, int expectedHeadY, int expectedTailX, int expectedTailY)
        {
            var rope = new Rope(new Point2D(headX, headY), new Point2D(tailX, tailY), 1);
            rope.MoveHead(move);
            rope.Head.Should().BeEquivalentTo(new Point2D(expectedHeadX, expectedHeadY));
            rope.Tail.Should().BeEquivalentTo(new Point2D(expectedTailX, expectedTailY));
        }

        [Test]
        public void TestRopeMovement()
        {
            var rope = new Rope(new Point2D(0, 0), new Point2D(0, 0), 1);

            rope.MoveHead("R 4");
            rope.Head.Should().BeEquivalentTo(new Point2D(4, 0));
            rope.Tail.Should().BeEquivalentTo(new Point2D(3, 0));

            rope.MoveHead("U 4");
            rope.Head.Should().BeEquivalentTo(new Point2D(4, -4));
            rope.Tail.Should().BeEquivalentTo(new Point2D(4, -3));

            rope.MoveHead("L 3");
            rope.Head.Should().BeEquivalentTo(new Point2D(1, -4));
            rope.Tail.Should().BeEquivalentTo(new Point2D(2, -4));

            rope.MoveHead("D 1");
            rope.Head.Should().BeEquivalentTo(new Point2D(1, -3));
            rope.Tail.Should().BeEquivalentTo(new Point2D(2, -4));

            rope.MoveHead("R 4");
            rope.Head.Should().BeEquivalentTo(new Point2D(5, -3));
            rope.Tail.Should().BeEquivalentTo(new Point2D(4, -3));

            rope.MoveHead("D 1");
            rope.Head.Should().BeEquivalentTo(new Point2D(5, -2));
            rope.Tail.Should().BeEquivalentTo(new Point2D(4, -3));

            rope.MoveHead("L 5");
            rope.Head.Should().BeEquivalentTo(new Point2D(0, -2));
            rope.Tail.Should().BeEquivalentTo(new Point2D(1, -2));

            rope.MoveHead("R 2");
            rope.Head.Should().BeEquivalentTo(new Point2D(2, -2));
            rope.Tail.Should().BeEquivalentTo(new Point2D(1, -2));
        }

        [Test]
        public void TestTailVisits()
        {
            var ropeMapper = new RopeMapper();
            ropeMapper.ProcessMoveList(input);

            ropeMapper.Rope.Head.Should().BeEquivalentTo(new Point2D(2, -2));
            ropeMapper.Rope.Tail.Should().BeEquivalentTo(new Point2D(1, -2));

            ropeMapper.Map
                .AsEnumerable()
                .Where(position => position.Z > 0)
                .Count()
                .Should().Be(13);
        }

        [Test]
        public void TestLongRopeMovement()
        {
            var rope = new Rope(new Point2D(0, 0), new Point2D(0, 0), 10);

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(1, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(2, 0),
                new Point2D(1, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(3, 0),
                new Point2D(2, 0),
                new Point2D(1, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(4, 0),
                new Point2D(3, 0),
                new Point2D(2, 0),
                new Point2D(1, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("U 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(4, -1),
                new Point2D(3, 0),
                new Point2D(2, 0),
                new Point2D(1, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("U 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(4, -2),
                new Point2D(4, -1),
                new Point2D(3, -1),
                new Point2D(2, -1),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("U 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(4, -3),
                new Point2D(4, -2),
                new Point2D(3, -1),
                new Point2D(2, -1),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("U 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(4, -4),
                new Point2D(4, -3),
                new Point2D(4, -2),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("L 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(3, -4),
                new Point2D(4, -3),
                new Point2D(4, -2),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("L 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(2, -4),
                new Point2D(3, -4),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("L 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(1, -4),
                new Point2D(2, -4),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("D 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(1, -3),
                new Point2D(2, -4),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(2, -3),
                new Point2D(2, -4),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(3, -3),
                new Point2D(2, -4),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(4, -3),
                new Point2D(3, -3),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(5, -3),
                new Point2D(4, -3),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("D 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(5, -2),
                new Point2D(4, -3),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("L 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(4, -2),
                new Point2D(4, -3),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("L 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(3, -2),
                new Point2D(4, -3),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("L 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(2, -2),
                new Point2D(3, -2),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("L 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(1, -2),
                new Point2D(2, -2),
                new Point2D(3, -3),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("L 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(0, -2),
                new Point2D(1, -2),
                new Point2D(2, -2),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(1, -2),
                new Point2D(1, -2),
                new Point2D(2, -2),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });

            rope.MoveHead("R 1");
            rope.Body.Should().BeEquivalentTo(new[] {
                new Point2D(2, -2),
                new Point2D(1, -2),
                new Point2D(2, -2),
                new Point2D(3, -2),
                new Point2D(2, -2),
                new Point2D(1, -1),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
                new Point2D(0, 0),
            });
        }

        [Test]
        public void TestLongRopeTailVisits()
        {
            var ropeMapper = new RopeMapper(10);
            ropeMapper.ProcessMoveList(input);

            ropeMapper.Rope.Head.Should().BeEquivalentTo(new Point2D(2, -2));
            ropeMapper.Rope.Tail.Should().BeEquivalentTo(new Point2D(0, 0));

            ropeMapper.Map
                .AsEnumerable()
                .Where(position => position.Z > 0)
                .Count()
                .Should().Be(1);
        }

        private string[] largeInput { get { return
@"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20".Split(Environment.NewLine); } }


        [Test]
        public void TestLongRopeLargeExample()
        {
            var ropeMapper = new RopeMapper(10);
            ropeMapper.ProcessMoveList(largeInput);

            ropeMapper.Rope.Head.Should().BeEquivalentTo(new Point2D(-11, -15));
            ropeMapper.Rope.Tail.Should().BeEquivalentTo(new Point2D(-11, -6));

            ropeMapper.Map
                .AsEnumerable()
                .Where(position => position.Z > 0)
                .Count()
                .Should().Be(36);
        }
    }
}