using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _16
{
    public class BitsDecoder
    {
        private readonly BitArray _input;

        public BitsDecoder(string input)
        {
            _input = BitsHelpers.HexStringToBitArray(input);

            int offset = 0;
            Packet = ReadPacket(ref offset);
        }

        private Packet ReadPacket(ref int offset)
        {
            var version = (int) ReadBits(ref offset, 3);
            var typeId = (Packet.PacketTypes) ReadBits(ref offset, 3);

            var packet = new Packet
            {
                Version = version,
                TypeId = typeId
            };

            switch (typeId)
            {
                case Packet.PacketTypes.Literal:
                    packet.LiteralValue = ReadLiteral(ref offset);
                    break;

                default:
                    packet.LengthMode = ReadLengthMode(ref offset);
                    packet.Length = ReadPacketLength(ref offset, packet.LengthMode);
                    packet.SubPackets.AddRange(ReadSubPackets(ref offset, packet.LengthMode, packet.Length));
                    break;
            }

            return packet;
        }

        private IEnumerable<Packet> ReadSubPackets(ref int offset, Packet.LengthModes lengthMode, long length)
        {
            var subPackets = new List<Packet>();

            switch (lengthMode)
            {
                case Packet.LengthModes.FixedBits:
                    var foo = offset;
                    while (offset - foo < length)
                    {
                        subPackets.Add(ReadPacket(ref offset));
                    }
                    break;

                case Packet.LengthModes.PacketCount:
                    for (int i = 0; i < length; i++)
                    {
                        subPackets.Add(ReadPacket(ref offset));
                    }
                    break;

                default:
                    throw new NotSupportedException($"Invalid LengthMode {lengthMode}");
            }

            return subPackets;
        }

        private long ReadLiteral(ref int offset)
        {
            long literal = 0;

            bool readMore;
            do
            {
                readMore = (ReadBits(ref offset, 1) != 0);

                literal <<= 4;
                literal += ReadBits(ref offset, 4);
            }
            while (readMore);

            return literal;
        }

        private Packet.LengthModes ReadLengthMode(ref int offset)
        {
            if (ReadBits(ref offset, 1) != 0)
            {
                return Packet.LengthModes.PacketCount;
            }
            else
            {
                return Packet.LengthModes.FixedBits;
            }
        }

        private long ReadPacketLength(ref int offset, Packet.LengthModes lengthMode)
        {
            switch (lengthMode)
            {
                case Packet.LengthModes.FixedBits:
                    return ReadBits(ref offset, 15);

                case Packet.LengthModes.PacketCount:
                    return ReadBits(ref offset, 11);

                default:
                    throw new NotSupportedException($"Invalid LengthMode {lengthMode}");
            }
        }

        private long ReadBits(ref int offset, int count)
        {
            long output = 0;

            for (int i = 0; i < count; i++)
            {
                output <<= 1;
                if (_input[offset])
                    output++;
                offset++;
            }

            return output;
        }


        public Packet Packet { get; private set; }
    }
}
