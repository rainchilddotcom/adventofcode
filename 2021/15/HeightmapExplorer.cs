using System;
using System.Collections.Generic;
using System.Linq;

namespace _15
{
    public class HeightmapExplorer
    {
        private readonly Heightmap _heightmap;
        private readonly Point _end;

        public HeightmapExplorer(Heightmap heightmap, Point start, Point end)
        {
            _heightmap = heightmap;
            _end = end;

            Explore(start);
        }

        public Path SafestPath { get; private set; }

        public void Explore(Point start)
        {
            var nodesToExplore = new PriorityQueue<Point, int>();
            nodesToExplore.Enqueue(start, 0);

            var costs = new Dictionary<Point, int>()
            {
                { start, 0 }
            };

            var path = new Dictionary<Point, Point>();

            while (nodesToExplore.Count > 0)
            {
                nodesToExplore.TryDequeue(out var current, out var danger);

                if (current.X == _end.X && current.Y == _end.Y)
                {
                    // jerb done
                    SafestPath = new Path(path
                        .Select(kvp => kvp.Value)
                        .ToList(), danger);
                    return;
                }

                // check the neighbours
                var neighbours = PotentialNeighbours(current);
                foreach (var neighbour in neighbours)
                {
                    if (!costs.TryGetValue(neighbour, out var cost))
                        cost = int.MaxValue;

                    if (danger < cost)
                    {
                        // this path is cheaper than the old one, save it
                        path[neighbour] = current;
                        costs[neighbour] = danger;

                        if (!nodesToExplore.ContainsValue(neighbour))
                        {
                            var stepDanger = _heightmap[neighbour.X, neighbour.Y];
                            nodesToExplore.Enqueue(neighbour, danger + stepDanger);
                        }
                    }
                }
            }
        }

        public List<Point> PotentialNeighbours(Point currentPoint)
        {
            var exits = new List<Point>();

            AddNeighbourIfValid(currentPoint.X, currentPoint.Y + 1); // south
            AddNeighbourIfValid(currentPoint.X + 1, currentPoint.Y); // east
            AddNeighbourIfValid(currentPoint.X, currentPoint.Y - 1); // north
            AddNeighbourIfValid(currentPoint.X - 1, currentPoint.Y); // west

            return exits;

            void AddNeighbourIfValid(int destX, int destY)
            {
                if (destX < 0 || destX >= _heightmap.Width)
                    return;

                if (destY < 0 || destY >= _heightmap.Height)
                    return;

                exits.Add(new Point(destX, destY));
            }
        }
    }
}
