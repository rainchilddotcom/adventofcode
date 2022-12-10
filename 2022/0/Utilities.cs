using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    public static class Utilities
    {
        public static Range ParseRange(string input, char separator = '-')
        {
            var indexes = input.Split(separator);
            decimal lowerBound = decimal.Parse(indexes[0]);
            decimal upperBound = decimal.Parse(indexes[1]);

            return new Range(lowerBound, upperBound);
        }

        public static bool Between(this decimal value, decimal lowerBound, decimal upperBound)
        {
            return value >= lowerBound && value <= upperBound;
        }

        public static bool Between(this int value, int lowerBound, int upperBound)
        {
            return value >= lowerBound && value <= upperBound;
        }
    }
}
