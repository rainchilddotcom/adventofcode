namespace _10
{
    public class Addx
        : Instruction
    {
        private readonly int _valueToAdd;
        private bool _first;

        public Addx(ElfCpu cpu, int valueToAdd)
            :base(cpu)
        {
            _valueToAdd = valueToAdd;
            _first = true;
        }

        public override string Name => "addx";

        public override bool Step()
        {
            if (_first)
            {
                _first = false;
                return false;
            }

            Cpu.X += _valueToAdd;
            return true;
        }
    }
}