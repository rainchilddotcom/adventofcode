using _0;

namespace _13
{
    public class Packet
        : IComparable<Packet>
    {
        public Packet(NestedList<int> packetData)
        {
            PacketData = packetData;
        }

        public NestedList<int> PacketData { get; }

        public override string ToString()
        {
            return PacketData.ToString();
        }

        public int CompareTo(Packet? other)
        {
            if (other == null)
                return 1;

            return CompareLists(PacketData, other.PacketData);
        }

        private int CompareLists(NestedList<int> left, NestedList<int> right)
        {
            if (left.IsValue() && right.IsValue())
                return Math.Sign(left.Value - right.Value);

            if (left.IsList() && right.IsList())
            {
                int max = Math.Max(left.NestedValues.Count, right.NestedValues.Count);
                for (int i = 0; i < max; i++)
                {
                    if (left.NestedValues.Count <= i)
                        return -1; // left list ran out of items first - is less than right

                    if (right.NestedValues.Count <= i)
                        return 1; // right list ran out of items first - is less than left

                    var result = CompareLists(left.NestedValues[i], right.NestedValues[i]);
                    if (result != 0)
                        return result;
                }

                return 0; // lists are equal
            }

            // one value, one list... convert the value to a list and do the comparison
            var leftComparison = left.IsValue() ? new NestedList<int>(new List<NestedList<int>> { left }) : left;
            var rightComparison = right.IsValue() ? new NestedList<int>(new List<NestedList<int>> { right }) : right;

            return CompareLists(leftComparison, rightComparison);
        }
    }
}


/*
 * When comparing two values, the first value is called left and the second value is called right. Then:

If both values are integers, the lower integer should come first. If the left integer is lower than the right integer,
the inputs are in the right order. If the left integer is higher than the right integer, the inputs are not in the right order. 
Otherwise, the inputs are the same integer; continue checking the next part of the input.

If both values are lists, compare the first value of each list, then the second value, and so on. If the left list runs out of
items first, the inputs are in the right order. If the right list runs out of items first, the inputs are not in the right order.

If the lists are the same length and no comparison makes a decision about the order, continue checking the next part of the input.

If exactly one value is an integer, convert the integer to a list which contains that integer as its only value, then retry the
comparison. For example, if comparing [0,0,0] and 2, convert the right value to [2] (a list containing 2); the result is then found by instead comparing [0,0,0] and [2].

 */