using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    public class Range
    {
        public Range(decimal lowerBound, decimal upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        public decimal LowerBound { get; }
        public decimal UpperBound { get; }
    }
}
