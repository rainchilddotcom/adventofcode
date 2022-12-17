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

        public int OffsetX { get { return _map.AsEnumerable().Min(x => x.X); } }
        public int OffsetY { get { return _map.AsEnumerable().Min(y => y.Y); } }

        public int Width { get { return _map.AsEnumerable().Max(x => x.X); } }
        public int Height { get { return _map.AsEnumerable().Max(y => y.Y); } }
        public T this[int x, int y] { get { return _map[x, y]; } }
        
        public void Swap(T source, T target)
        {
            _map[source.X, source.Y] = target;
            _map[target.X, target.Y] = source;

            var sourceX = source.X;
            var sourceY = source.Y;

            source.X = target.X;
            source.Y = target.Y;

            target.X = sourceX;
            target.Y = sourceY;
        }

        public IEnumerable<T> AsEnumerable()
        {
            return _map.AsEnumerable();
        }

        public virtual string RenderMap()
        {
            if (_map.Count == 0)
                return "";

            int minX = OffsetX;
            int minY = OffsetY;
            int maxX = Width + 1;
            int maxY = Height + 1;

            char[,] map = new char[maxX, maxY];

            foreach (var point in _map.AsEnumerable())
            {
                map[point.X, point.Y] = point.Placeholder();
            }

            var mapString = "";

            for (int y = minY; y < maxY; y++)
            {
                for (int x = minX; x < maxX; x++)
                {
                    if (map[x, y] == '\0')
                        map[x, y] = ' ';

                    mapString += map[x, y];
                }
                mapString += Environment.NewLine;
            }

            return mapString;
        }
    }
}
