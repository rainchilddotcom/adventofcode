using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    public class MapExplorer<T>
        where T: Point2D
    {
        private readonly Map<T> _heightMap;

        public MapExplorer(Map<T> heightMap)
        {
            _heightMap = heightMap;
        }

        public void Explore(Point2D start, Func<Point2D, bool> visitFunction)
        {
            var visited = new bool[_heightMap.Width, _heightMap.Height];
            var nodesToExplore = new Queue<Point2D>();
            nodesToExplore.Enqueue(start);

            while (nodesToExplore.Count > 0)
            {
                var current = nodesToExplore.Dequeue();

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
    }
}
