using System;
using Xunit;
using FluentAssertions;

namespace _18.Tests
{
    public class UnitTests
    {
        [Fact]
        public void SnailfishNumbersArePairs()
        {
            var n = new SnailfishNumber(1, 2);
            n.X.Should().BeEquivalentTo(1);
            n.Y.Should().BeEquivalentTo(2);
        }

        [Fact]
        public void SnailfishNumbersContainSnailfishNumbers()
        {
            var n1 = new SnailfishNumber(new SnailfishNumber(1, 2), 3);
            n1.X.X.Should().BeEquivalentTo(1);
            n1.X.Y.Should().BeEquivalentTo(2);
            n1.Y.Should().BeEquivalentTo(3);

            var n2 = new SnailfishNumber(9, new SnailfishNumber(8, 7));
            n2.X.Should().BeEquivalentTo(9);
            n2.Y.X.Should().BeEquivalentTo(8);
            n2.Y.Y.Should().BeEquivalentTo(7);

            var n3 = new SnailfishNumber(new SnailfishNumber(1, 9), new SnailfishNumber(8, 5));
            n3.X.X.Should().BeEquivalentTo(1);
            n3.X.Y.Should().BeEquivalentTo(9);
            n3.Y.X.Should().BeEquivalentTo(8);
            n3.Y.Y.Should().BeEquivalentTo(5);
        }

        [Fact]
        public void SnailfishNumbersToString()
        {
            var n = new SnailfishNumber(1, 2);
            n.ToString().Should().Be("[1,2]");

            var n1 = new SnailfishNumber(new SnailfishNumber(1, 2), 3);
            n1.ToString().Should().Be("[[1,2],3]");

            var n2 = new SnailfishNumber(9, new SnailfishNumber(8, 7));
            n2.ToString().Should().Be("[9,[8,7]]");

            var n3 = new SnailfishNumber(new SnailfishNumber(1, 9), new SnailfishNumber(8, 5));
            n3.ToString().Should().Be("[[1,9],[8,5]]");
        }

        [Theory]
        [InlineData("[1,2]")]
        [InlineData("[[1,2],3]")]
        [InlineData("[9,[8,7]]")]
        [InlineData("[[1,9],[8,5]]")]
        [InlineData("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]")]
        [InlineData("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]")]
        [InlineData("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]")]
        public void SnailfishIO(string input)
        {
            var parser = new SnailfishNumberParser();
            var snailfishNumber = parser.Parse(input);

            snailfishNumber.ToString().Should().Be(input);
        }

        [Theory]
        [InlineData("[[1,2],[[3,4],5]]", "[1,2]", "[[3,4],5]")]
        [InlineData("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", "[[[[4,3],4],4],[7,[[8,4],9]]]", "[1,1]")]
        [InlineData("[[[[1,1],[2,2]],[3,3]],[4,4]]", "[1,1]", "[2, 2]", "[3, 3]", "[4, 4]")]
        [InlineData("[[[[3,0],[5,3]],[4,4]],[5,5]]", "[1,1]", "[2, 2]", "[3, 3]", "[4, 4]", "[5,5]")]
        [InlineData("[[[[5,0],[7,4]],[5,5]],[6,6]]", "[1,1]", "[2, 2]", "[3, 3]", "[4, 4]", "[5,5]", "[6,6]")]
        [InlineData("[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]", "[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]", "[7,[[[3, 7],[4, 3]],[[6, 3],[8, 8]]]]")]

        [InlineData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 
            "[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]", 
            "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]", 
            "[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]", 
            "[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]", 
            "[7,[5,[[3,8],[1,4]]]]", 
            "[[2,[2,2]],[8,[8,1]]]", 
            "[2,9]", 
            "[1,[[[9,3],9],[[9,0],[0,7]]]]",
            "[[[5,[7,4]],7],1]", 
            "[[[[4,2],2],6],[8,7]]")]
        public void SnailfishCanAdd(string expected, params string[] numbers)
        {
            var parser = new SnailfishNumberParser();
            var reducer = new SnailfishReducer();

            var number = parser.Parse(numbers[0]);
            for (int i = 1; i < numbers.Length; i++)
            {
                number = new SnailfishNumber(number, parser.Parse(numbers[i]));
                reducer.ReduceAll(number);
            }

            number.ToString().Should().Be(expected);
        }

        [Theory]
        [InlineData("[[[[[9,8],1],2],3],4]", "[[[[0,9],2],3],4]")]
        [InlineData("[7,[6,[5,[4,[3,2]]]]]", "[7,[6,[5,[7,0]]]]")]
        [InlineData("[[6,[5,[4,[3,2]]]],1]", "[[6,[5,[7,0]]],3]")]
        [InlineData("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
        [InlineData("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
        public void SnailfishCanExplode(string before, string after)
        {
            var parser = new SnailfishNumberParser();
            var reducer = new SnailfishReducer();

            var n = parser.Parse(before);
            reducer.ReduceOnce(n);

            n.ToString().Should().Be(after);
        }

        [Theory]
        [InlineData("[10,0]", "[[5,5],0]")]
        [InlineData("[11,0]", "[[5,6],0]")]
        [InlineData("[12,0]", "[[6,6],0]")]
        [InlineData("[[10,0],0]", "[[[5,5],0],0]")]
        [InlineData("[[0,11],0]", "[[0,[5,6]],0]")]
        [InlineData("[0,[0,12]]", "[0,[0,[6,6]]]")]
        public void SnailfishCanSplit(string before, string after)
        {
            var parser = new SnailfishNumberParser();
            var reducer = new SnailfishReducer();

            var n = parser.Parse(before);
            reducer.ReduceOnce(n);

            n.ToString().Should().Be(after);
        }

        [Theory]
        [InlineData(29, "[9,1]")]
        [InlineData(143, "[[1,2],[[3,4],5]]")]
        [InlineData(3488, "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")]
        public void TeachersOnlyCheckMagnitude(int expectedMagnitude, string number)
        {
            var parser = new SnailfishNumberParser();
            var n = parser.Parse(number);
            n.Magnitude.Should().Be(expectedMagnitude);
        }

        [Fact]
        public void ExampleHomework()
        {
            var parser = new SnailfishNumberParser();
            var reducer = new SnailfishReducer();

            var number = parser.Parse("[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]");
            number = new SnailfishNumber(number, parser.Parse("[[[5,[2, 8]], 4],[5,[[9,9],0]]]"));
            reducer.ReduceAll(number);
            number = new SnailfishNumber(number, parser.Parse("[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]"));
            reducer.ReduceAll(number);
            number = new SnailfishNumber(number, parser.Parse("[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]"));
            reducer.ReduceAll(number);
            number = new SnailfishNumber(number, parser.Parse("[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]"));
            reducer.ReduceAll(number);
            number = new SnailfishNumber(number, parser.Parse("[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]"));
            reducer.ReduceAll(number);
            number = new SnailfishNumber(number, parser.Parse("[[[[5,4],[7,7]],8],[[8,3],8]]"));
            reducer.ReduceAll(number);
            number = new SnailfishNumber(number, parser.Parse("[[9,3],[[9,9],[6,[4,9]]]]"));
            reducer.ReduceAll(number);
            number = new SnailfishNumber(number, parser.Parse("[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]"));
            reducer.ReduceAll(number);
            number = new SnailfishNumber(number, parser.Parse("[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]"));
            reducer.ReduceAll(number);

            number.ToString().Should().Be("[[[[6,6],[7,6]],[[7,7],[7,0]]],[[[7,7],[7,7]],[[7,8],[9,9]]]]");
            number.Magnitude.Should().Be(4140);
        }
    }
}
