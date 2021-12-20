namespace _11
{
    public class Octopus
    {
        public Octopus(int x, int y, int level)
        {
            X = x;
            Y = y;
            Level = level;
        }

        public int X { get; }
        public int Y { get; }
        public int Level { get; private set; }
        public bool Flashed { get; private set; }

        public override string ToString()
        {
            return Level > 9 ? "0" : Level.ToString();
        }

        public void Step()
        {
            Level++;
        }

        public void Flash()
        {
            Flashed = true;
        }

        public void Reset()
        {
            if (Flashed)
            {
                Level = 0;
                Flashed = false;
            }
        }
    }
}