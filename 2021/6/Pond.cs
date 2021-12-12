using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6
{
    public class Pond
    {
        private decimal[] _fish = new decimal[9];

        public Pond(short[] fish)
        {
            foreach (var f in fish)
                _fish[f]++;
        }

        public decimal NumberOfFish
        {
            get
            {
                decimal sum = 0;
                for (int i = 0; i <= 8; i++)
                {
                    sum += _fish[i];
                }
                return sum;
            }
        }

        public void TimePasses()
        {
            var dayzero = _fish[0];
            _fish[0] = _fish[1];
            _fish[1] = _fish[2];
            _fish[2] = _fish[3];
            _fish[3] = _fish[4];
            _fish[4] = _fish[5];
            _fish[5] = _fish[6];
            _fish[6] = _fish[7] + dayzero;
            _fish[7] = _fish[8];
            _fish[8] = dayzero;
        }
    }
}
