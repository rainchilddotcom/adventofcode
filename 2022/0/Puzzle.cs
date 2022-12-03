namespace _0
{
    public abstract class Puzzle
    {
        public abstract string Part1Caption();
        public abstract string Part1Answer();

        public abstract string Part2Caption();
        public abstract string Part2Answer();

        public string[] LoadInput()
        {
            var assembly = this.GetType().Assembly;

            using Stream fileStream = assembly.GetManifestResourceStream(assembly.GetManifestResourceNames().First(x => x.EndsWith("input.txt")));
            using StreamReader reader = new StreamReader(fileStream);

            var lines = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines.ToArray();
        }
    }
}