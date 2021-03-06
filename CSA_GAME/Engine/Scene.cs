﻿using System.Drawing;
using CSA_GAME.Game;

namespace CSA_GAME.Engine
{
    public class Scene : GameObject
    {
        public int Width;
        public int Height;

        public static Font Font = new Font(new FontFamily("consolas"), 9, FontStyle.Bold);

        public Scene(int height, int width)
        {
            Height = height - 5;
            Width = width - 5;
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            base.Update(ctx, deltaTime);
            var size = ctx.MeasureString($"{DinoGame.Score:D5}", Font);
            ctx.DrawString($"{DinoGame.Score:D5}", Font, Brushes.White, Width - size.Width, 5);
        }
    }
}
