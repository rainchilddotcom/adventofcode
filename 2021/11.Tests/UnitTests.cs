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

        [Fact]
        public void TestMiniField()
        {
            var octo314 = new OctoThreePointOneFour("11111\r\n19991\r\n19191\r\n19991\r\n11111");

            octo314.Step();
            Assert.Equal("34543\r\n40004\r\n50005\r\n40004\r\n34543", octo314.Field);

            octo314.Step();
            Assert.Equal("45654\r\n51115\r\n61116\r\n51115\r\n45654", octo314.Field);
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
