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
            var outer = new NestedList<int>(new List<NestedList<int>> { inner1, inner2 });

            outer.ToString()
                .Should().Be("[11,22]");
        }

        [Test]
        public void NestedListStringToString()
        {
            var inner1 = new NestedList<string>("foo");
            var inner2 = new NestedList<string>("bar");
            var outer = new NestedList<string>(new List<NestedList<string>> { inner1, inner2 });

            outer.ToString()
                .Should().Be("[foo,bar]");
        }
    }
}
