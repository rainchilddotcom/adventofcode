namespace _0
{
    public class PointAlpha
        : Point2D
    {
        public PointAlpha(int x, int y, string z)
            : base(x, y)
        {
            Z = z;
        }

        public string Z { get; set; }

        public override char Placeholder()
        {
            return Z[0];
        }
    }
}
