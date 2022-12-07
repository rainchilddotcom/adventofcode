namespace _7
{
    public abstract class ElfTermFileSystemObject
    {
        public string Name { get; set; }
        public abstract string FileSystemObjectType { get; }
        public abstract uint Size { get; }
        public ElfTermDirectory Parent { get; set; }

        public string Indent
        {
            get
            {
                string indent = "";
                var parent = Parent;
                while (parent != null)
                {
                    indent += "  ";
                    parent = parent.Parent;
                }
                return indent;
            }
        }
    }
}