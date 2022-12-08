using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    public abstract class Map<T>
        where T : Point2D
    {
        private readonly T[,] _map;

        public Map(string[] input)
        {
            Width = input[0].Length;
            Height = input.Length;

            _map = new T[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _map[x, y] = ConstructValue(x, y, input[y][x].ToString());
                }
            }
        }

        protected abstract T ConstructValue(int x, int y, string input);

        public int Width { get; init; }
        public int Height { get; init; }

        public T this[int x, int y] { get { return _map[x, y]; } }

        public IEnumerable<T> AsEnumerable()
        {
            for (int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    yield return _map[x, y];
                }
            }
        }
    }
}
