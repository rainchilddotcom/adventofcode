namespace _1
{
    public class Elf
    {
        public List<Decimal> Items { get; set; } = new List<Decimal>();

        public decimal TotalCalories
        {
            get
            {
                return Items.Sum();
            }
        }
    }
}
