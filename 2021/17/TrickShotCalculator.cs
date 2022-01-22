using System;
using System.Collections.Generic;
using System.Text;

namespace _17
{
    public class TrickShotCalculator
    {
        public void CalculateHighestVerticalVelocity(TargetArea targetArea, out int vx, out int vy, out int maxy, out int count)
        {
            int bestvx = 0;
            int bestvy = 0;
            int bestmaxy = 0;
            count = 0;

            for (int x = 0; x <= targetArea.MaxX; x++)
            {
                for (int y = targetArea.MinY; y < 1000; y++)
                {
                    var probe = new Probe(x, y);
                    if (probe.HitsTargetArea(targetArea))
                    {
                        count++;
                        if (probe.MaxY > bestmaxy)
                        {
                            bestvx = probe.InitialVelocityX;
                            bestvy = probe.InitialVelocityY;
                            bestmaxy = probe.MaxY;
                        }
                    }
                }
            }

            vx = bestvx;
            vy = bestvy;
            maxy = bestmaxy;
        }
    }
}