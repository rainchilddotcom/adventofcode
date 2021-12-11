namespace _5
{
    public class Vent
        : Coordinate
    {
        public Vent(int x, int y)
            : base(x, y)
        {
        }

        public int Danger { get; private set; }
        public int StraightDanger { get; private set; }

        public void IncreaseDanger(bool straight)
        {
            Danger++;

            if (straight)
                StraightDanger++;
        }
    }
}
