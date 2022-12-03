using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public class Rucksack
    {
        public Rucksack(string items)
        {
            Items = items;
            Compartment1 = items.Substring(0, items.Length / 2);
            Compartment2 = items.Substring(items.Length / 2);
            MispackedItem = Compartment1.ToArray().Where(x => Compartment2.Contains(x)).First();
            MisplacedPriority = Item.CalculatePriority(MispackedItem);
        }

        public string Items { get; init; }
        public string Compartment1 { get; init; }
        public string Compartment2 { get; init; }
        public char MispackedItem { get; init; }
        public int MisplacedPriority { get; init; }
    }
}
