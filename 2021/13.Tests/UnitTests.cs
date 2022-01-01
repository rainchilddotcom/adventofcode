using System;
using Xunit;

namespace _13.Tests
{
    public class UnitTests
    {
        const string testInput = 
@"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

        const string expectedStartingPaper =
@"...#..#..#.
....#......
...........
#..........
...#....#.#
...........
...........
...........
...........
...........
.#....#.##.
....#......
......#...#
#..........
#.#........";

        const string expectedPaperFold1 =
@"#.##..#..#.
#...#......
......#...#
#...#......
.#.#..#.###
...........
...........";

        const string expectedPaperFold2 =
@"#####
#...#
#...#
#...#
#####
.....
.....";

        [Fact]
        public void PaperCanBeFolded()
        {
            var paper = new Paper(testInput.Split(Environment.NewLine));

            Assert.Equal(18, paper.Dots.Count);
            Assert.Equal(2, paper.Folds.Count);
            Assert.Equal(expectedStartingPaper, paper.ToString());

            paper.Fold();

            Assert.Equal(17, paper.Dots.Count);
            Assert.Single(paper.Folds);
            Assert.Equal(expectedPaperFold1, paper.ToString());

            paper.Fold();

            Assert.Equal(16, paper.Dots.Count);
            Assert.Empty(paper.Folds);
            Assert.Equal(expectedPaperFold2, paper.ToString());

            Assert.Throws<InvalidOperationException>(paper.Fold);
        }

        [Fact]
        public void FoldHorizontal()
        {
            const string testInput = @"1309,892
1309,0
1308,891

fold along y=447";

            var paper = new Paper(testInput.Split(Environment.NewLine));
            paper.Fold();

            Assert.Collection(paper.Dots, 
                dot => Assert.True(1309 == dot.X && 2 == dot.Y && 0 == dot.Layer),
                dot => Assert.True(1309 == dot.X && 0 == dot.Y && 0 == dot.Layer),
                dot => Assert.True(1308 == dot.X && 3 == dot.Y && 0 == dot.Layer)
            );

            Assert.Equal(446, paper.MaxY);
        }

        [Fact]
        public void FoldVertical()
        {
            const string testInput = @"1309,892
0,892
1308,891

fold along x=655";

            var paper = new Paper(testInput.Split(Environment.NewLine));
            paper.Fold();

            Assert.Collection(paper.Dots,
                dot => Assert.True(1 == dot.X && 892 == dot.Y && 0 == dot.Layer),
                dot => Assert.True(0 == dot.X && 892 == dot.Y && 0 == dot.Layer),
                dot => Assert.True(2 == dot.X && 891 == dot.Y && 0 == dot.Layer)
            );

            Assert.Equal(654, paper.MaxX);
        }
    }
}
