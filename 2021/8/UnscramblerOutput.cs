using System.Linq;

namespace _8
{
    public class UnscramblerOutput
    {
        public UnscramblerOutput(string line)
        {
            UnscrambleLine(line);
        }

        public string[] Input { get; private set; }
        public string[] Output { get; private set; }
        public string d1 { get; private set; }
        public string d4 { get; private set; }
        public string d7 { get; private set; }
        public string d8 { get; private set; }
        public string DecryptedInput { get; private set; }
        public string DecryptedOutput { get; private set; }
        public string d9 { get; private set; }
        public string d0 { get; private set; }
        public string d6 { get; private set; }
        public string d3 { get; private set; }
        public string d5 { get; private set; }
        public string d2 { get; private set; }

        public string UnscrambleLine(string line)
        {
            var split = line.Split(" | ");
            Input = split[0].Split(" ");
            Output = split[1].Split(" ");

            // these can be determined by length alone
            d1 = Input.First(x => x.Length == 2);
            d4 = Input.First(x => x.Length == 4);
            d7 = Input.First(x => x.Length == 3);
            d8 = Input.First(x => x.Length == 7);

            // a is the difference between d7 and d1
            char a = d7.Trim(d1.ToCharArray())[0];

            // d9 is 6 long, contains d4 (bcdf) + ag
            d9 = Input
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
            d0 = Input
                .Where(x => x.Length == 6)
                .Where(x => x != d9)
                .Where(x => x.Contains(d1[0]))
                .Where(x => x.Contains(d1[1]))
                .Single();

            // d must be the difference between d0 and d8
            char d = d8.Trim(d0.ToCharArray())[0];

            // d6 is 6 long, last one standing
            d6 = Input
                .Where(x => x.Length == 6)
                .Where(x => x != d9)
                .Where(x => x != d0)
                .Single();

            // c must be the difference between d6 and d8
            char c = d8.Trim(d6.ToCharArray())[0];

            // d3 is 5 long, contains d1
            d3 = Input
                .Where(x => x.Length == 5)
                .Where(x => x.Contains(d1[0]))
                .Where(x => x.Contains(d1[1]))
                .Single();

            // d5 is 5 long, not d3, and does not contain the e
            d5 = Input
                .Where(x => x.Length == 5)
                .Where(x => x != d3)
                .Where(x => !x.Contains(e))
                .Single();

            // d2 is the other 5 long one
            d2 = Input
                .Where(x => x.Length == 5)
                .Where(x => x != d3)
                .Where(x => x != d5)
                .Single();

            // now we've deduced everything (?) we can try to unscramble the message
            DecryptedInput = UnscrambleDigits(Input);
            DecryptedOutput = UnscrambleDigits(Output);

            return DecryptedOutput;
        }

        private string UnscrambleDigits(string[] input)
        {
            string unscrambled = "";
            foreach (var digit in input)
            {
                unscrambled += UnscrambleDigit(digit);
            }
            return unscrambled;
        }

        private string UnscrambleDigit(string digit)
        {
            if (Matches(digit, d0))
                return "0";
            else if (Matches(digit, d1))
                return "1";
            else if (Matches(digit, d2))
                return "2";
            else if (Matches(digit, d3))
                return "3";
            else if (Matches(digit, d4))
                return "4";
            else if (Matches(digit, d5))
                return "5";
            else if (Matches(digit, d6))
                return "6";
            else if (Matches(digit, d7))
                return "7";
            else if (Matches(digit, d8))
                return "8";
            else if (Matches(digit, d9))
                return "9";
            else
                throw new System.Exception($"Couldn't decode {digit}");
        }

        private bool Matches(string a, string b)
        {
            return a.Except(b).Union(b.Except(a)).Count() == 0;
        }
    }
}