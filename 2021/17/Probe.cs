using System;
using System.Collections.Generic;
using System.Text;

namespace _17
{
    public class Probe
    {
        public Probe(int velocityX, int velocityY)
        {
            InitialVelocityX = VelocityX = velocityX;
            InitialVelocityY = VelocityY = velocityY;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int VelocityX { get; private set; }
        public int VelocityY { get; private set; }

        public int InitialVelocityX { get; }
        public int InitialVelocityY { get; }
        public int MaxY { get; private set; }

        public void Step()
        {
            PositionX += VelocityX;
            PositionY += VelocityY;

            if (PositionY > MaxY)
                MaxY = PositionY;

            if (VelocityX > 0)
                VelocityX--;
            else if (VelocityX < 0)
                VelocityX++;

            VelocityY--;
        }

        public bool HitsTargetArea(TargetArea targetArea)
        {
            while (PositionX <= targetArea.MaxX && PositionY >= targetArea.MinY)
            {
                Step();
                if (targetArea.Hit(PositionX, PositionY))
                    return true;
            }

            return false;
        }
    }
}