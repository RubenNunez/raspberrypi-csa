using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace CSA_GAME.Explorer700
{
    public class LedGpio : LedBase
    {
        private readonly IGpioPin _ledGpio;

        public LedGpio()
        {
            _ledGpio = Pi.Gpio[26]; // BCM 12
            _ledGpio.PinMode = GpioPinDriveMode.Output;
        }

        public override bool Enabled
        {
            get => _ledGpio.Read();
            set => _ledGpio.Write(value);
        }
    }
}