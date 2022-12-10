using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    public class Day9
        : Puzzle
    {
        public override string Part1Caption() => "Tail Visits";

        public override string Part1Answer()
        {
            var input = LoadInput();

            var ropeMapper = new RopeMapper();
            ropeMapper.ProcessMoveList(input);

            return ropeMapper.Map
                .AsEnumerable()
                .Where(position => position.Z > 0)
                .Count()
                .ToString();
        }

        public override string Part2Caption() => "Tail Visits (Long)";

        public override string Part2Answer()
        {
            var input = LoadInput();

            var ropeMapper = new RopeMapper(10);
            ropeMapper.ProcessMoveList(input);

            return ropeMapper.Map
                .AsEnumerable()
                .Where(position => position.Z > 0)
                .Count()
                .ToString();
        }
    }
}
