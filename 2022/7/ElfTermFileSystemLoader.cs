namespace _7
{
    public class ElfTermFileSystemLoader
    {
        public ElfTermFileSystem Load(string[] input)
        {
            var etfs = new ElfTermFileSystem();
            var currentDirectory = etfs.RootDirectory;

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("$ cd"))
                {
                    // change directory...
                    string name = line.Substring(5);
                    if (name == "/")
                    {
                        currentDirectory = etfs.RootDirectory;
                    }
                    else if (name == "..")
                    {
                        currentDirectory = currentDirectory.Parent;
                    }
                    else
                    {
                        currentDirectory = currentDirectory.Objects
                            .OfType<ElfTermDirectory>()
                            .Where(x => x.Name == name)
                            .Single();
                    }
                }
                else if (line == "$ ls")
                {
                    // theoretically we'll be getting a list of files and folders next, don't actually need to worry about this command
                }
                else if (line.StartsWith("dir"))
                {
                    // directory object
                    var directory = new ElfTermDirectory(line.Substring(4));

                    if (currentDirectory == null)
                        throw new Exception($"directory exists without directory: {line}");

                    currentDirectory.AddObject(directory);
                }
                else
                {
                    // file object
                    var split = line.Split(' ');
                    if (split.Length != 2)
                        throw new FormatException($"could not parse file object: {line}");

                    var size = uint.Parse(split[0]);
                    var name = split[1];

                    var file = new ElfTermFile(name, size);

                    if (currentDirectory == null)
                        throw new Exception($"file exists without directory: {line}");

                    currentDirectory.AddObject(file);
                }
            }

            return etfs;
        }
    }
}