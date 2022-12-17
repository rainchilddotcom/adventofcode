using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    public class Day13
        : Puzzle
    {
        public override string Part1Caption() => "Correct Packet Sum";

        public override string Part1Answer()
        {
            var input = LoadInput();
            
            var packets = new PacketLoader()
                .LoadPackets(input);

            var signal = new Signal(packets);
            return signal.CorrectPacketNumbers().Sum().ToString();
        }

        public override string Part2Caption() => "Decoder Key";

        public override string Part2Answer()
        {
            var input = LoadInput();

            var packets = new PacketLoader()
                .LoadPackets(input);
            
            var signal = new Signal(packets);
            return signal.CalculateDecoderKey().ToString();
        }
    }
}
