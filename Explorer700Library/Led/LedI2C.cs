﻿// ----------------------------------------------------------------------------
// CSA - C# in Action
// (c) 2020, Christian Jost, HSLU
// ----------------------------------------------------------------------------

namespace Explorer700Library.Led
{
    public class LedI2C : LedBase
    {
        #region members
        const int BIT_LED2 = 4;
        #endregion

        #region constructor & destructor
        public LedI2C(Pcf8574 pcf8574)
        {
            Led = Leds.Led2;
            Pcf8574 = pcf8574;
        }
        #endregion

        #region properties
        public Pcf8574 Pcf8574 { get;}

        public override Leds Led { get; }

        public override bool Enabled
        {
            get { return !Pcf8574[BIT_LED2]; }
            set { Pcf8574[BIT_LED2] = !value; }
        }
        #endregion
    }
}
