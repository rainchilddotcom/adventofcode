using System;
using System.Linq;
using Xunit;

namespace _16.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData("D2FE28", 13827624)]
        public void TestHexStringToByteArray(string input, long expected)
        {
            var result = BitsHelpers.HexStringToByteArray(input);

            var longResult = 0;
            for (int i = 0; i < result.Length; i++)
            {
                longResult <<= 8;
                longResult += result[i];
            }

            Assert.Equal(expected, longResult);
        }

        [Theory]
        [InlineData("D2FE28", 13827624)]
        public void TestHexStringToBitArray(string input, long expected)
        {
            var result = BitsHelpers.HexStringToBitArray(input);

            var longResult = 0;
            for (int i = 0; i < result.Length; i++)
            {
                longResult <<= 1;
                if (result[i])
                    longResult += 1;
            }

            Assert.Equal(expected, longResult);
        }

        [Fact]
        public void DecodeLiteralValue()
        {
            var decoder = new BitsDecoder("D2FE28");

            Assert.Equal(6, decoder.Packet.Version);
            Assert.Equal(4, (int)decoder.Packet.TypeId);
            Assert.Equal(2021, decoder.Packet.Value);
        }

        [Fact]
        public void DecodeOperatorPacketFixedBits()
        {
            var decoder = new BitsDecoder("38006F45291200");

            Assert.Equal(1, decoder.Packet.Version);
            Assert.Equal(6, (int)decoder.Packet.TypeId);
            Assert.Equal(Packet.LengthModes.FixedBits, decoder.Packet.LengthMode);
            Assert.Equal(27, decoder.Packet.Length);
            Assert.Collection(decoder.Packet.SubPackets,
                subPacket => Assert.Equal(10, subPacket.Value),
                subPacket => Assert.Equal(20, subPacket.Value)
            );
        }


        [Fact]
        public void DecodeOperatorPacketPacketCount()
        {
            var decoder = new BitsDecoder("EE00D40C823060");

            Assert.Equal(7, decoder.Packet.Version);
            Assert.Equal(3, (int)decoder.Packet.TypeId);
            Assert.Equal(Packet.LengthModes.PacketCount, decoder.Packet.LengthMode);
            Assert.Equal(3, decoder.Packet.Length);
            Assert.Collection(decoder.Packet.SubPackets,
                subPacket => Assert.Equal(1, subPacket.Value),
                subPacket => Assert.Equal(2, subPacket.Value),
                subPacket => Assert.Equal(3, subPacket.Value)
            );
        }

        [Theory]
        [InlineData("8A004A801A8002F478", 16)]
        [InlineData("620080001611562C8802118E34", 12)]
        [InlineData("C0015000016115A2E0802F182340", 23)]
        [InlineData("A0016C880162017C3686B18A3D4780", 31)]
        public void CheckPacketChecksum(string input, int expectedChecksum)
        {
            var decoder = new BitsDecoder(input);
            Assert.Equal(expectedChecksum, decoder.Packet.Checksum);
        }

        [Theory]
        [InlineData("C200B40A82", 3)]
        [InlineData("04005AC33890", 54)]
        [InlineData("880086C3E88112", 7)]
        [InlineData("CE00C43D881120", 9)]
        [InlineData("D8005AC2A8F0", 1)]
        [InlineData("F600BC2D8F", 0)]
        [InlineData("9C005AC2F8F0", 0)]
        [InlineData("9C0141080250320F1802104A08", 1)]
        public void CheckPacketValue(string input, int expectedValue)
        {
            var decoder = new BitsDecoder(input);
            Assert.Equal(expectedValue, decoder.Packet.Value);
        }
    }
}
