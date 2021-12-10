namespace _4
{
    public class BingoNumber
    {
        public BingoNumber(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }
        public bool Called { get; private set; }

        public void Call(int number)
        {
            if (number == Number)
                Called = true;
        }
    }
}
