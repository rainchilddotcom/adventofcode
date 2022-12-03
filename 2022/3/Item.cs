using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    public class Item
    {
        public static int CalculatePriority(char mispackedItem)
        {
            if (mispackedItem >= 'a' && mispackedItem <= 'z')
            {
                return mispackedItem - 'a' + 1;
            }

            if (mispackedItem >= 'A' && mispackedItem <= 'Z')
            {
                return mispackedItem - 'A' + 27;
            }

            throw new ArgumentOutOfRangeException($"Unknown item: {mispackedItem}");
        }
    }
}
