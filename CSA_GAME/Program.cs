using System;
using System.Diagnostics;
using System.Threading;
// ReSharper disable InconsistentNaming

namespace CSA_GAME
{
    class Program
    {
        private const int TIME_WAITING_FOR_DEBUGGER = 0;

        // Build App    dotnet build
        // Run App      dotnet run --project CSA_GAME
        static void Main(string[] args)
        {
            var time = 0;
            Console.WriteLine("waiting for debugger to attach: ");
            while (!Debugger.IsAttached & time < TIME_WAITING_FOR_DEBUGGER)
            {
                Console.Write("▉");
                time++;                    
                Thread.Sleep(1000);
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine("finish waiting for debugger!");

            var explorer700 = new Explorer700.Explorer700();

            for (var i = 0; i < 7; i++)
            {
                explorer700.Led1.Toggle();
                explorer700.Led2.Toggle();
                Thread.Sleep(250);
            }
        }
    }
}