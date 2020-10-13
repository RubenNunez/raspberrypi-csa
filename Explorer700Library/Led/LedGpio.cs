// ----------------------------------------------------------------------------
// CSA - C# in Action
// (c) 2020, Christian Jost, HSLU
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace Explorer700Library
{
    public class LedGpio : LedBase
    {
        #region members
        private IGpioPin ledPin;
        #endregion

        #region constructor & destructor
        public LedGpio()
        {
            ledPin = Pi.Gpio[26]; // BCM 12
            ledPin.PinMode = GpioPinDriveMode.Output; // use as output
        }
        #endregion

        #region properties
        public override Leds Led => Leds.Led1;
        
        public override bool Enabled
        {
            get { return ledPin.Read(); }
            set { ledPin.Write(value); }
        }
        #endregion
    }
}
