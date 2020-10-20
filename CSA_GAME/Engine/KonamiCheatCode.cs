using System.Drawing;
using Explorer700Library.Joystick;

namespace CSA_GAME.Engine
{
    public class KonamiCheatCode : GameObject
    {
        private readonly Keys[] _konamiCode = {
            Keys.Up, Keys.Up, Keys.Down, Keys.Down, Keys.Left, Keys.Right, Keys.Left, Keys.Right, Keys.Center,
            Keys.Center
        };

        private bool _foundKonamiCode;
        private int _cursor;

        public override void Start()
        {
            base.Start();
            Game.Instance.Explorer700.Joystick.JoystickChanged += CheatCode;
        }

        private void CheatCode(object? sender, KeyEventArgs e)
        {
            if(e.Keys == Keys.NoKey || _foundKonamiCode) return;

            if (_konamiCode[_cursor] != e.Keys)
            {
                _cursor = 0;
                return;
            }

            _cursor++;

            if (_konamiCode.Length == _cursor + 1)
            {
                _foundKonamiCode = true; // bravo
                Game.Instance.Explorer700.Display.Invert();
            }
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            base.Update(ctx, deltaTime);
            if (_foundKonamiCode)
            {
                //ctx.DrawRectangle(Scene.WhitePen, new Rectangle(5,5, Game.Instance.Scene.Width - 5, 5));
            }
        }
    }
}
