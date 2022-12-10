namespace _10
{
    public class Noop
        : Instruction
    {
        public Noop(ElfCpu cpu)
            : base(cpu) { }

        public override string Name => "noop";

        public override bool Step()
        {
            // does nothing
            return true;
        }
    }
}