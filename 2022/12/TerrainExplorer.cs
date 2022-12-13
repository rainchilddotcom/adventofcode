using _0;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    public class TerrainExplorer
        : MapExplorer<PointAlpha>
    {
        public TerrainExplorer(Map<PointAlpha> heightMap)
            : base(heightMap)
        {
        }

        public Path<PointAlpha> FindPath()
        {
            var start = _heightMap.AsEnumerable().Where(x => x.Z == "S").Single();
            var end = _heightMap.AsEnumerable().Where(x => x.Z == "E").Single();
            EndFunction endFunction = (current) => current == end;

            var path = base.FindPath(start, endFunction, MovementCost);
            return path;
        }

        public Path<PointAlpha> FindHike()
        {
            var start = _heightMap.AsEnumerable().Where(x => x.Z == "E").Single();
            EndFunction endFunction = (current) => current.Z == "a";

            var path = base.FindPath(start, endFunction, ReverseMovementCost);
            return path;
        }

        public int MovementCost(PointAlpha current, PointAlpha neighbour)
        {
            if (current.Z == "S" && (neighbour.Z == "a" || neighbour.Z == "b"))
                return 1;

            if (neighbour.Z == "E")
            {
                if (current.Z == "y" || current.Z == "z")
                    return 1;

                return MaxValue;
            }

            if (neighbour.Z[0] - current.Z[0] > 1)
                return MaxValue;

            return 1;
        }

        public int ReverseMovementCost(PointAlpha current, PointAlpha neighbour)
        {
            if (current.Z == "S" && (neighbour.Z == "a" || neighbour.Z == "b"))
                return 1;

            if (current.Z == "E")
            {
                if (neighbour.Z == "y" || neighbour.Z == "z")
                    return 1;

                return MaxValue;
            }

            if (neighbour.Z == "E")
            {
                if (current.Z == "y" || current.Z == "z")
                    return 1;

                return MaxValue;
            }

            if (current.Z[0] - neighbour.Z[0] > 1)
                return MaxValue;

            return 1;
        }
    }
}
