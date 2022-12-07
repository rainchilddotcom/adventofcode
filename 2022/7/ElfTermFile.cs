namespace _7
{
    public class ElfTermFile
        : ElfTermFileSystemObject
    {
        uint _size;

        public ElfTermFile(string name, uint size)
        {
            Name = name;
            _size = size;
        }

        public override string FileSystemObjectType => "file";

        public override uint Size
        {
            get
            {
                return _size;
            }
        }

        public override string ToString()
        {
            return $"{Indent}- {Name} ({FileSystemObjectType}, size={Size}){Environment.NewLine}";
        }
    }
}
