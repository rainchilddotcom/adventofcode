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
                .ToList();

            return points;
        }
    }
}
