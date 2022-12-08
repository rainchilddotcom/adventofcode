using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    public class Day8
        : Puzzle
    {
        public override string Part1Caption() => "Total Visible Trees";

        public override string Part1Answer()
        {
            var input = LoadInput();
            return new TreeHeightMap(input)
                .TotalVisibleTrees
                .ToString();
        }

        public override string Part2Caption() => "Highest Scenic Score";

        public override string Part2Answer()
        {
            var input = LoadInput();
            return new TreeHeightMap(input)
                .AsEnumerable()
                .OrderByDescending(x => x.ScenicScore)
                .Take(1)
                .Single()
                .ScenicScore
                .ToString();
        }
    }
}
