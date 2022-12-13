using System.Linq;

namespace _0
{
    public class MapExplorer<T>
        where T: Point2D
    {
        protected readonly Map<T> _heightMap;

        public MapExplorer(Map<T> heightMap)
        {
            _heightMap = heightMap;
        }

        public void Explore(T start, Func<T, bool> visitFunction)
        {
            var visited = new bool[_heightMap.Width, _heightMap.Height];
            var nodesToExplore = new Queue<Point2D>();
            nodesToExplore.Enqueue(start);

            while (nodesToExplore.Count > 0)
            {
                var currentPoint = nodesToExplore.Dequeue();
                var current = _heightMap[currentPoint.X, currentPoint.Y];

                if (visited[current.X, current.Y])
                    continue;

                if (!visitFunction(current))
                    return;

                visited[current.X, current.Y] = true;

                if (current.X > 0)
                {
                    // explore west neighbour
                    nodesToExplore.Enqueue(new Point2D(current.X - 1, current.Y));
                }

                if (current.X < _heightMap.Width - 1)
                {
                    // explore east neighbour
                    nodesToExplore.Enqueue(new Point2D(current.X + 1, current.Y));
                }

                if (current.Y > 0)
                {
                    // explore north neighbour
                    nodesToExplore.Enqueue(new Point2D(current.X, current.Y - 1));
                }

                if (current.Y < _heightMap.Height - 1)
                {
                    // explore north neighbour
                    nodesToExplore.Enqueue(new Point2D(current.X, current.Y + 1));
                }
            }
        }

        public delegate int CostFunction(T current, T neighbour);
        public delegate bool EndFunction(T current);
        public const int MaxValue = 123456789;

        public Path<T> FindPath(T start, EndFunction endFunction, CostFunction costFunction)
        {
            var nodesToExplore = new PriorityQueue<T, int>();
            nodesToExplore.Enqueue(start, 0);

            var costs = new Dictionary<T, int>() { { start, 0 } };
            var path = new Dictionary<T, T>();

            while (nodesToExplore.Count > 0)
            {
                nodesToExplore.TryDequeue(out var current, out var pathCost);

                if (endFunction(current))
                {
                    // jerb done, retrace our steps to get the final path
                    var finalPath = new Stack<T>();
                    do
                    {
                        finalPath.Push(current);
                        current = path[current];
                    }
                    while (current != start);

                    return new Path<T>
                    {
                        Steps = finalPath.ToList(),
                        Cost = pathCost
                    };
                }

                // check the neighbours
                var neighbours = new List<T>();
                if (current.X > 0)
                {
                    // west neighbour
                    neighbours.Add(_heightMap[current.X - 1, current.Y]);
                }

                if (current.X < _heightMap.Width - 1)
                {
                    // east neighbour
                    neighbours.Add(_heightMap[current.X + 1, current.Y]);
                }

                if (current.Y > 0)
                {
                    // north neighbour
                    neighbours.Add(_heightMap[current.X, current.Y - 1]);
                }

                if (current.Y < _heightMap.Height - 1)
                {
                    // north neighbour
                    neighbours.Add(_heightMap[current.X, current.Y + 1]);
                }

                foreach (var neighbour in neighbours)
                {
                    if (!costs.TryGetValue(neighbour, out var neighbourCost))
                        neighbourCost = MaxValue;

                    var stepCost = costFunction != null ? costFunction(current, neighbour) : 1;
                    if (stepCost != MaxValue && pathCost + stepCost < neighbourCost)
                    {
                        // this path is cheaper than the old one, save it
                        path[neighbour] = current;
                        costs[neighbour] = pathCost;

                        if (!nodesToExplore.UnorderedItems.Any(x => x.Element == neighbour))
                        {
                            nodesToExplore.Enqueue(neighbour, pathCost + stepCost);
                        }
                    }
                }
            }

            throw new Exception("Could not find path");
        }

        public string RenderPath(IEnumerable<T> path)
        {
            if (path.Count() == 0)
                return "";

            int maxX = path.Max(step => step.X) + 1;
            int maxY = path.Max(step => step.Y) + 1;

            char[,] map = new char[maxX, maxY];

            foreach (var step in path)
            {
                map[step.X, step.Y] = step.Placeholder();
            }

            var pathString = "";

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (map[x, y] == '\0')
                        map[x, y] = ' ';

                    pathString += map[x, y];
                }
                pathString += Environment.NewLine;
            }

            return pathString;
        }
    }
}
