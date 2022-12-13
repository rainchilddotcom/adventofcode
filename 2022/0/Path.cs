namespace _0
{
    public class Path<T>
        where T: Point2D
    {
        public List<T> Steps { get; init; } = new List<T>();
        public int Cost { get; init; }
    }
}
