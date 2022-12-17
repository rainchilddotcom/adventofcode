using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    public class Day14
        : Puzzle
    {
        public override string Part1Caption() => "Total Sand";

        public override string Part1Answer()
        {
            var input = LoadInput();

            var cave = new CaveLoader()
                .LoadCave(input);

            cave.FillCavern();

            return cave.TotalSand.ToString() + Environment.NewLine + cave.RenderMap();
        }

        public override string Part2Caption() => "Total Sand";

        public override string Part2Answer()
        {
            var input = LoadInput();

            var cave = new CaveLoader()
                .LoadCave(input);

            cave.AddFloor();
            cave.FillCavern();

            return cave.TotalSand.ToString() + Environment.NewLine + cave.RenderMap();
        }
    }
}
