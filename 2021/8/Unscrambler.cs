using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8
{
    public class Unscrambler
    {
        public Unscrambler(string[] lines)
        {
            EasyDigits = CountEasyDigits(lines);
            Checksum = UnscrambleInput(lines);
        }

        public int CountEasyDigits(string[] lines)
        {
            int easyDigits = 0;

            foreach (var line in lines)
            {
                var split = line.Split(" | ");
                var input = split[0].Split(" ");
                var output = split[1].Split(" ");

                foreach (var digit in output)
                {
                    if (digit.Length == 2 || digit.Length == 3 || digit.Length == 4 || digit.Length == 7)
                    {
                        easyDigits++;
                    }
                }
            }
            
            return easyDigits;
        }

        public int EasyDigits { get; }
        public int Checksum { get; }
        public List<UnscramblerOutput> Lines { get; } = new List<UnscramblerOutput>();

        public int UnscrambleInput(string[] lines)
        {
            int checksum = 0;

            foreach (var line in lines)
            {
                var output = new UnscramblerOutput(line);
                Lines.Add(output);
                checksum += Convert.ToInt32(output.DecryptedOutput);
            }

            return checksum;
        }
    }
}
