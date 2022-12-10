namespace _10.Tests
{
    public class Day10Tests
    {
        const string testInput =
@"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";

        private string[] input { get { return testInput.Split(Environment.NewLine); } }

        [Test]
        public void SmallProgram()
        {
            var input = @"noop
addx 3
addx -5".Split(Environment.NewLine);

            var cpu = new ElfCpu(input);

            cpu.X.Should().Be(1);
            cpu.Step(); // noop
            cpu.X.Should().Be(1);
            cpu.Step(); // addx 3 cycle 1
            cpu.X.Should().Be(1);
            cpu.Step(); // addx 3 cycle 2
            cpu.X.Should().Be(4);
            cpu.Step(); // addx -5 cycle 1
            cpu.X.Should().Be(4);
            cpu.Step(); // addx -5 cycle 2
            cpu.X.Should().Be(-1);
        }

        [Test]
        public void SampleProgram()
        {
            var cpu = new ElfCpu(input);
            cpu.SampleX.Should().Be(1);

            for (int i = 0; i < 20; i++)
                cpu.Step();
            cpu.SampleX.Should().Be(21);

            for (int i = 0; i < 40; i++)
                cpu.Step();
            cpu.SampleX.Should().Be(19);

            for (int i = 0; i < 40; i++)
                cpu.Step();
            cpu.SampleX.Should().Be(18);

            for (int i = 0; i < 40; i++)
                cpu.Step();
            cpu.SampleX.Should().Be(21);

            for (int i = 0; i < 40; i++)
                cpu.Step();
            cpu.SampleX.Should().Be(16);

            for (int i = 0; i < 40; i++)
                cpu.Step();
            cpu.SampleX.Should().Be(18);

            cpu.AutoSampleX.Should().Be(13140);
        }

        [Test]
        public void RenderDisplay()
        {
            var cpu = new ElfCpu(input);
            cpu.Run();

            cpu.RenderDisplay()
                .Should().Be(
@"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....
");
        }
    }
}