using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _15
{
    public class SensorGridLoader
    {
        public SensorGrid LoadSensorGrid(string[] input)
        {
            var sensorGrid = new SensorGrid();

            foreach (var line in input)
            {
                var sensor = ParseSensor(line);
                sensorGrid.Add(sensor);
            }

            return sensorGrid;
        }

        public Sensor ParseSensor(string line)
        {
            var match = Regex.Match(line, @"^Sensor at x=(-?\d+), y=(-?\d+): closest beacon is at x=(-?\d+), y=(-?\d+)");

            if (!match.Success)
                throw new InvalidDataException($"Illegal sensor definition: {line}");

            int sx = int.Parse(match.Groups[1].Value);
            int sy = int.Parse(match.Groups[2].Value);
            int bx = int.Parse(match.Groups[3].Value);
            int by = int.Parse(match.Groups[4].Value);

            var sensor = new Sensor(new Point2D(sx, sy), new Point2D(bx, by));

            return sensor;
        }
    }
}
