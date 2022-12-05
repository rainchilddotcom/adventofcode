using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    public class Day5
        : Puzzle
    {
        public override string Part1Caption() => "CrateMover9000";

        public override string Part1Answer()
        {
            var input = LoadInput();
            var manifest = new SupplyManifestLoader()
                .LoadSupplies(new CrateMover9000(), input);

            while (manifest.Moves.Count() > 0)
            {
                manifest.ProcessMove();
            }

            return manifest.TopCrates;
        }

        public override string Part2Caption() => "CrateMover9001";

        public override string Part2Answer()
        {
            var input = LoadInput();
            var manifest = new SupplyManifestLoader()
                .LoadSupplies(new CrateMover9001(), input);

            while (manifest.Moves.Count() > 0)
            {
                manifest.ProcessMove();
            }

            return manifest.TopCrates;
        }
    }
}
