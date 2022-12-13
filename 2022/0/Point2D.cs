namespace _0
{
    public class Point2D
    {
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public virtual char Placeholder()
        {
            return '#';
        }
    }
}