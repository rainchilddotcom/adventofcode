using System.Text;

namespace _7
{
    public class ElfTermDirectory
        : ElfTermFileSystemObject
    {
        public ElfTermDirectory(string name)
        {
            Name = name;
        }

        public override string FileSystemObjectType => "dir";
        public List<ElfTermFileSystemObject> Objects { get; init; } = new List<ElfTermFileSystemObject>();
        public override uint Size
        {
            get
            {
                uint size = 0;
                foreach (var o in Objects)
                {
                    size += o.Size;
                }
                return size;
            }
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Indent}- {Name} ({FileSystemObjectType})");

            foreach (var o in Objects)
            {
                sb.Append(o.ToString());
            }

            return sb.ToString();
        }

        public void AddObject(ElfTermFileSystemObject etfso)
        {
            etfso.Parent = this;
            Objects.Add(etfso);
        }

        public IEnumerable<ElfTermFileSystemObject> Find(Func<ElfTermFileSystemObject, bool> predicate)
        {
            return Objects
                .Where(predicate)
                .ToList();
        }
    }
}