using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    public class RopeMapper
    {
        private DynamicMap<Point3D> _map;
        private Rope _rope;

        public RopeMapper(int length = 1)
        {
            _map = new DynamicMap<Point3D>((x, y) => new Point3D(x, y, 0));
            _rope = new Rope(new Point2D(0, 0), new Point2D(0, 0), length);

            _rope.OnTailVisit += (tail => _map[tail.X, tail.Y].Z++);
        }

        public void ProcessMoveList(string[] list)
        {
            // before we get started... we should visit the starting points
            _rope.Visit(true, true);

            foreach (var move in list)
            {
                _rope.MoveHead(move);
            }
        }

        public Rope Rope { get { return _rope; } }
        public DynamicMap<Point3D> Map { get { return _map; } }
    }
}
