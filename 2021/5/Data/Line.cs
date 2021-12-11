namespace _5
{
    public class Line
    {
        public Line(Coordinate start, Coordinate end)
        {
            Start = start;
            End = end;
        }

        public Coordinate Start { get; }
        public Coordinate End { get; }

        public bool IsHorizontal { get { return Start.Y == End.Y; } }
        public bool IsVertical { get { return Start.X == End.X; } }
    }
}