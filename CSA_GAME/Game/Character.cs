#nullable enable
using System;
using System.Drawing;
using CSA_GAME.Engine;
using Explorer700Library.Joystick;

namespace CSA_GAME.Game
{
    public class Character : GameObject
    {
        private const int Speed = 15;
        private const float Ex = 15f;
        private Image? _run1;
        private Image? _run2;
        private Image? _crouch1;
        private Image? _crouch2;
        private Image? _idle;

        private bool _isRunning = true;
        private bool _isGrounded = true;
        private bool _isCrouching;
        private float _motion = 3;
        private float _startPosY;
        private float _startPosX;

        private long _frames;

        public override void Start()
        {
            base.Start();
            _idle = Image.FromFile("CSA_GAME/Resources/Dino/_idle.png");
            _run1 = Image.FromFile("CSA_GAME/Resources/Dino/_run1.png");
            _run2 = Image.FromFile("CSA_GAME/Resources/Dino/_run2.png");
            _crouch1 = Image.FromFile("CSA_GAME/Resources/Dino/_crouch1.png");
            _crouch2 = Image.FromFile("CSA_GAME/Resources/Dino/_crouch2.png");

            _startPosX = 10;
            Transform.Position.X = _startPosX;
            _startPosY = Engine.Game.Instance.Scene.Height - (_idle.Height + 5);
            Transform.Position.Y = _startPosY;

            Engine.Game.Instance.Explorer700.Joystick.JoystickChanged += Jump;
            Level.CactusEntersCriticalZone += LevelOnCactusEntersCriticalZone;
        }

        private void LevelOnCactusEntersCriticalZone(object? sender, EventArgs e)
        {
            if(!_isGrounded)
                return;
            DinoGame.RequestGameOver();
        }

        private void Jump(object? sender, KeyEventArgs e)
        {
            switch (e.Keys)
            {
                case Keys.Up:
                    if (_isGrounded)
                        _motion = 0;
                    break;
                case Keys.Down:
                    _isCrouching = true;
                    break;
                case Keys.NoKey:
                    _isCrouching = false;
                    if (_motion < Ex)
                        _isGrounded = false;
                    break;
            }
        }

        public override void Update(Graphics ctx, long deltaTime)
        {
            base.Update(ctx, deltaTime);

            if (!_isGrounded)
            {
                _motion = Math.Clamp(_motion, 0, Ex);
                // (x-ex)^(2) (x)/(ex) -> plot between 0 - ex
                Transform.Position.Y = _startPosY - (float) Math.Pow(_motion - Ex, 2) * (_motion / Ex);
                Transform.Position.X = _startPosX + (float) Math.Pow(_motion - Ex, 2) * (_motion / Ex) * 0.1f;
                ctx.DrawImage(_idle, Transform.Position.X, Transform.Position.Y);
                _motion += deltaTime / 50f;
                if (_motion >= Ex) 
                    _isGrounded = true;
                return;
            }

            if (_isRunning && _isCrouching)
            {
                ctx.DrawImage(_frames++ % Speed >= Speed / 2 ? _crouch1 : _crouch2, Transform.Position.X,
                    Engine.Game.Instance.Scene.Height - Transform.Position.Y);
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
