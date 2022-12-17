namespace _0.Tests
{
    public class NestedListTests
    {
        [Test]
        public void NestedListDecimalToString()
        {
            var inner1 = new NestedList<decimal>(11.1m);
            var inner2 = new NestedList<decimal>(22.2m);
            var outer1 = new NestedList<decimal>(new List<NestedList<decimal>> { inner1, inner2 });

            outer1.ToString()
                .Should().Be("[11.1,22.2]");

            var outer2 = new NestedList<decimal>(33.3m);
            var outer3 = new NestedList<decimal>(new List<NestedList<decimal>> { outer1, outer2 });

            outer3.ToString()
                .Should().Be("[[11.1,22.2],33.3]");
        }

        [Test]
        public void NestedListIntToString()
        {
            var inner1 = new NestedList<int>(11);
            var inner2 = new NestedList<int>(22);
            var outer1 = new NestedList<int>(new List<NestedList<int>> { inner1, inner2 });

            outer1.ToString()
                .Should().Be("[11,22]");

            var inner3 = new NestedList<int>(33);
            var inner4 = new NestedList<int>(44);
            var inner5 = new NestedList<int>(55);

            var outer2 = new NestedList<int>(new List<NestedList<int>> { inner3, inner4, inner5 });
            var outer3 = new NestedList<int>(new List<NestedList<int>> { outer1, outer2 });

            outer3.ToString()
                .Should().Be("[[11,22],[33,44,55]]");
        }

        [Test]
        public void NestedListStringToString()
        {
            var inner1 = new NestedList<string>("foo");
            var inner2 = new NestedList<string>("bar");
            var outer1 = new NestedList<string>(new List<NestedList<string>> { inner1, inner2 });

            outer1.ToString()
                .Should().Be("[foo,bar]");

            var outer2 = new NestedList<string>("baz");
            var outer3 = new NestedList<string>(new List<NestedList<string>> { outer2, outer1 });

            outer3.ToString()
                .Should().Be("[baz,[foo,bar]]");
        }

        [Test]
        [TestCase("[1]")]
        [TestCase("[1,2]")]
        [TestCase("[1,1,3,1,1]")]
        [TestCase("[[1],[2,3,4]]")]
        [TestCase("[[1],4]")]
        [TestCase("[[]]")]
        [TestCase("[1,[2,[3,[4,[5,6,7]]]],8,9]")]
        [TestCase("[[1,9],[8,5]]")]
        [TestCase("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]")]
        [TestCase("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]")]
        [TestCase("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]")]
        public void NestedListIntParser(string input)
        {
            var nestedList = NestedList<int>.Parse(input);
            nestedList.ToString()
                .Should().Be(input);
        }
    }
}
