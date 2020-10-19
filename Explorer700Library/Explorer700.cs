// ----------------------------------------------------------------------------
// CSA - C# in Action
// (c) 2020, Christian Jost, HSLU
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using Explorer700Library.Led;
using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

namespace Explorer700Library
{
    public class Explorer700
    {
        #region members
        public const int ADDR_PCF8574 = 0x20;
        #endregion

        #region constructor & destructor
        public Explorer700()
        {
            Pi.Init<BootstrapWiringPi>();
            Led1 = new LedGpio();
            Pcf8574 = new Pcf8574(ADDR_PCF8574);
            Led2 = new LedI2C(Pcf8574);
            Joystick = new Joystick.Joystick(Pcf8574);
            Buzzer = new Buzzer(Pcf8574);
            Display = new Display.Display();
        }
        #endregion

        #region properties
        public LedBase Led1 { get; }
        public Pcf8574 Pcf8574 { get; }
        public LedBase Led2 { get; }
        public Buzzer Buzzer { get; }
        public Joystick.Joystick Joystick { get; }
        public Display.Display Display { get; }
        #endregion
    }
}
