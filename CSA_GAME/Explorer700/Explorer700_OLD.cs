using Unosquare.RaspberryIO;
using Unosquare.WiringPi;

namespace CSA_GAME.Explorer700
{
    public class Explorer700_OLD
    {
        private static readonly Pcf8574 Pcf8574 = new Pcf8574(0x20);

        public LedBase Led1 { get; }
        public LedBase Led2 { get; }

        public Explorer700_OLD()
        {
            Pi.Init<BootstrapWiringPi>();
            Led1 = new LedGpio();
            Led2 = new LedI2C(Pcf8574);
        }
    }
}
