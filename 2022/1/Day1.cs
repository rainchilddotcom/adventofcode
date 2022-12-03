using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class Day1
        : Puzzle
    {
        public override string Part1Caption() => "Calories Carried (top 1)";

        public override string Part1Answer()
        {
            var expedition = new Expedition(new ElfLoader().LoadElves(LoadInput()));
            return expedition.ElfWithMostCalories.TotalCalories.ToString();
        }

        public override string Part2Caption() => "Calories Carried (top 3)";

        public override string Part2Answer()
        {
            var expedition = new Expedition(new ElfLoader().LoadElves(LoadInput()));
            return expedition.ElvesWithMostCalories(3).Sum(x => x.TotalCalories).ToString();
        }
    }
}
