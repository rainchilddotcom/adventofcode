using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _11
{
    public class OctoThreePointOneFour
    {
        private Octopus[,] _field;

        public OctoThreePointOneFour(string input)
        {
            StringToField(input);
            TotalFlashes = 0;
        }

        public string Field { get { return FieldToString(); } }

        private string FieldToString()
        {
            var sb = new StringBuilder();
            var maxX = _field.GetUpperBound(0);
            var maxY = _field.GetUpperBound(1);

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    sb.Append(_field[x, y].ToString());
                }
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }

        private void StringToField(string input)
        {
            var split = input.Split(Environment.NewLine);
            var maxX = split[0].Length - 1;
            var maxY = split.Length - 1;

            _field = new Octopus[maxX + 1, maxY + 1];

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    _field[x, y] = new Octopus(x, y, Convert.ToInt32(split[y][x].ToString()));
                }
            }
        }

        public int TotalFlashes { get; private set; }

        public int Step()
        {
            var maxX = _field.GetUpperBound(0);
            var maxY = _field.GetUpperBound(1);
            
            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    _field[x, y].Step();
                }
            }

            var flasherQueue = new Queue<Octopus>();

            _field.Cast<Octopus>()
                .Where(o => o.Level > 9)
                .ToList()
                .ForEach(o => flasherQueue.Enqueue(o));

            while (flasherQueue.Count > 0)
            {
                var octopus = flasherQueue.Dequeue();
                octopus.Flash();
                PokeNeighbours(octopus, maxX, maxY, flasherQueue);
            }

            var flashed = _field.Cast<Octopus>()
                .Where(o => o.Flashed)
                .ToList();

            TotalFlashes += flashed.Count;
            flashed.ForEach(o => o.Reset());

            return flashed.Count;
        }

        private void PokeNeighbours(Octopus octopus, int maxX, int maxY, Queue<Octopus> flasherQueue)
        {
            var neighbours = OctoUtilities.GetNeighbourXY(octopus.X, octopus.Y, maxX, maxY);
            foreach (var neighbourXY in neighbours)
            {
                var neighbour = _field[neighbourXY.X, neighbourXY.Y];
                neighbour.Step();
                if (neighbour.Level > 9 && neighbour.Flashed == false)
                {
                    if (!flasherQueue.Contains(neighbour))
                    {
                        flasherQueue.Enqueue(neighbour);
                    }
                }
            }
        }
    }
}
