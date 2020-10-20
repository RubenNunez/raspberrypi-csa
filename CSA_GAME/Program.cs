using System;
using System.Diagnostics;
using System.Threading;
using CSA_GAME.Engine;
using CSA_GAME.Game;

// ReSharper disable InconsistentNaming

namespace CSA_GAME
{
    internal class Program
    {
        private const int TIME_WAITING_FOR_DEBUGGER = 20;
        private static Engine.Game _game;
        private static Thread _gameLoop;

        // Build App    dotnet build
        // Run App      dotnet run --project CSA_GAME
        private static void Main(string[] args)
        {
            /*var time = 0;
            Console.WriteLine("waiting for debugger to attach: ");
            while (!Debugger.IsAttached & time < TIME_WAITING_FOR_DEBUGGER)
            {
                Console.Write("▉");
                time++;                    
                Thread.Sleep(1000);
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine("finish waiting for debugger!");*/


            //Console.WriteLine("start testing module.");
            //Test.Module();
            //Console.WriteLine(string.Empty);
            //Console.WriteLine("finish testing module.");


            Console.WriteLine("GameLoop Thread starting");
            var scene = new Scene(64, 128);

            scene.Children.Add(new Level());
            scene.Children.Add(new Character());
            scene.Children.Add(new KonamiCheatCode());
            _game = new Engine.Game(scene);
            _gameLoop = new Thread(_game.Start) {Name = "GameLoop"};
            _gameLoop.Start();
        }
    }
}