using System;
using System.Drawing.Drawing2D;

namespace CSA_GAME.Engine
{
    public class Game
    {
        public static Game Instance { get; set; }
        public bool Running { get; set; }

        private const int TargetFps = 3;
        private static readonly long StartTimeInMs = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        private long _lastTimeInMs = StartTimeInMs;
        private long _currentTimeInMs = StartTimeInMs;
        private long _deltaTimeInMs;
        public Scene Scene { get; }

        private readonly Explorer700Library.Explorer700 _explorer700;

        public Game(Scene scene)
        {
            _explorer700 = new Explorer700Library.Explorer700();
            Scene = scene;
            Instance = this;
        }
        
        public void Start()
        {
            Running = true;
            try
            {
                Scene.Start();

                while (Running)
                {
                    _currentTimeInMs = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    if (_currentTimeInMs <= _lastTimeInMs + 1000 / TargetFps) continue;
                    _deltaTimeInMs = _currentTimeInMs - _lastTimeInMs;
                    _lastTimeInMs = _currentTimeInMs;

                    Draw();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void Draw()
        {
            _explorer700.Display.Clear();
            Scene.Update(_explorer700.Display.Graphics, _deltaTimeInMs);
            _explorer700.Display.Update();
        }
    }
}
