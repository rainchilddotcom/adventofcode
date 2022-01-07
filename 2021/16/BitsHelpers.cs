using System;
using System.Collections;

namespace _16
{
    public static class BitsHelpers
    {
        public static byte[] HexStringToByteArray(string input)
        {
            var output = new byte[input.Length / 2];

            for (int offset = 0; offset < output.Length; offset++)
            {
                output[offset] = byte.Parse(input.Substring(offset * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }

            return output;
        }

        public static BitArray HexStringToBitArray(string input)
        {
            var array = HexStringToByteArray(input);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ReverseBits(array[i]);
            }

            return new BitArray(array);
        }

        public static byte ReverseBits(byte input)
        {
            byte output = input;
            input >>= 1;

            for (int i = 0; i < 7; i++)
            {
                output <<= 1;
                output |= (byte)(input & 1);
                input >>= 1;
            }

            return output;
        }
    }
}
