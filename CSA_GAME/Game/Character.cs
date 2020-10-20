#nullable enable
using System;
using System.Drawing;
using CSA_GAME.Engine;
using Explorer700Library.Joystick;

namespace CSA_GAME.Game
{
    public class Character : GameObject
    {
        private const int Speed = 20;
        private const float Ex = 4f;
        private Image? _run1;
        private Image? _run2;
        private Image? _idle;

        private bool _isRunning = true;
        private bool _isGrounded = true;
        private float _motionY = 3;
        private float _startPosY;

        private long _frames;

        public override void Start()
        {
            base.Start();
            _idle = Image.FromFile("CSA_GAME/Resources/Dino/_idle.png");
            _run1 = Image.FromFile("CSA_GAME/Resources/Dino/_run1.png");
            _run2 = Image.FromFile("CSA_GAME/Resources/Dino/_run2.png");

            Transform.Position.X = 10;
            _startPosY = Engine.Game.Instance.Scene.Height - (_idle.Height + 5);
            Transform.Position.Y = _startPosY;

            Engine.Game.Instance.Explorer700.Joystick.JoystickChanged += Jump;
        }

        private void Jump(object? sender, KeyEventArgs e)
        {
            switch (e.Keys)
            {
                case Keys.Up:
                    if (_isGrounded)
                        _motionY = 0;
                    break;
                case Keys.NoKey:
                    if (_motionY < Ex)
                        _isGrounded = false;
                    break;
            }
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            base.Update(ctx, deltaTime);

            if (!_isGrounded)
            {
                _motionY = Math.Clamp(_motionY, 0, Ex);
                Transform.Position.Y = _startPosY - (float) Math.Pow(_motionY - Ex, 2) * _motionY * Ex;
                ctx.DrawImage(_idle, Transform.Position.X, Transform.Position.Y);
                _motionY += deltaTime / 100f;
                if (_motionY >= Ex) 
                    _isGrounded = true;
                return;
            }

            if (_isRunning)
                ctx.DrawImage(_frames++ % Speed >= Speed/2 ? _run1 : _run2, Transform.Position.X,
                    Engine.Game.Instance.Scene.Height - Transform.Position.Y);
            else
                ctx.DrawImage(_idle, Transform.Position.X, Engine.Game.Instance.Scene.Height - Transform.Position.Y);
            
        }
    }
}
