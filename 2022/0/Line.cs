using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    public class Line
    {
        public Line(Point2D<double> start, Point2D<double> end)
        {
            Start = start;
            End = end;
        }

        public Line(int p1x, int p1y, int p2x, int p2y)
        {
            Start = new Point2D<double>(p1x, p1y);
            End = new Point2D<double>(p2x, p2y);
        }

        public Point2D<double> Start { get; }
        public Point2D<double> End { get; }

        public double Length
        {
            get
            {
                return Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2));
            }
        }

        public Point2D<double>? IntersectWith(Line otherLine)
        {
            // see https://en.wikipedia.org/wiki/Line%E2%80%93line_intersection
            try
            {
                var t = ((this.Start.X - otherLine.Start.X) * (otherLine.Start.Y - otherLine.End.Y) - (this.Start.Y - otherLine.Start.Y) * (otherLine.Start.X - otherLine.End.X))
                    / ((this.Start.X - this.End.X) * (otherLine.Start.Y - otherLine.End.Y) - (this.Start.Y - this.End.Y) * (otherLine.Start.X - otherLine.End.X));

                var u = ((this.Start.X - otherLine.Start.X) * (this.Start.Y - this.End.Y) - (this.Start.Y - otherLine.Start.Y) * (this.Start.X - this.End.X))
                    / ((this.Start.X - this.End.X) * (otherLine.Start.Y - otherLine.End.Y) - (this.Start.Y - this.End.Y) * (otherLine.Start.X - otherLine.End.X));

                if (!(0 <= t && t <= 1 && 0 <= u && u <= 1))
                    return null; // lines don't intersect

                var x = (this.Start.X + t * (this.End.X - this.Start.X));
                var y = (this.Start.Y + t * (this.End.Y - this.Start.Y));

                //// this works for infinite lines...
                //var x = ((this.Start.X * this.End.Y - this.Start.Y * this.End.X) * (otherLine.Start.X - otherLine.End.Y) - (this.Start.X - this.End.X) * (otherLine.Start.X * otherLine.End.Y - otherLine.Start.Y * otherLine.End.X))
                //    / (double)((this.Start.X - this.End.X) * (otherLine.Start.Y - otherLine.End.Y) - (this.Start.Y - this.End.Y) * (otherLine.Start.X - otherLine.End.X));
                //var y = ((this.Start.X * this.End.Y - this.Start.Y * this.End.X) * (otherLine.Start.Y - otherLine.End.Y) - (this.Start.Y - this.End.Y) * (otherLine.Start.X * otherLine.End.Y - otherLine.Start.Y * otherLine.End.X))
                //    / (double)((this.Start.X - this.End.X) * (otherLine.Start.Y - otherLine.End.Y) - (this.Start.Y - this.End.Y) * (otherLine.Start.X - otherLine.End.X));

                return new Point2D<double>(x, y);
            }
            catch (DivideByZeroException)
            {
                return null;
            }
        }
    }
}
