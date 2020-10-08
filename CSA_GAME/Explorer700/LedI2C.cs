using System;

namespace CSA_GAME.Explorer700
{
    public class LedI2C : LedBase
    {
        private readonly Pcf8574 _pcf8574;
        public LedI2C(Pcf8574 pcf8574)
        {
            _pcf8574 = pcf8574;
            _pcf8574.Mask = 0b01111111;

            AppDomain.CurrentDomain.ProcessExit += delegate { pcf8574[7] = true; };
        }
        public override bool Enabled { 
            get => _pcf8574[7]; 
            set => _pcf8574[7] = value;
        }

    }
}