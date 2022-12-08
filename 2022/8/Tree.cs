using _0;

namespace _8
{
    public class Tree
        : Point3D
    {
        public Tree(int x, int y, int z)
            : base(x, y, z)
        {
        }

        public bool Visible
        {
            get
            {
                return VisibleFrom != Direction.None;
            }
        }

        public Direction VisibleFrom { get; set; }
        public int ScenicScore { get; set; }
    }
}
