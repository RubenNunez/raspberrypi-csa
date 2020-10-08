using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;

namespace CSA_GAME.Explorer700
{
    public class Pcf8574
    {
        private byte _data;
        private byte _mask;
        private readonly II2CDevice _dev;

        public Pcf8574(int address)
        {
            _dev = Pi.I2C.AddDevice(address);
            Read();
        }
        

        /// <summary>
        /// Setzt eine Maske die dazu führt, dass ausgewählten Bits nie auf 0 gesetzt werden.
        /// </summary>
        public byte Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                Write(_data);
            }
        }

        public bool this[int bit]
        {
            get => (Read() & (1 << bit)) != 0;
            set => Write((byte) (value ? (1 << bit) : 0b00000000));
        }

        /// <summary>
        /// Liest den Zustand der Port-Pins.
        /// </summary>
        /// <returns>1 Byte mit den 8 Zuständen des Ports</returns>
        public byte Read()
        {
            _data = _dev.Read();
            return _data;
        }

        /// <summary>
        /// Setzt die 8 Pins des Port Expanders auf High oder Low
        /// </summary>
        /// <param name="data">1 Byte mit den 8 Zuständen</param>
        public void Write(byte data)
        {
            _data = data;
            _dev.Write((byte)(data | _mask));
        }
    }
}