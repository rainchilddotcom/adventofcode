using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _9
{
    public class Heightmap
    {
        private int[,] map;

        public Heightmap(string input)
        {
            var split = input.Split(Environment.NewLine);

            Width = split[0].Length;
            Height = split.Length;

            map = new int[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    map[x, y] = Convert.ToInt32(split[y][x].ToString());
                }
            }

            CalculateLowPoints();
            CalculateBasins();
        }

        public int RiskLevel { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Point> LowPoints { get; private set; }
        public int LargestBasins { get; private set; }
        public List<List<Point>> Basins { get; private set; }

        public List<Point> CalculateLowPoints()
        {
            LowPoints = new List<Point>();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (IsLowPoint(x, y))
                    {
                        LowPoints.Add(new Point(x, y, map[x, y]));
                    }
                }
            }

            RiskLevel = LowPoints.Sum(p => 1 + p.Z);

            return LowPoints;
        }

        public bool IsLowPoint(int x, int y)
        {
            if (x > 0 && map[x - 1, y] <= map[x, y])
                return false;
            if (x < Width - 1 && map[x + 1, y] <= map[x, y])
                return false;
            if (y > 0 && map[x, y - 1] <= map[x, y])
                return false;
            if (y < Height - 1 && map[x, y + 1] <= map[x, y])
                return false;

            return true;
        }

        public List<List<Point>> CalculateBasins()
        {
            Basins = new List<List<Point>>();

            foreach (var lowPoint in LowPoints)
            {
                Basins.Add(CalculateBasin(lowPoint));
            }

            LargestBasins = Basins
                .OrderByDescending(x => x.Count)
                .Take(3)
                .Select(x => x.Count)
                .Aggregate((a, b) => a * b);

            return Basins;
        }

        public List<Point> CalculateBasin(Point lowPoint)
        {
            var basin = new List<Point>();
            var explored = new bool[Width, Height];
            var scanQueue = new Queue<Coordinate>();
            scanQueue.Enqueue(new Coordinate(lowPoint.X, lowPoint.Y));
            while (scanQueue.Count > 0)
            {
                var coordinate = scanQueue.Dequeue();
                var x = coordinate.X;
                var y = coordinate.Y;
                var z = map[x,y];

                if (!explored[x, y] && z < 9)
                {
                    // we're still inside the basin
                    basin.Add(new Point(x, y, z));
                    explored[x, y] = true;

                    // queue neighbours for exploration
                    if (x > 0)
                        scanQueue.Enqueue(new Coordinate(x - 1, y));
                    if (x < Width -1)
                        scanQueue.Enqueue(new Coordinate(x + 1, y));
                    if (y > 0)
                        scanQueue.Enqueue(new Coordinate(x, y - 1));
                    if (y < Height -1)
                        scanQueue.Enqueue(new Coordinate(x, y + 1));
                }
            }

            return basin;
        }
    }
}
