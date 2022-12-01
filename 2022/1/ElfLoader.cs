namespace _1
{
    public class ElfLoader
    {
        public List<Elf> LoadElves(string[] input)
        {
            var elves = new List<Elf>();
            var elf = new Elf();
            elves.Add(elf);

            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                {
                    // next elf
                    elf = new Elf();
                    elves.Add(elf);
                }
                else
                {
                    elf.Items.Add(Convert.ToDecimal(line));
                }
            }

            return elves;
        }
    }
}