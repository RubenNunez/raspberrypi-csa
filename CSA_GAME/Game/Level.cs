﻿using System.Drawing;
using CSA_GAME.Engine;

namespace CSA_GAME.Game
{
    public class Level : GameObject
    {
        private const float Speed = 10f;
        private Image _level;
        private Position _lvl1;

        private bool _isRunning = true;

        public override void Start()
        {
            base.Start();
            _level = Image.FromFile("CSA_GAME/Resources/Level/_level.png");
            _lvl1.X = 0;
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            base.Update(ctx, deltaTime);
            _lvl1.X -= deltaTime / Speed;

            _lvl1.X %= _level.Width - Engine.Game.Instance.Scene.Width - 5;

            ctx.DrawImage(_level, _lvl1.X, Engine.Game.Instance.Scene.Height - (_level.Height + 2));
        }
    }
}
