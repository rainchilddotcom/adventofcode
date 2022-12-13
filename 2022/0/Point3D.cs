using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    public class Point3D
        : Point2D
    {
        public Point3D(int x, int y, int z)
            : base(x, y)
        {
            Z = z;
        }

        public int Z { get; set; }

        public override char Placeholder()
        {
            return Z.ToString()[0];
        }
    }
}
