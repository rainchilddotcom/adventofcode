using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    public class Day6
        : Puzzle
    {
        public override string Part1Caption() => "First start-of-packet";

        public override string Part1Answer()
        {
            var input = LoadInput();
            return new RadioSignal(input[0])
                .FirstPacketMarker
                .ToString();
        }

        public override string Part2Caption() => "First start-of-message";

        public override string Part2Answer()
        {
            var input = LoadInput();
            return new RadioSignal(input[0])
                .FirstMessageMarker
                .ToString();
        }
    }
}
