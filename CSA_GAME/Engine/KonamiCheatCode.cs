using System.Drawing;
using CSA_GAME.Game;
using Explorer700Library.Joystick;

namespace CSA_GAME.Engine
{
    public class KonamiCheatCode : GameObject
    {
        public static Font Font = new Font(new FontFamily("consolas"), 9, FontStyle.Bold);

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
                DinoGame.RequestCheatMode(); _= _foundKonamiCode = true; // bravo
                Game.Instance.Explorer700.Display.Invert();
            }
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            base.Update(ctx, deltaTime);
            if (_foundKonamiCode)
            {
                ctx.DrawString("godmode", Font, Brushes.White, 5, 5);
            }
        }
    }
}
