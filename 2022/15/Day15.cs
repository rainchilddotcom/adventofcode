using _0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15
{
    public class Day15
        : Puzzle
    {
        public override string Part1Caption() => "Coverage @ 2,000,000";

        public override string Part1Answer()
        {
            var input = LoadInput();
            var sensorGrid = new SensorGridLoader().LoadSensorGrid(input);
            var line = new Line((int)sensorGrid.MinX, 2000000, (int)sensorGrid.MaxX, 2000000);
            return sensorGrid.CalculateCoverage(line).ToString();
        }

        public override string Part2Caption() => "TODO";

        public override string Part2Answer()
        {
            var input = LoadInput();
            throw new NotImplementedException();
        }
    }
}
