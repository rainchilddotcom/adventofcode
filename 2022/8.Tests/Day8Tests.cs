namespace _8.Tests
{
    public class Day8Tests
    {
        const string testInput =
@"30373
25512
65332
33549
35390";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void TreeHeight()
        {
            var trees = new TreeHeightMap(input);
            trees[0, 0].Z.Should().Be(3);
            trees[1, 0].Z.Should().Be(0);
            trees[2, 0].Z.Should().Be(3);
            trees[3, 0].Z.Should().Be(7);
            trees[4, 0].Z.Should().Be(3);

            trees[0, 1].Z.Should().Be(2);
            trees[1, 1].Z.Should().Be(5);
            trees[2, 1].Z.Should().Be(5);
            trees[3, 1].Z.Should().Be(1);
            trees[4, 1].Z.Should().Be(2);

            trees[0, 2].Z.Should().Be(6);
            trees[1, 2].Z.Should().Be(5);
            trees[2, 2].Z.Should().Be(3);
            trees[3, 2].Z.Should().Be(3);
            trees[4, 2].Z.Should().Be(2);

            trees[0, 3].Z.Should().Be(3);
            trees[1, 3].Z.Should().Be(3);
            trees[2, 3].Z.Should().Be(5);
            trees[3, 3].Z.Should().Be(4);
            trees[4, 3].Z.Should().Be(9);

            trees[0, 4].Z.Should().Be(3);
            trees[1, 4].Z.Should().Be(5);
            trees[2, 4].Z.Should().Be(3);
            trees[3, 4].Z.Should().Be(9);
            trees[4, 4].Z.Should().Be(0);
        }

        [Test]
        public void TotalVisibleTrees()
        {
            new TreeHeightMap(input)
                .TotalVisibleTrees
                .Should().Be(21);
        }

        [Test]
        public void TreeVisibility()
        {
            var trees = new TreeHeightMap(input);

            // row 1
            {
                trees[0, 0]
                    .VisibleFrom
                    .Should().Be(Direction.West | Direction.North);

                trees[1, 0]
                    .VisibleFrom
                    .Should().Be(Direction.North);

                trees[2, 0]
                    .VisibleFrom
                    .Should().Be(Direction.North);

                trees[3, 0]
                    .VisibleFrom
                    .Should().Be(Direction.North | Direction.West | Direction.East);

                trees[4, 0]
                    .VisibleFrom
                    .Should().Be(Direction.North | Direction.East);
            }

            // row 2
            {
                trees[0,1]
                    .VisibleFrom
                    .Should().Be(Direction.West);

                trees[1, 1]
                    .VisibleFrom
                    .Should().Be(Direction.North | Direction.West);

                trees[2, 1]
                    .VisibleFrom
                    .Should().Be(Direction.North | Direction.East);

                trees[3, 1]
                    .VisibleFrom
                    .Should().Be(Direction.None);

                trees[4, 1]
                    .VisibleFrom
                    .Should().Be(Direction.East);
            }

            // row 3
            {
                trees[0, 2]
                    .VisibleFrom
                    .Should().Be(Direction.All);

                trees[1, 2]
                    .VisibleFrom
                    .Should().Be(Direction.East);

                trees[2, 2]
                    .VisibleFrom
                    .Should().Be(Direction.None);

                trees[3, 2]
                    .VisibleFrom
                    .Should().Be(Direction.East);

                trees[4, 2]
                    .VisibleFrom
                    .Should().Be(Direction.East);
            }

            // row 4
            {
                trees[0, 3]
                    .VisibleFrom
                    .Should().Be(Direction.West);

                trees[1, 3]
                    .VisibleFrom
                    .Should().Be(Direction.None);

                trees[2, 3]
                    .VisibleFrom
                    .Should().Be(Direction.South | Direction.West);

                trees[3, 3]
                    .VisibleFrom
                    .Should().Be(Direction.None);

                trees[4, 3]
                    .VisibleFrom
                    .Should().Be(Direction.All);
            }

            // row 5
            {
                trees[0, 4]
                    .VisibleFrom
                    .Should().Be(Direction.South | Direction.West);

                trees[1, 4]
                    .VisibleFrom
                    .Should().Be(Direction.South | Direction.West);

                trees[2, 4]
                    .VisibleFrom
                    .Should().Be(Direction.South);

                trees[3, 4]
                    .VisibleFrom
                    .Should().Be(Direction.All);

                trees[4, 4]
                    .VisibleFrom
                    .Should().Be(Direction.South | Direction.East);
            }
        }

        [Test]
        [TestCase(2, 1, 4)]
        [TestCase(2, 3, 8)]
        public void ScenicScore(int x, int y, int expectedScore)
        {
            new TreeHeightMap(input)[x, y]
                .ScenicScore
                .Should().Be(expectedScore);
        }
    }
}