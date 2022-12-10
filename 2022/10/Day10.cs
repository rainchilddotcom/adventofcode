using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    public class Day10
        : Puzzle
    {
        public override string Part1Caption() => "Signal Strength";

        public override string Part1Answer()
        {
            var input = LoadInput();
            var cpu = new ElfCpu(input);
            cpu.Run();
            return cpu.AutoSampleX.ToString();
        }

        public override string Part2Caption() => "Screen";

        public override string Part2Answer()
        {
            var input = LoadInput();
            var cpu = new ElfCpu(input);
            cpu.Run();
            return cpu.RenderDisplay();
        }
    }
}
