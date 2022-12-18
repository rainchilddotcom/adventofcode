using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    public class SensorGrid
    {
        public List<Sensor> Sensors { get; } = new List<Sensor>();

        public void Add(Sensor sensor)
        {
            Sensors.Add(sensor);
        }
    }
}
