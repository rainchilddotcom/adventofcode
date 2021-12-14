using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8
{
    public class Unscrambler
    {
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

        public string UnscrambleLine(string line)
        {
            var split = line.Split(" | ");
            var input = split[0].Split(" ");
            var output = split[1].Split(" ");

            // these can be determined by length alone
            string d1 = input.First(x => x.Length == 2);
            string d4 = input.First(x => x.Length == 4);
            string d7 = input.First(x => x.Length == 3);
            string d8 = input.First(x => x.Length == 7);

            // a is the difference between d7 and d1
            char a = d7.Trim(d1.ToCharArray())[0];

            // d9 is 6 long, contains d4 (bcdf) + ag
            string d9 = input
                .Where(x => x.Length == 6)
                .Where(x => x.Contains(a))
                .Where(x => x.Contains(d4[0]))
                .Where(x => x.Contains(d4[1]))
                .Where(x => x.Contains(d4[2]))
                .Where(x => x.Contains(d4[3]))
                .Single();

            // e must be the difference between d9 and d8
            char e = d8.Trim(d9.ToCharArray())[0];

            // g must be the unknown character from d9
            char g = d9.Trim(d4.ToCharArray()).Trim(a)[0];

            // d0 is 6 long, not d9, contains d1
            string d0 = input
                .Where(x => x.Length == 6)
                .Where(x => x != d9)
                .Where(x => x.Contains(d1[0]))
                .Where(x => x.Contains(d1[1]))
                .Single();

            // d must be the difference between d0 and d8
            char d = d8.Trim(d0.ToCharArray())[0];

            // d6 is 6 long, last one standing
            string d6 = input
                .Where(x => x.Length == 6)
                .Where(x => x != d9)
                .Where(x => x != d0)
                .Single();

            // c must be the difference between d6 and d8
            char c = d8.Trim(d6.ToCharArray())[0];

            // d3 is 5 long, contains d1
            string d3 = input
                .Where(x => x.Length == 5)
                .Where(x => x.Contains(d1[0]))
                .Where(x => x.Contains(d1[1]))
                .Single();

            // d5 is 5 long, not d3, and does not contain the e
            var d5 = input
                .Where(x => x.Length == 5)
                .Where(x => x != d3)
                .Where(x => !x.Contains(e))
                .Single();

            // d2 is the other 5 long one
            var d2 = input
                .Where(x => x.Length == 5)
                .Where(x => x != d3)
                .Where(x => x != d5)
                .Single();

            // now we've deduced everything (?) we can try to unscramble the message
            string unscrambled = "";

            foreach (var digit in output)
            {
                if (Matches(digit, d0))
                    unscrambled += "0";
                else if (Matches(digit, d1))
                    unscrambled += "1";
                else if (Matches(digit, d2))
                    unscrambled += "2";
                else if (Matches(digit, d3))
                    unscrambled += "3";
                else if (Matches(digit, d4))
                    unscrambled += "4";
                else if (Matches(digit, d5))
                    unscrambled += "5";
                else if (Matches(digit, d6))
                    unscrambled += "6";
                else if (Matches(digit, d7))
                    unscrambled += "7";
                else if (Matches(digit, d8))
                    unscrambled += "8";
                else if (Matches(digit, d9))
                    unscrambled += "9";
                else
                    throw new Exception($"Couldn't decode {digit}");
            }

            return unscrambled;
        }

        public int UnscrambleInput(string[] lines)
        {
            int checksum = 0;

            foreach(var line in lines)
            {
                checksum += Convert.ToInt32(UnscrambleLine(line));
            }

            return checksum;
        }

        private bool Matches(string a, string b)
        {
            return a.Except(b).Union(b.Except(a)).Count() == 0;
        }
    }
}
