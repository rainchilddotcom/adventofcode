using System;
using System.Collections.Generic;
using System.Linq;

namespace _10
{
    public class Line
    {
        public string Text { get; }
        public List<Chunk> Chunks { get; } = new List<Chunk>();

        public Line(string line)
        {
            Text = line;

            ParseLine();

            if (Incomplete)
                AutocompleteLine();
        }

        public void ParseLine()
        {
            try
            {
                int position = 0;
                while (true)
                    position = ReadChunk(position) + 1;
            }
            catch (Exception ex)
            {
                // swallow
            }
        }

        private void AutocompleteLine()
        {
            Autocompletion = string.Concat(
                Chunks
                .OrderByDescending(x => x.Start)
                .Where(x => x.End == 0)
                .Select(x => Parser.StartEndPairs[x.StartChar])
            );

            AutocompletionScore = 0;
            foreach (var c in Autocompletion)
            {
                AutocompletionScore *= 5;
                AutocompletionScore += AutocompleteScoreFor(c);
            }
        }

        public int ReadChunk(int position)
        {
            var chunk = new Chunk();
            Chunks.Add(chunk);

            chunk.Start = position;
            chunk.StartChar = Text[chunk.Start];

            do
            {
                position++;

                if (position >= Text.Length)
                {
                    // we've run out of input, must be incomplete
                    Incomplete = true;
                    throw new Exception($"Line incomplete at position {position}");
                }
                else if (Parser.StartEndPairs.ContainsKey(Text[position]))
                {
                    // if it's an open bracket of some kind, read the nested chunk and update the position
                    position = ReadChunk(position);
                }
                else if (Text[position] == Parser.StartEndPairs[chunk.StartChar])
                {
                    // if it's our close bracket, then we're done
                    chunk.End = position;
                    chunk.EndChar = Text[position];
                    return position;
                }
                else
                {
                    // corruption detected
                    CorruptionScore = ErrorScoreFor(Text[position]);

                    throw new Exception($"Line corrupt at position {position}, char {Text[position]}, score {ErrorScoreFor(Text[position])}");
                }
            } while (true);
        }

        private int ErrorScoreFor(char c)
        {
            switch (c)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
            }

            throw new Exception($"Unscored character: {c}");
        }

        private int AutocompleteScoreFor(char c)
        {
            switch (c)
            {
                case ')':
                    return 1;
                case ']':
                    return 2;
                case '}':
                    return 3;
                case '>':
                    return 4;
            }

            throw new Exception($"Unscored character: {c}");
        }

        public int CorruptionScore { get; private set; }
        public bool Incomplete { get; private set; }
        public string Autocompletion { get; private set; }
        public long AutocompletionScore { get; private set; }
    }
}