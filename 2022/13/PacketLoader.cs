using _0;

namespace _13
{
    public class PacketLoader
    {
        public List<Tuple<Packet, Packet>> LoadPackets(string[] input)
        {
            var packets = new List<Tuple<Packet, Packet>>();

            for (int i = 0; i < input.Length; i += 3)
            {
                var left = new Packet(NestedList<int>.Parse(input[i]));
                var right = new Packet(NestedList<int>.Parse(input[i+1]));
                packets.Add(new Tuple<Packet, Packet>(left, right));
            }

            return packets;
        }
    }
}