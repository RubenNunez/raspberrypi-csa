// ----------------------------------------------------------------------------
// CSA - C# in Action
// (c) 2020, Christian Jost, HSLU
// ----------------------------------------------------------------------------

namespace Explorer700Library.Led
{
    public abstract class LedBase
    {
        #region properties
        public abstract Leds Led { get; }

        public abstract bool Enabled { get; set; }
        #endregion

        #region methods
        public void Toggle()
        {
            Enabled = !Enabled;
        }
        #endregion
    }
}
