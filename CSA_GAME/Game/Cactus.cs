#nullable enable
using System;
using System.Drawing;
using CSA_GAME.Engine;

namespace CSA_GAME.Game
{
    public class Cactus : GameObject
    {
        public bool Passed { private set; get; } = true;

        private const float Offset = 10;
        private Image? _cactus;
        private bool _isPlaying;
        private bool _hasInformedCriticalZone;
        private Random? _random;

        public override void Start()
        {
            base.Start();
            _random = new Random();
            _cactus = Image.FromFile(_random.Next(0,100) > 50 
                ? "CSA_GAME/Resources/Cactus/_cactus1.png" : "CSA_GAME/Resources/Cactus/_cactus2.png");
            Transform.Position.X = Engine.Game.Instance.Scene.Width + Offset;
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            base.Update(ctx, deltaTime);
            if(!_isPlaying) return;

            Transform.Position.X -= deltaTime / DinoGame.Speed;

            if (Transform.Position.X + Transform.Position.X + _cactus.Width < 0)
            {
                Passed = true;
                _isPlaying = false;
                Transform.Position.X = Engine.Game.Instance.Scene.Width + Offset;
                return;
            }

            if (Transform.Position.X < 10 && !_hasInformedCriticalZone)
            {
                Level.OnCactusEntersCriticalZone(this);
                _hasInformedCriticalZone = true;
            }

            ctx.DrawImage(_cactus, Transform.Position.X, Engine.Game.Instance.Scene.Height - (_cactus.Height + 2));
        }

        public void Play()
        {
            _isPlaying = true;
            Passed = false;
            _hasInformedCriticalZone = false;
            _cactus = Image.FromFile(_random.Next(0, 100) > 50
                ? "CSA_GAME/Resources/Cactus/_cactus1.png" : "CSA_GAME/Resources/Cactus/_cactus2.png");
        }
    }
}
