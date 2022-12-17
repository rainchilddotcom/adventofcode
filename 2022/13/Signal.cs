using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    public class Signal
    {
        private List<Tuple<Packet, Packet>> _packets;

        public Signal(List<Tuple<Packet, Packet>> packets)
        {
            _packets = packets;
        }

        public int[] CorrectPacketNumbers()
        {
            return _packets
                .Select((value, index) => new { Value = value, Index = index })
                .Where(pair => pair.Value.Item1.CompareTo(pair.Value.Item2) < 0)
                .Select(pair => pair.Index + 1)
                .ToArray();
        }

        public int CalculateDecoderKey()
        {
            var leftDivider = new Packet(NestedList<int>.Parse("[[2]]"));
            var rightDivider = new Packet(NestedList<int>.Parse("[[6]]"));

            var packetList = new List<Packet>();
            packetList.Add(leftDivider); 
            packetList.Add(rightDivider);
            packetList.AddRange(_packets.Select(x => x.Item1));
            packetList.AddRange(_packets.Select(x => x.Item2));

            packetList.Sort();

            return packetList
                .Select((value, index) => new { Value = value, Index = index })
                .Where(pair => pair.Value == leftDivider || pair.Value == rightDivider)
                .Select(pair => pair.Index + 1)
                .Aggregate(1, (x, y) => x * y);
        }
    }
}
