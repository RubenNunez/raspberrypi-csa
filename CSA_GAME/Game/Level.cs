using System;
using System.Collections.Generic;
using System.Drawing;
using CSA_GAME.Engine;

namespace CSA_GAME.Game
{
    public class Level : GameObject
    {
        public static event EventHandler CactusEntersCriticalZone;

        private Image _level;
        private float _acc;
        private int _randomFactor;
        private Random _random;
        private readonly List<Cactus> _cactuses = new List<Cactus>(5);

        public override void Start()
        {
            _level = Image.FromFile("CSA_GAME/Resources/Level/_level.png");
            Transform.Position.X = 0;
            _random = new Random();

            for (var i = 0; i < 5; i++)
            {
                var cactus = new Cactus();
                _cactuses.Add(cactus);
                Children.Add(cactus);
            }

            base.Start();
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            Transform.Position.X -= deltaTime / DinoGame.Speed;
            Transform.Position.X %= _level.Width - Engine.Game.Instance.Scene.Width - 5;

            ctx.DrawImage(_level, Transform.Position.X, Engine.Game.Instance.Scene.Height - (_level.Height + 2));

            GenerateCactuses(deltaTime);

            base.Update(ctx, deltaTime);
        }

        private void GenerateCactuses(long deltaTime)
        {
            _acc += deltaTime;
            if (_acc > 500 * _randomFactor)
            {
                _acc = 0;
                _randomFactor = _random.Next(2, 2 + (int)DinoGame.Speed);
                var index = _random.Next(0, 5);
                var cactus = _cactuses[index];
                if (cactus.Passed)
                    cactus.Play();
            }
        }

        public static void OnCactusEntersCriticalZone(Cactus cactus)
        {
            CactusEntersCriticalZone?.Invoke(cactus, EventArgs.Empty);
            Console.WriteLine("OnCactusEntersCriticalZone");
        }
    }
}
