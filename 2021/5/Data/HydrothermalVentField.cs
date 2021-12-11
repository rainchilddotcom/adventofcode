using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5
{
    public class HydrothermalVentField
    {
        private List<Line> _lines;
        private ConcurrentBag<Vent> _vents;

        public HydrothermalVentField(string[] input)
        {
            _lines = new InputParser()
                .ParseLines(input);

            Console.WriteLine($"Line count: {_lines.Count}");

            _vents = new ConcurrentBag<Vent>();

            Task.Run(CalculateVentField);
        }

        public void CalculateVentField()
        {
            foreach (var line in _lines)
            {
                Console.WriteLine($"Processing line {line.Start.X},{line.Start.Y} -> {line.End.X},{line.End.Y}");

                if (line.IsHorizontal)
                {
                    int y = line.Start.Y;
                    int start = Math.Min(line.Start.X, line.End.X);
                    int end = Math.Max(line.Start.X, line.End.X);
                    for (int x = start; x <= end; x++)
                    {
                        UpsertVent(x, y, true);
                    }
                }
                else if (line.IsVertical)
                {
                    int x = line.Start.X;
                    int start = Math.Min(line.Start.Y, line.End.Y);
                    int end = Math.Max(line.Start.Y, line.End.Y);
                    for (int y = start; y <= end; y++)
                    {
                        UpsertVent(x, y, true);
                    }
                }
                else
                {
                    int stepx = line.Start.X == line.End.X ? 0 : line.Start.X < line.End.X ? 1 : -1;
                    int stepy = line.Start.Y == line.End.Y ? 0 : line.Start.Y < line.End.Y ? 1 : -1;

                    int x = line.Start.X;
                    int y = line.Start.Y;

                    while (true)
                    {
                        UpsertVent(x, y, false);

                        if (x == line.End.X && y == line.End.Y)
                            break;

                        x += stepx;
                        y += stepy;
                    }
                }
            }

            Console.WriteLine($"Vent count: {NumberOfVents}");
            Console.WriteLine($"Dangerous straight vent count: {NumberOfDangerousHorizontalVents}");
            Console.WriteLine($"Dangerous vent count: {NumberOfDangerousVents}");

            Loaded = true;
        }

        public Coordinate UpsertVent(int x, int y, bool straight)
        {
            var vent = VentAt(x, y);
            if (vent == null)
            {
                vent = new Vent(x, y);
                _vents.Add(vent);
            }

            vent.IncreaseDanger(straight);

            return vent;
        }

        public Vent VentAt(int x, int y)
        {
            return _vents.Where(v => v.X == x && v.Y == y).SingleOrDefault();
        }

        public List<Vent> Vents { get { return _vents.ToList(); } }

        public bool Loaded { get; private set; }
        public int NumberOfLines { get { return _lines.Count; } }
        public int NumberOfVents { get { return _vents.Count; } }
        public int NumberOfDangerousVents { get { return _vents.Count(v => v.Danger > 1); } }
        public int NumberOfDangerousHorizontalVents { get { return _vents.Count(v => v.StraightDanger > 1); } }
    }
}
