using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _17
{
    public class TargetAreaLoader
    {
        public TargetArea Load(string input)
        {
            var match = Regex.Match(input, @"x=(-?\d*)\.\.(-?\d*),\s*y=(-?\d*)\.\.(-?\d*)");
            if (match.Success)
            {
                int minX = Convert.ToInt32(match.Groups[1].Captures[0].Value);
                int maxX = Convert.ToInt32(match.Groups[2].Captures[0].Value);
                int minY = Convert.ToInt32(match.Groups[3].Captures[0].Value);
                int maxY = Convert.ToInt32(match.Groups[4].Captures[0].Value);

                return new TargetArea(minX, maxX, minY, maxY);
            }

            throw new ArgumentException("Input is invalid");
        }
    }
}
