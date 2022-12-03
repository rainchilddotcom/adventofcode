using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public class Group
    {
        public Group(List<Rucksack> rucksacks)
        {
            Rucksacks = rucksacks;

            Badge = FindBadge(Rucksacks);
            BadgePriority = Item.CalculatePriority(Badge);
        }

        private char FindBadge(List<Rucksack> rucksacks)
        {
            var items1 = rucksacks[0].Items.ToArray();
            var items2 = rucksacks[1].Items.ToArray();
            var items3 = rucksacks[2].Items.ToArray();

            return items1.Intersect(items2).Intersect(items3).Single();
        }

        public List<Rucksack> Rucksacks { get; init; }
        public char Badge { get; init; }
        public int BadgePriority { get; init; }

        public static List<Group> AssignGroups(List<Rucksack> rucksacks)
        {
            return rucksacks
                .Chunk(3)
                .Select(x => new Group(x.ToList()))
                .ToList();
        }
    }
}
