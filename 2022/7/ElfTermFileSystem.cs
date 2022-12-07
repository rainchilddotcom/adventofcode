namespace _7
{
    public class ElfTermFileSystem
    {
        public ElfTermDirectory RootDirectory { get; set; } = new ElfTermDirectory("/");

        public string VisualRepresentation()
        {
            return RootDirectory.ToString();
        }

        public uint PrunableSpace()
        {
            var prunable = new DirectoryCrawler(RootDirectory)
                .Find(x => x.Size <= 100000);

            return (uint)prunable
                .Sum(x => x.Size);
        }

        public ElfTermDirectory SmallestPrunableDirectory()
        {
            var freeSpace = 70000000 - RootDirectory.Size;
            var requiredSpace = 30000000 - freeSpace;

            var prunable = new DirectoryCrawler(RootDirectory)
                .Find(x => x.Size >= requiredSpace)
                .OfType<ElfTermDirectory>()
                .OrderBy(x => x.Size)
                .First();

            return prunable;
        }
    }
}