namespace _0
{
    public class HeightMap
        : Map<Point3D>
    {
        public HeightMap(string[] input)
            : base(input)
        {
        }

        protected override Point3D ConstructValue(int x, int y, string input)
        {
            return new Point3D(x, y, Convert.ToInt32(input));
        }
    }
}
