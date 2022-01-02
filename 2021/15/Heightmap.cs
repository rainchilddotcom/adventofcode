using System;
using System.Linq;

namespace _15
{
    public class Heightmap
    {
        private int[,] _map;

        public Heightmap(string[] input)
        {
            Width = input[0].Length;
            Height = input.Length;

            _map = new int[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _map[x, y] = Convert.ToInt32(input[y][x].ToString());
                }
            }
        }

        private HeightmapExplorer HeightmapExplorer { get; set; }

        public Path SafestPath
        {
            get
            {
                if (HeightmapExplorer == null)
                {
                    HeightmapExplorer = new HeightmapExplorer(this, new Point(0, 0), new Point(Width - 1, Height - 1));
                }

                return HeightmapExplorer.SafestPath;
            }
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public int this[int x, int y] { get { return _map[x, y]; } }

        public void Extrapolate(int horizontalTimes, int verticalTimes)
        {
            var newWidth = Width * horizontalTimes;
            var newHeight = Height * verticalTimes;
            var newMap = new int[newWidth, newHeight];

            for (int dupeY = 0; dupeY < verticalTimes; dupeY++)
            {
                for (int dupeX = 0; dupeX < horizontalTimes; dupeX++)
                {
                    for (int sourceY = 0; sourceY < Height; sourceY++)
                    {
                        for (int sourceX = 0; sourceX < Width; sourceX++)
                        {
                            newMap[dupeX * Width + sourceX, dupeY * Height + sourceY] = WrapValue(_map[sourceX, sourceY] + dupeX + dupeY);
                        }
                    }
                }
            }

            _map = newMap;
            Width = newWidth;
            Height = newHeight;

            int WrapValue(int number)
            {
                if (number > 9)
                    return number -= 9;

                return number;
            }
        }
    }
}