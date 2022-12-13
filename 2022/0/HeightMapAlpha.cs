using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    public class HeightMapAlpha
        : Map<PointAlpha>
    {
        public HeightMapAlpha(string[] input)
            : base(input)
        {
        }

        protected override PointAlpha ConstructValue(int x, int y, string input)
        {
            return new PointAlpha(x, y, input);
        }
    }
}
