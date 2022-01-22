using System;
using System.Collections.Generic;
using System.Text;

namespace _18
{
    public class MagnitudeFinder
    {
        public void FindLargest(string[] input, out string bestLeft, out string bestRight, out string bestResult, out long bestMagnitude)
        {
            var parser = new SnailfishNumberParser();
            var reducer = new SnailfishReducer();

            string bl = null;
            string br = null;
            string bn = null;
            long bm = 0;

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{DateTime.Now.ToString("HH:mm:ss")} Processing {i}\r");

                for (int j = 0; j < input.Length; j++)
                {
                    if (i != j)
                    {
                        CheckBest(input[i], input[j]);
                        CheckBest(input[j], input[i]);
                    }
                }
            }

            bestLeft = bl;
            bestRight = br;
            bestResult = bn;
            bestMagnitude = bm;

            void CheckBest(string left, string right)
            {
                var result = new SnailfishNumber(parser.Parse(left), parser.Parse(right));
                reducer.ReduceAll(result);
                UpdateBest(left, right, result);
            }

            void UpdateBest(string left, string right, SnailfishNumber result)
            {
                var magnitude = result.Magnitude;

                if (magnitude > bm)
                {
                    bl = left;
                    br = right;
                    bn = result.ToString();
                    bm = magnitude;
                }
            }
        }
    }
}
