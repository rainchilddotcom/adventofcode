using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _5
{
    public class InputParser
    {
        public List<Line> ParseLines(string[] input)
        {
            var lines = new List<Line>();
            foreach (string line in input)
            {
                if (GetCoordinates(line, out var start, out var end))
                {
                    lines.Add(new Line(start, end));
                }
            }
            return lines;
        }

        const string lineRegex = @"(\d*),(\d*) -> (\d*),(\d*)";

        bool GetCoordinates(string input, out Coordinate start, out Coordinate end)
        {
            var match = Regex.Match(input, lineRegex);

            if (match.Success)
            {
                start = new Coordinate(Convert.ToInt32(match.Groups[1].Captures[0].Value), Convert.ToInt32(match.Groups[2].Captures[0].Value));
                end = new Coordinate(Convert.ToInt32(match.Groups[3].Captures[0].Value), Convert.ToInt32(match.Groups[4].Captures[0].Value));
                return true;
            }
            else
            {
                start = null;
                end = null;
                return false;
            }
        }
    }
}
