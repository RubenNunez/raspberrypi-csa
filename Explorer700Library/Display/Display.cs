// ----------------------------------------------------------------------------
// CSA - C# in Action
// (c) 2020, Christian Jost, HSLU
// ----------------------------------------------------------------------------

using System.Drawing;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace Explorer700Library.Display
{
    public class Display
    {
        #region members
        private SSD1306 disp;
        private IGpioPin cs;
        private IGpioPin res;
        private IGpioPin dnc;
        private Bitmap bitmap;
        #endregion

        #region constructor & destructor
        public Display()
        {
            cs = Pi.Gpio[P1.Pin24];                 // GPIO8 = Pin 24
            cs.PinMode = GpioPinDriveMode.Output;   // use pin as ouptut pin
            cs.Write(false);

            res = Pi.Gpio[P1.Pin35];                // GPI19 = Pin 35
            res.PinMode = GpioPinDriveMode.Output;  // use pin as ouptut pin
            res.Write(true);
            Thread.Sleep(10);
            res.Write(false);
            Thread.Sleep(10);
            res.Write(true);

            dnc = Pi.Gpio[P1.Pin36];                // GPI16 = Pin 36
            dnc.PinMode = GpioPinDriveMode.Output;  // use pin as ouptut pin
            dnc.Write(false);

            I2CtoSPI spiDevice = new I2CtoSPI(0, 0);
            disp = new SSD1306(spiDevice,
                SSD1306.DisplayModel.Display128X64, SSD1306.VccSourceMode.Switching);

            bitmap = new Bitmap(128, 64);
            Graphics = Graphics.FromImage(bitmap);
            Clear();
        }
        #endregion

        #region properties
        public Graphics Graphics
        {
            get;
        }
        #endregion

        #region methods
        public void Update()
        {
            disp.LoadBitmap(bitmap, 0.5, 0, 0);

            dnc.Write(false);
            disp.SetAddressRange();
            dnc.Write(true);
            disp.Render();
        }

        public void Clean()
        {
            Graphics.Clear(Color.Black);
            disp.BlackPixels();
            disp.ClearPixels();
        }

        public void Clear()
        {
            Graphics.Clear(Color.Black);
            Update();
        }

        public void Invert()
        {
            disp.Invert = !disp.Invert;
        }
        #endregion
    }
}
