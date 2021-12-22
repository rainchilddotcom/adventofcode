using System;
using System.Collections.Generic;
using System.Linq;

namespace _12
{
    public class Path
    {
        public Path(List<Room> steps)
        {
            Steps = steps;
        }

        List<Room> Steps { get; } = new List<Room>();

        public override string ToString()
        {
            return string.Join(',', Steps);
        }
    }
}