namespace _7.Tests
{
    public class Day7Tests
    {
        const string testInput =
@"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k
";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void LoadFileStructureFromLog()
        {
            string expectedRepresentation =
@"- / (dir)
  - a (dir)
    - e (dir)
      - i (file, size=584)
    - f (file, size=29116)
    - g (file, size=2557)
    - h.lst (file, size=62596)
  - b.txt (file, size=14848514)
  - c.dat (file, size=8504156)
  - d (dir)
    - j (file, size=4060174)
    - d.log (file, size=8033020)
    - d.ext (file, size=5626152)
    - k (file, size=7214296)
";

            var etfs = new ElfTermFileSystemLoader()
                .Load(input);

            etfs.VisualRepresentation()
                .Should().Be(expectedRepresentation);
        }

        [Test]
        public void PrunableSpace()
        {
            var etfs = new ElfTermFileSystemLoader()
                .Load(input);

            etfs.PrunableSpace()
                .Should().Be(95437);
        }

        [Test]
        public void SmallestPrunableDirectory()
        {
            var etfs = new ElfTermFileSystemLoader()
                .Load(input);

            etfs.SmallestPrunableDirectory()
                .Size.Should().Be(24933642);
        }
    }
}