using System;
using System.Collections.Generic;
using System.Text;

namespace _17
{
    public class TargetArea
    {
        public TargetArea(int minX, int maxX, int minY, int maxY)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }

        public int MinX { get; private set; }
        public int MaxX { get; private set; }
        public int MinY { get; private set; }
        public int MaxY { get; private set; }

        public bool Hit(int x, int y)
        {
            return (x >= MinX && x <= MaxX && y >= MinY && y <= MaxY);
        }
    }
}