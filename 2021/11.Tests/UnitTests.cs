using System;
using Xunit;

namespace _11.Tests
{
    public class UnitTests
    {
        const string input = 
@"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

        const string step1 =
@"6594254334
3856965822
6375667284
7252447257
7468496589
5278635756
3287952832
7993992245
5957959665
6394862637";

        const string step2 =
@"8807476555
5089087054
8597889608
8485769600
8700908800
6600088989
6800005943
0000007456
9000000876
8700006848";

        const string step100 =
@"0397666866
0749766918
0053976933
0004297822
0004229892
0053222877
0532222966
9322228966
7922286866
6789998766";

        const string miniInput = @"11111
19991
19191
19991
11111";

        const string miniStep1 = @"34543
40004
50005
40004
34543";

        const string miniStep2 = @"45654
51115
61116
51115
45654";

        [Fact]
        public void TestMiniField()
        {
            var octo314 = new OctoThreePointOneFour(miniInput);

            octo314.Step();
            Assert.Equal(miniStep1, octo314.Field);

            octo314.Step();
            Assert.Equal(miniStep2, octo314.Field);
        }

        [Fact]
        public void TestPartOne()
        {
            var octo314 = new OctoThreePointOneFour(input);

            octo314.Step();
            Assert.Equal(step1, octo314.Field);

            octo314.Step();
            Assert.Equal(step2, octo314.Field);

            for (int i = 2; i < 100; i++)
                octo314.Step();

            Assert.Equal(step100, octo314.Field);

            Assert.Equal(1656, octo314.TotalFlashes);
        }

        [Fact]
        public void TestStringUtilities()
        {
            var octo314 = new OctoThreePointOneFour(input);
            Assert.Equal(input, octo314.Field);
        }

        [Fact]
        public void TestNeighbourXY()
        {
            var neighbours00 = OctoUtilities.GetNeighbourXY(0, 0, 5, 5);
            Assert.Collection(neighbours00,
                neighbour => Assert.True(neighbour.X == 1 && neighbour.Y == 0),
                neighbour => Assert.True(neighbour.X == 0 && neighbour.Y == 1),
                neighbour => Assert.True(neighbour.X == 1 && neighbour.Y == 1)
            );

            var neighbours33 = OctoUtilities.GetNeighbourXY(3, 3, 5, 5);
            Assert.Collection(neighbours33,
                neighbour => Assert.True(neighbour.X == 2 && neighbour.Y == 2),
                neighbour => Assert.True(neighbour.X == 3 && neighbour.Y == 2),
                neighbour => Assert.True(neighbour.X == 4 && neighbour.Y == 2),
                neighbour => Assert.True(neighbour.X == 2 && neighbour.Y == 3),
                neighbour => Assert.True(neighbour.X == 4 && neighbour.Y == 3),
                neighbour => Assert.True(neighbour.X == 2 && neighbour.Y == 4),
                neighbour => Assert.True(neighbour.X == 3 && neighbour.Y == 4),
                neighbour => Assert.True(neighbour.X == 4 && neighbour.Y == 4)
            );

            var neighbours55 = OctoUtilities.GetNeighbourXY(5, 5, 5, 5);
            Assert.Collection(neighbours55,
                neighbour => Assert.True(neighbour.X == 4 && neighbour.Y == 4),
                neighbour => Assert.True(neighbour.X == 5 && neighbour.Y == 4),
                neighbour => Assert.True(neighbour.X == 4 && neighbour.Y == 5)
            );
        }
    }
}
