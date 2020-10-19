using System.Drawing;
using CSA_GAME.Engine;

namespace CSA_GAME.Game
{
    public class Character : GameObject
    {
        private const int Speed = 2;
        private Image _run1;
        private Image _run2;
        private Image _idle;

        private bool _isRunning = true;
        private long _steps;

        public override void Start()
        {
            base.Start();
            _idle = Image.FromFile("CSA_GAME/Resources/Dino/_idle.png");
            _run1 = Image.FromFile("CSA_GAME/Resources/Dino/_run1.png");
            _run2 = Image.FromFile("CSA_GAME/Resources/Dino/_run2.png");

            Transform.Position.X = 10;
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            base.Update(ctx, deltaTime);
            if (_isRunning)
                ctx.DrawImage(_steps++ % Speed >= Speed/2 ? _run1 : _run2, Transform.Position.X,
                    Engine.Game.Instance.Scene.Height - (Transform.Position.Y + _idle.Height));
            else
                ctx.DrawImage(_idle, Transform.Position.X, Engine.Game.Instance.Scene.Height - (Transform.Position.Y + _idle.Height));
            
        }
    }
}
