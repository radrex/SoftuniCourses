﻿namespace P07_RawData
{
    public class Engine
    {
        //-------------- Constructors --------------
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }

        //--------------- Properties ---------------
        public int Speed { get; private set; }

        public int Power { get; private set; }
    }
}
