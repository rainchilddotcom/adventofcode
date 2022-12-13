using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _12
{
    public class Day12
        : Puzzle
    {
        public override string Part1Caption() => "Leisurely Stroll";

        public override string Part1Answer()
        {
            var input = LoadInput();

            var terrain = new TerrainLoader()
                .LoadTerrain(input);

            var explorer = new TerrainExplorer(terrain);
            var path = explorer.FindPath();

            return path.Steps.Count.ToString() + Environment.NewLine + explorer.RenderPath(path.Steps);
        }

        public override string Part2Caption() => "Hiking Is Fun";

        public override string Part2Answer()
        {
            var input = LoadInput();

            var terrain = new TerrainLoader()
                .LoadTerrain(input);

            var explorer = new TerrainExplorer(terrain);
            var path = explorer.FindHike();

            return path.Steps.Count.ToString() + Environment.NewLine + explorer.RenderPath(path.Steps);
        }
    }
}
