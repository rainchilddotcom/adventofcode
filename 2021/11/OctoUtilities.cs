using System;
using System.Collections.Generic;
using System.Text;

namespace _11
{
    public static class OctoUtilities
    {
        public static List<(int X, int Y)> GetNeighbourXY(int x, int y, int maxX, int maxY)
        {
            var neighbours = new List<(int X, int Y)>();

            for (int ny = y - 1; ny <= y + 1; ny++)
            {
                for (int nx = x - 1; nx <= x + 1; nx++)
                {
                    if (nx == x && ny == y)
                    {
                        continue;
                    }

                    if (nx >= 0 && nx <= maxX && ny >= 0 && ny <= maxY)
                    {
                        neighbours.Add((nx, ny));
                    }
                }
            }

            return neighbours;
        }
    }
}
