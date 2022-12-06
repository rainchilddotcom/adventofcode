namespace _6
{
    public class RadioSignal
    {
        private string _dataStream;

        public class MarkerLengths
        {
            public const int Packet = 4;
            public const int Message = 14;
        };

        public RadioSignal(string dataStream)
        {
            _dataStream = dataStream;
            FirstPacketMarker = SeekToPacket(0);
            FirstMessageMarker = SeekToMessage(FirstPacketMarker - MarkerLengths.Packet);
        }

        public int FirstPacketMarker { get; init; }
        public int FirstMessageMarker { get; init; }

        public int SeekToPacket(int offset)
        {
            return PerformSeek(offset, MarkerLengths.Packet);
        }

        public int SeekToMessage(int offset)
        {
            while (true)
            {
                if (VerifyUniqueness(offset, MarkerLengths.Message))
                    return offset + MarkerLengths.Message;

                offset = SeekToPacket(++offset) - MarkerLengths.Packet;
            }
        }

        private int PerformSeek(int offset, int markerLength)
        {
            if (offset < 0 || offset >= _dataStream.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            do
            {
                if (VerifyUniqueness(offset, markerLength))
                    return offset + markerLength;
            }
            while (offset++ < _dataStream.Length);

            throw new IndexOutOfRangeException($"Ran out of data at {offset}");
        }

        private bool VerifyUniqueness(int offset, int length)
        {
            if (offset < 0 || offset >= _dataStream.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            var nextNCharacters = _dataStream.Substring(offset, length);
            if (nextNCharacters.Length < length)
                throw new IndexOutOfRangeException($"Ran out of data at {offset}");

            return (nextNCharacters.ToList().Distinct().Count() == length);
        }
    }
}