using System.Collections.Generic;

namespace _15
{
    public class Path
    {
        public Path(List<Point> steps, int danger)
        {
            Steps = steps;
            Danger = danger;
        }
        
        public int Danger { get; }
        public List<Point> Steps { get; } = new List<Point>();
    }
}