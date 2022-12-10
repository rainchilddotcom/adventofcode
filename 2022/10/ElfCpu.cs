using _0;

namespace _10
{
    public class ElfCpu
    {
        public ElfCpu(string[] program)
        {
            Cycle = 0;
            X = 1;
            SampleX = 1;
            LoadProgram(program);
            Display = "".PadRight(240, '.').ToCharArray();
        }

        private void LoadProgram(string[] program)
        {
            foreach (string line in program)
            {
                if (line == "noop")
                    Program.Enqueue(new Noop(this));

                if (line.StartsWith("addx"))
                {
                    int valueToAdd = Convert.ToInt32(line.Substring(5));
                    Program.Enqueue(new Addx(this, valueToAdd));
                }
            }
        }

        public Queue<Instruction> Program { get; } = new Queue<Instruction>();
        public int X { get; set; }
        public int Cycle { get; private set; }
        public int SampleX { get; private set; }
        public int AutoSampleX { get; private set; }
        public char[] Display { get; private set; }

        public void Step()
        {
            SampleX = X;
            Cycle++;

            UpdateDisplay();

            if (Cycle.Between(20, 220) && (Cycle - 20) % 40 == 0)
                AutoSampleX += Cycle * SampleX;

            var instruction = Program.Peek();
            if (instruction.Step())
                Program.Dequeue();
        }

        private void UpdateDisplay()
        {
            if (((Cycle - 1) % 40).Between(SampleX - 1, SampleX + 1))
                Display[Cycle - 1] = '#';
        }

        public string RenderDisplay()
        {
            return new string(Display, 0, 40) + Environment.NewLine
                + new string(Display, 40, 40) + Environment.NewLine
                + new string(Display, 80, 40) + Environment.NewLine
                + new string(Display, 120, 40) + Environment.NewLine
                + new string(Display, 160, 40) + Environment.NewLine
                + new string(Display, 200, 40) + Environment.NewLine;
        }

        public void Run()
        {
            while (Program.Count > 0)
            {
                Step();
            }

            Console.Write(RenderDisplay());
        }
    }
}
