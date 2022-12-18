namespace _0
{
    public class Point2D<T>
    {
        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X { get; set; }
        public T Y { get; set; }

        public virtual char Placeholder()
        {
            return '#';
        }
    }

    public class Point2D
        : Point2D<int>
    {
        public Point2D(int x, int y)
            : base(x, y)
        {
        }
    }
}
