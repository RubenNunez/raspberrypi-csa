using System;
using System.Collections.Generic;
using System.Text;

namespace CSA_GAME.Explorer700
{
    public abstract class LedBase
    {
        public abstract bool Enabled { get; set; }

        public void Toggle()
        {
            Enabled = !Enabled;
        }
    }
}
