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

        public static List<int> ParseIntList(this string input, char separator = ',')
        {
            var list = new List<int>();
            foreach (var item in input.Split(separator))
            {
                list.Add(int.Parse(item));
            }
            return list;
        }

        public static Point2D ParseCoordinate(this string input, char separator = ',')
        {
            var coordinates = input.Split(separator);
            return new Point2D(Convert.ToInt32(coordinates[0]), Convert.ToInt32(coordinates[1]));
        }

        public static List<Point2D> ParsePointList(this string input, char xyseparator = ',', string pointseparator = " ")
        {
            var list = new List<Point2D>();
            foreach (var item in input.Split(pointseparator))
            {
                list.Add(ParseCoordinate(item, xyseparator));
            }
            return list;
        }

        public static long CalculateHighestPrime(this long value)
        {
            // didn't need this in the end, but it could be handy in future?
            long orig = value;
            var factors = new List<long>();

            int factor = 2;
            while (value % factor == 0)
            {
                factors.Add(factor);
                value /= factor;
            }

            factor = 3;
            while (factor * factor <= value)
            {
                // only have to check up to the square root
                if (value % factor == 0)
                {
                    factors.Add(factor);
                    value /= factor;
                }
                else
                {
                    factor += 2;
                }
            }

            if (value != 1)
            {
                factors.Add(value);
            }

            var max = factors.Max();

            Console.WriteLine($"Factoring {orig} into {max}");

            return max;
        }
    }
}
