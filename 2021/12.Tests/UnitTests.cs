using System;
using Xunit;

namespace _12.Tests
{
    public class UnitTests
    {
        readonly string[] _shortInput =
@"start-A
start-b
A-c
A-b
b-d
A-end
b-end".Split(Environment.NewLine);

        readonly string[] _mediumInput =
@"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc".Split(Environment.NewLine);

        readonly string[] _complexInput =
@"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW".Split(Environment.NewLine);

        [Fact]
        public void ParseShortExample()
        {
            var cave = new Cave();
            cave.ParseRooms(_shortInput);

            var paths = cave.CalculatePaths("start", "end");

            Assert.Equal(10, paths.Count);

            Assert.Collection(paths,
                path => Assert.Equal("start,A,b,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,b,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,A,end", path.ToString()),
                path => Assert.Equal("start,b,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,b,A,end", path.ToString()),
                path => Assert.Equal("start,b,end", path.ToString())
            );
        }

        [Fact]
        public void ParseMediumExample()
        {
            var cave = new Cave();
            cave.ParseRooms(_mediumInput);

            var paths = cave.CalculatePaths("start", "end");

            Assert.Equal(19, paths.Count);

            Assert.Collection(paths,
                path => Assert.Equal("start,dc,end", path.ToString()),
                path => Assert.Equal("start,dc,HN,end", path.ToString()),
                path => Assert.Equal("start,dc,HN,kj,HN,end", path.ToString()),
                path => Assert.Equal("start,dc,kj,HN,end", path.ToString()),
                path => Assert.Equal("start,HN,dc,end", path.ToString()),
                path => Assert.Equal("start,HN,dc,HN,end", path.ToString()),
                path => Assert.Equal("start,HN,dc,HN,kj,HN,end", path.ToString()),
                path => Assert.Equal("start,HN,dc,kj,HN,end", path.ToString()),
                path => Assert.Equal("start,HN,end", path.ToString()),
                path => Assert.Equal("start,HN,kj,dc,end", path.ToString()),
                path => Assert.Equal("start,HN,kj,dc,HN,end", path.ToString()),
                path => Assert.Equal("start,HN,kj,HN,dc,end", path.ToString()),
                path => Assert.Equal("start,HN,kj,HN,dc,HN,end", path.ToString()),
                path => Assert.Equal("start,HN,kj,HN,end", path.ToString()),
                path => Assert.Equal("start,kj,dc,end", path.ToString()),
                path => Assert.Equal("start,kj,dc,HN,end", path.ToString()),
                path => Assert.Equal("start,kj,HN,dc,end", path.ToString()),
                path => Assert.Equal("start,kj,HN,dc,HN,end", path.ToString()),
                path => Assert.Equal("start,kj,HN,end", path.ToString())
            );
        }

        [Fact]
        public void ParseComplexExample()
        {
            var cave = new Cave();
            cave.ParseRooms(_complexInput);

            var paths = cave.CalculatePaths("start", "end");

            Assert.Equal(226, paths.Count);
        }

        [Fact]
        public void TakeAShortLeisurelyStroll()
        {
            var cave = new Cave();
            cave.ParseRooms(_shortInput);

            var paths = cave.CalculateLeisurelyStroll("start", "end");

            Assert.Equal(36, paths.Count);

            Assert.Collection(paths,
                path => Assert.Equal("start,A,b,A,b,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,A,b,end", path.ToString()),
                path => Assert.Equal("start,A,b,A,c,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,A,c,A,b,end", path.ToString()),
                path => Assert.Equal("start,A,b,A,c,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,d,b,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,d,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,b,d,b,end", path.ToString()),
                path => Assert.Equal("start,A,b,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,b,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,b,A,b,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,b,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,b,d,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,b,d,b,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,b,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,c,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,c,A,b,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,A,end", path.ToString()),
                path => Assert.Equal("start,b,A,b,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,b,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,b,A,b,end", path.ToString()),
                path => Assert.Equal("start,b,A,c,A,b,A,end", path.ToString()),
                path => Assert.Equal("start,b,A,c,A,b,end", path.ToString()),
                path => Assert.Equal("start,b,A,c,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,b,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,b,A,end", path.ToString()),
                path => Assert.Equal("start,b,d,b,A,c,A,end", path.ToString()),
                path => Assert.Equal("start,b,d,b,A,end", path.ToString()),
                path => Assert.Equal("start,b,d,b,end", path.ToString()),
                path => Assert.Equal("start,b,end", path.ToString())
            );
        }

        [Fact]
        public void TakeAnAmblingLeisurelyStroll()
        {
            var cave = new Cave();
            cave.ParseRooms(_mediumInput);

            var paths = cave.CalculateLeisurelyStroll("start", "end");

            Assert.Equal(103, paths.Count);
        }

        [Fact]
        public void TakeALongLeisurelyStroll()
        {
            var cave = new Cave();
            cave.ParseRooms(_complexInput);

            var paths = cave.CalculateLeisurelyStroll("start", "end");

            Assert.Equal(3509, paths.Count);
        }
    }
}
