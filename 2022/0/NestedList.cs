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
                return $"[{string.Join(',' , NestedValues)}]";
            }
        }
    }
}
