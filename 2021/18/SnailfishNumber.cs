using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _18
{
    public class SnailfishNumber
    {
        public SnailfishNumber(int x, int y)
        {
            X = new SnailfishNumber(x);
            Y = new SnailfishNumber(y);
        }

        public SnailfishNumber(SnailfishNumber x, SnailfishNumber y)
        {
            X = x;
            Y = y;
        }

        public SnailfishNumber(SnailfishNumber x, int y)
        {
            X = x;
            Y = new SnailfishNumber(y);
        }

        public SnailfishNumber(int x, SnailfishNumber y)
        {
            X = new SnailfishNumber(x);
            Y = y;
        }

        public void AddExplosiveMatter(int value)
        {
            Value += value;
        }

        public SnailfishNumber(int value)
        {
            Value = value;
        }

        public SnailfishNumber X { get; private set; }
        public SnailfishNumber Y { get; private set; }

        public int? Value { get; private set; }

        public override string ToString()
        {
            if (Value.HasValue)
            {
                return Value.ToString();
            }
            else
            {
                return $"[{X},{Y}]";
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is int val)
                return val == Value;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Value);
        }

        public bool IsPair()
        {
            return !IsValue();
        }

        public bool IsValue()
        {
            return Value.HasValue;
        }

        public void Explode()
        {
            Value = 0;
            X = null;
            Y = null;

            throw new BigBadaBoom();
        }

        public void Split()
        {
            if (Value >= 10)
            {
                X = new SnailfishNumber((int)Math.Floor(Value.Value / 2.0m));
                Y = new SnailfishNumber((int)Math.Ceiling(Value.Value / 2.0m));
                Value = null;

                throw new SplitHappens();
            }
        }

        public long Magnitude
        {
            get
            {
                if (IsValue())
                    return Value.Value;

                return (X.Magnitude * 3) + (Y.Magnitude * 2);
            }
        }
    }
}
