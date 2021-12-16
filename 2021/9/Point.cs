namespace _9
{
    public class Point
        : Coordinate
    {
        public Point(int x, int y, int z)
            : base(x,y)
        {
            Z = z;
        }

        public int Z { get; set; }
    }
}
