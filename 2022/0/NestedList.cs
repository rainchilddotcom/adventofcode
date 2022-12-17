using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    public class NestedList<T>
    {
        public NestedList(T value)
        {
            Value = value;
        }

        public NestedList(List<NestedList<T>> list)
        {
            NestedValues = list;
        }

        public T Value { get; private set; }

        public List<NestedList<T>>? NestedValues { get; private set; }

        public bool IsList()
        {
            return NestedValues != null;
        }

        public bool IsValue()
        {
            return !IsList();
        }

        public override string ToString()
        {
            if (IsValue())
            {
                return Value.ToString();
            }
            else
            {
                return $"[{string.Join(',', NestedValues)}]";
            }
        }

        public static NestedList<T> Parse(string input)
        {
            int position = 0;

            return ReadElement();

            NestedList<T> ReadElement()
            {
                if (input[position] == '[')
                {
                    position++;
                    var x = new NestedList<T>(new List<NestedList<T>>());

                    while (input[position] != ']')
                    {
                        x.NestedValues.Add(ReadElement());
                        if (input[position] == ',')
                            position++;
                    }

                    position++;
                    return x;
                }

                return ReadValue();
            }

            NestedList<T> ReadValue()
            {
                var value = "";
                while (input[position] != ',' && input[position] != ']')
                {
                    value += input[position];
                    position++;
                }

                return new NestedList<T>((T)Convert.ChangeType(value, typeof(T)));
            }
        }
    }
}
