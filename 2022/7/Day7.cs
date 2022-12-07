using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    public class Day7
        : Puzzle
    {
        public override string Part1Caption() => "Naive Prunable Space";

        public override string Part1Answer()
        {
            var input = LoadInput();
            var etfs = new ElfTermFileSystemLoader()
                .Load(input);
            return etfs.PrunableSpace().ToString();
        }

        public override string Part2Caption() => "Smallest Prunable Folder";

        public override string Part2Answer()
        {
            var input = LoadInput();
            var etfs = new ElfTermFileSystemLoader()
                .Load(input);
            var prunable = etfs.SmallestPrunableDirectory();

            return $"name={prunable.Name}, size={prunable.Size}";
        }
    }
}
