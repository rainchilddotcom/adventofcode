namespace _0
{
    public class DynamicMap<T>
        where T : Point2D
    {
        private readonly Dictionary2D<int, int, T> _map;

        public DynamicMap(Func<int, int, T> constructValue)
        {
            _map = new Dictionary2D<int, int, T>(constructValue);
        }

        public int Width { get { return _map.Width; } }
        public int Height { get { return _map.Height; } }
        public T this[int x, int y] { get { return _map[x, y]; } }

        public IEnumerable<T> AsEnumerable()
        {
            return _map.AsEnumerable();
        }
    }
}
