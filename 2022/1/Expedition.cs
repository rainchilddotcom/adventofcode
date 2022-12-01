namespace _1
{
    public class Expedition
    {
        public List<Elf> Elves { get; set; }

        public Expedition(List<Elf> elves)
        {
            Elves = elves;
        }

        public Elf ElfWithMostCalories
        {
            get
            {
                return Elves
                    .OrderByDescending(elf => elf.TotalCalories)
                    .First();
            }
        }

        public List<Elf> ElvesWithMostCalories(int limit)
        {
            return Elves
                .OrderByDescending(elf => elf.TotalCalories)
                .Take(limit)
                .ToList();
        }
    }
}