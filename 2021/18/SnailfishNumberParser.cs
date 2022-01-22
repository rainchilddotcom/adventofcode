using System;
using System.Collections.Generic;
using System.Text;

namespace _18
{
    public class SnailfishNumberParser
    {
        public SnailfishNumber Parse(string input)
        {
            int position = 1;

            return ReadNumber();

            SnailfishNumber ReadNumber()
            {
                SnailfishNumber x = ReadElement();
                SnailfishNumber y = ReadElement();

                return new SnailfishNumber(x, y);
            }

            SnailfishNumber ReadElement()
            {
                if (input[position] == '[')
                {
                    position++;
                    var x = ReadNumber();
                    position++;
                    return x;
                }
                else
                {
                    return ReadLiteral();
                }
            }

            SnailfishNumber ReadLiteral()
            {
                var number = "";
                while (input[position] != ',' && input[position] != ']')
                {
                    number += input[position];
                    position++;
                }

                position++;

                return new SnailfishNumber(Convert.ToInt32(number));
            }
        }

        public List<SnailfishNumber> ParseAllNumbers(string[] numbers)
        {
            var list = new List<SnailfishNumber>();
            
            foreach(var number in numbers)
            {
                list.Add(Parse(number));
            }

            return list;
        }
    }
}
