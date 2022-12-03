using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public class RucksackLoader
    {
        public List<Rucksack> LoadRucksacks(string[] input)
        {
            var rucksacks = new List<Rucksack>();
            
            foreach (var ruck in input)
            {
                rucksacks.Add(new Rucksack(ruck));
            }

            return rucksacks;
            
        }
    }
}
