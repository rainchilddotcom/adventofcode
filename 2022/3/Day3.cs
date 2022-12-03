using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public class Day3
        : Puzzle
    {
        public override string Part1Answer()
        {
            var rucksacks = new RucksackLoader().LoadRucksacks(LoadInput());

            return rucksacks.Sum(x => x.MisplacedPriority).ToString();
        }

        public override string Part2Answer()
        {
            var rucksacks = new RucksackLoader().LoadRucksacks(LoadInput());
            var groups = Group.AssignGroups(rucksacks);
            
            return groups.Sum(x => x.BadgePriority).ToString();
        }
    }
}
