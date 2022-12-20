using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    public class Sensor
    {
        public Sensor(Point2D position, Point2D closestBeacon)
        {
            Position = position;
            ClosestBeacon = closestBeacon;
            DistanceFromBeacon = CalculateDistance();
            Polygon = CalculatePolygon();

            // calculate bounding dimensions
            MinX = Polygon.Min(x => Math.Min(x.Start.X, x.End.X));
            MinY = Polygon.Min(x => Math.Min(x.Start.Y, x.End.Y));
            MaxX = Polygon.Max(x => Math.Max(x.Start.X, x.End.X));
            MaxY = Polygon.Max(x => Math.Max(x.Start.Y, x.End.Y));
        }

        private int CalculateDistance()
        {
            return Math.Abs(ClosestBeacon.X - Position.X) + Math.Abs(ClosestBeacon.Y - Position.Y);
        }

        private List<Line> CalculatePolygon()
        {
            var list = new List<Line>();

            list.Add(new Line(Position.X - DistanceFromBeacon, Position.Y, Position.X, Position.Y - DistanceFromBeacon));
            list.Add(new Line(Position.X, Position.Y - DistanceFromBeacon, Position.X + DistanceFromBeacon, Position.Y));
            list.Add(new Line(Position.X + DistanceFromBeacon, Position.Y, Position.X, Position.Y + DistanceFromBeacon));
            list.Add(new Line(Position.X, Position.Y + DistanceFromBeacon, Position.X - DistanceFromBeacon, Position.Y));

            return list;
        }

        public Point2D Position { get; init; }
        public Point2D ClosestBeacon { get; init; }
        public int DistanceFromBeacon { get; init; }
        public List<Line> Polygon { get; init; }

        public List<Point2D<double>> IntersectsWith(Line line)
        {
            var points = Polygon
                .Select(x => x.IntersectWith(line))
                .Where(x => x != null)
                .Distinct()
                .OrderBy(x => x.X)
                .ThenBy(x => x.Y)
                .ToList();

            return points;
        }

        public double MinX { get; init; }
        public double MinY { get; init; }
        public double MaxX { get; init; }
        public double MaxY { get; init; }
    }
}
