using System;
using System.Drawing;
using CSA_GAME.Engine;
using Explorer700Library.Joystick;

namespace CSA_GAME.Game
{
    public class DinoGame : GameObject
    {
        public static float Speed { private set; get; } = 10f;
        public static int Score { private set; get; }
        public static bool GameOver { private set; get; }
        public static bool CheatMode { private set; get; }

        private long _acc;

        public static Font Font = new Font(new FontFamily("consolas"), 9, FontStyle.Bold);

        public override void Start()
        {
            base.Start();
            Engine.Game.Instance.Explorer700.Joystick.JoystickChanged += Restart;
        }

        private void Restart(object? sender, KeyEventArgs e)
        {
            if (e.Keys == Keys.Center && GameOver)
            {
                GameOver = false;
                Score = 0;
            }
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            base.Update(ctx, deltaTime);

            _acc += deltaTime;
            if (_acc > 100 && !GameOver)
            {
                _acc = 0;
                Score++;
            }

            if (GameOver)
                DrawGameOverScreen(ctx);
        }

        public static void RequestGameOver()
        {
            if(CheatMode) return;
            GameOver = true;
            Console.WriteLine("GameOver");
        }

        public static void RequestCheatMode()
        {
            CheatMode = true;
        }

        private void DrawGameOverScreen(Graphics ctx)
        {
            var size = ctx.MeasureString("GameOver", Font);
            ctx.FillRectangle(new SolidBrush(Color.White), 0,0, Engine.Game.Instance.Scene.Width, Engine.Game.Instance.Scene.Height);
            ctx.DrawString("GameOver", Font, Brushes.Black, Engine.Game.Instance.Scene.Width/2f - size.Width/2, Engine.Game.Instance.Scene.Height/2f - size.Height/2);
            var sizeScore = ctx.MeasureString($"Score {Score}", Font);
            ctx.DrawString($"Score {Score}", Font, Brushes.Black, Engine.Game.Instance.Scene.Width / 2f - size.Width / 2, Engine.Game.Instance.Scene.Height / 2f - size.Height / 2 + 10);
        }
    }
}