using System;
using System.Collections.Generic;
using System.Linq;

namespace _16
{
    public class Packet
    {
        public int Version { get; set; }
        public PacketTypes TypeId { get; set; }
        public long LiteralValue { get; set; }
        public long Length { get; set; }
        public LengthModes LengthMode { get; set; }
        public List<Packet> SubPackets { get; } = new List<Packet>();

        public int Checksum
        {
            get
            {
                return SubPackets.Sum(sp => sp.Checksum) + Version;
            }
        }

        public long Value
        {
            get
            {
                switch (TypeId)
                {
                    case PacketTypes.Literal:
                        return LiteralValue;

                    case PacketTypes.Sum:
                        return SubPackets.Sum(sp => sp.Value);

                    case PacketTypes.Product:
                        return SubPackets
                            .Select(sp => sp.Value)
                            .Aggregate((x, y) => x * y);

                    case PacketTypes.Minimum:
                        return SubPackets.Min(sp => sp.Value);

                    case PacketTypes.Maximum:
                        return SubPackets.Max(sp => sp.Value);

                    case PacketTypes.GreaterThan:
                        return (SubPackets[0].Value > SubPackets[1].Value ? 1 : 0);

                    case PacketTypes.LessThan:
                        return (SubPackets[0].Value < SubPackets[1].Value ? 1 : 0);

                    case PacketTypes.EqualTo:
                        return (SubPackets[0].Value == SubPackets[1].Value ? 1 : 0);

                    default:
                        throw new NotSupportedException($"Invalid TypeId {TypeId}");
                }
            }
        }

        public enum LengthModes
        {
            FixedBits,
            PacketCount
        }

        public enum PacketTypes
        {
            Sum = 0,
            Product = 1,
            Minimum = 2,
            Maximum = 3,
            Literal = 4,
            GreaterThan = 5,
            LessThan = 6,
            EqualTo = 7
        }
    }
}