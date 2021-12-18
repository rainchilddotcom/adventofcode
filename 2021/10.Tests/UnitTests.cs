using System;
using System.Linq;
using Xunit;

namespace _10.Tests
{
    public class UnitTests
    {
        readonly string[] lines =
@"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]"
    .Split(Environment.NewLine);

        [Fact]
        public void IdentifyCorruption()
        {
            var parser = new Parser(lines);
            Assert.Equal(26397, parser.SyntaxErrorScore);
        }

        [Fact]
        public void LineZeroIsIncomplete()
        {
            var parser = new Parser(lines);
            var line = parser.Lines[0];
            Assert.True(line.Incomplete);
            Assert.Equal('[', line.Chunks[0].StartChar);
            Assert.Equal('(', line.Chunks[1].StartChar);
            Assert.Equal('{', line.Chunks[2].StartChar);
            Assert.Equal('(', line.Chunks[3].StartChar);
            Assert.Equal('<', line.Chunks[4].StartChar);
            Assert.Equal('(', line.Chunks[5].StartChar);
            Assert.Equal('(', line.Chunks[6].StartChar);
            Assert.Equal(')', line.Chunks[6].EndChar);
            Assert.Equal(')', line.Chunks[5].EndChar);

            Assert.Equal("}}]])})]", line.Autocompletion);
            Assert.Equal(288957, line.AutocompletionScore);

            // []>[[{[]{<()<>>
        }

        [Fact]
        public void LineTwoIsCorrupt()
        {
            var parser = new Parser(lines);
            Assert.Equal(1197, parser.Lines[2].CorruptionScore);
        }

        [Fact]
        public void ThereAreFiveIncompleteLines()
        {
            var parser = new Parser(lines);

            Assert.True(parser.Lines[0].Incomplete);
            Assert.True(parser.Lines[1].Incomplete);
            Assert.True(parser.Lines[3].Incomplete);
            Assert.True(parser.Lines[6].Incomplete);
            Assert.True(parser.Lines[9].Incomplete);

            Assert.Equal(5, parser.Lines.Where(x => x.Incomplete).Count());
        }

        [Fact]
        public void AutocompletionScoreIsCorrect()
        {
            var parser = new Parser(lines);
            Assert.Equal(288957, parser.MiddleAutocompletionScore);
        }
    }
}
