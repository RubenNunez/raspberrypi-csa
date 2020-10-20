using System;
using System.Threading;

namespace CSA_GAME.Engine
{
    public class Game
    {
        public static Game Instance { get; set; }
        public bool Running { get; set; }

        private const int TargetFps = 30;
        private static readonly long StartTimeInMs = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        private long _lastTimeInMs = StartTimeInMs;
        private long _currentTimeInMs = StartTimeInMs;
        private long _deltaTimeInMs;
        public Scene Scene { get; }

        public readonly Explorer700Library.Explorer700 Explorer700;

        public Game(Scene scene)
        {
            Explorer700 = new Explorer700Library.Explorer700();
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
                    Thread.Sleep(1000 / TargetFps);

                    _currentTimeInMs = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                    //if (_currentTimeInMs <= _lastTimeInMs + 1000 / TargetFps) continue;

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
            Explorer700.Display.Clean();
            Scene.Update(Explorer700.Display.Graphics, _deltaTimeInMs);
            Explorer700.Display.Update();
        }
    }
}
