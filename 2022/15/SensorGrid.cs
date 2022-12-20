using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    public class SensorGrid
    {
        public List<Sensor> Sensors { get; } = new List<Sensor>();

        public void Add(Sensor sensor)
        {
            Sensors.Add(sensor);
        }

        public int CalculateCoverage(Line line)
        {
            var lines = new List<Line>();

            foreach (var sensor in Sensors)
            {
                var intersections = sensor.IntersectsWith(line);
                if (intersections.Count == 0)
                    continue;
                else if (intersections.Count == 1)
                    lines.Add(new Line(intersections[0], intersections[0]));
                else
                    lines.Add(new Line(intersections[0], intersections[1]));
            }

            lines = lines
                .OrderBy(x => x.Start.X)
                .ThenBy(x => x.Start.Y)
                .ThenByDescending(x => x.End.X)
                .ThenByDescending(x => x.End.Y)
                .ToList();

            int length = 0;

            Line previous = null;
            foreach (var foo in lines)
            {
                System.Diagnostics.Debug.WriteLine($"Line: {foo.Start.X},{foo.Start.Y}-{foo.End.X},{foo.End.Y}: {foo.Length}");
                if (previous != null)
                {
                    if (Math.Max(foo.Start.X, foo.End.X) <= previous.End.X && Math.Max(foo.Start.Y, foo.End.Y) <= previous.End.Y)
                    {
                        System.Diagnostics.Debug.WriteLine("Skipping fully contained line");
                        continue;
                    }

                    var overlapX = Math.Max(0, Math.Min(previous.End.X, foo.End.X) - Math.Max(previous.Start.X, foo.Start.X));
                    var overlapY = Math.Max(0, Math.Min(previous.End.Y, foo.End.Y) - Math.Max(previous.Start.Y, foo.Start.Y));
                    if (overlapX != 0 || overlapY != 0)
                    {
                        var overlap = new Line(0, 0, (int)overlapX, (int)overlapY);
                        System.Diagnostics.Debug.WriteLine($"Overlap: {overlap.Start.X},{overlap.Start.Y}-{overlap.End.X},{overlap.End.Y}: {overlap.Length}");
                        length += (int)(foo.Length - overlap.Length);
                    }
                    else
                    {
                        length += (int)foo.Length;

                        /*
                         * apparently they didn't want us to count + 1 after all
                        if (foo.Start.X - previous.End.X + foo.Start.Y - previous.End.Y > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("New line, adding 1");
                            length++; // count the point at the start of a new line
                        }
                        */
                    }
                }
                else
                {
                    length += (int)foo.Length;
                    /*
                     * apparently they didn't want us to count + 1 after all
                    // for this puzzle, a length of 2 to 4 = 2 3 4 = length 3
                    System.Diagnostics.Debug.WriteLine("New line, adding 1");
                    length += 1 + (int)foo.Length;
                    */
                }

                previous = foo;
            }

            return length;
        }

        // calculate bounding dimensions
        public double MinX => Sensors.Min(x => x.MinX);
        public double MinY => Sensors.Min(x => x.MinY);
        public double MaxX => Sensors.Max(x => x.MaxX);
        public double MaxY => Sensors.Max(x => x.MaxY);
    }
}
