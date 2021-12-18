using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10
{
    public class Parser
    {
        public List<Line> Lines { get; } = new List<Line>();

        public Parser(string[] lines)
        {
            LoadLines(lines);
        }

        private void LoadLines(string[] lines)
        {
            foreach (var line in lines)
            {
                Lines.Add(new Line(line));
            }
        }

        public int SyntaxErrorScore
        {
            get
            {
                return Lines.Sum(line => line.CorruptionScore);
            }
        }

        public long MiddleAutocompletionScore
        {
            get
            {
                var scores = Lines
                    .Where(x => x.Incomplete)
                    .Select(x => x.AutocompletionScore)
                    .OrderByDescending(x => x)
                    .ToList();

                return scores[scores.Count / 2];
            }
        }

        public static Dictionary<char, char> StartEndPairs { get; } = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
    }
}
