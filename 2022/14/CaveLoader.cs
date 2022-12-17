using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14
{
    public class CaveLoader
    {
        public Cave LoadCave(string[] input)
        {
            var cave = new Cave();

            foreach (var line in input)
            {
                var points = line.ParsePointList(pointseparator: " -> ");
                Point2D? from = null;
                foreach (var to in points)
                {
                    if (from != null)
                    {
                        for (int x = Math.Min(from.X, to.X); x <= Math.Max(from.X, to.X); x++)
                        {
                            for (int y = Math.Min(from.Y, to.Y); y <= Math.Max(from.Y, to.Y); y++)
                            {
                                cave[x, y].Z = "#";
                            }
                        }
                    }

                    from = to;
                }
            }

            cave.AddSpawner(500, 0);

            return cave;
        }
    }
}
