namespace _10
{
    public abstract class Instruction
    {
        public Instruction(ElfCpu cpu)
        {
            Cpu = cpu;
        }

        public abstract string Name { get; }
        public ElfCpu Cpu { get; }
        public abstract bool Step();
    }
}