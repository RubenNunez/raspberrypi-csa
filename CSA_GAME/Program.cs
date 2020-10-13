using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using Explorer700Library.Joystick;

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

            var explorer700 = new Explorer700.Explorer700_OLD();

            for (var i = 0; i < 7; i++)
            {
                explorer700.Led1.Toggle();
                explorer700.Led2.Toggle();
                Thread.Sleep(250);
            }
        }
        
        static void TEST(string[] args)
        {
            Explorer700Library.Explorer700 exp = new Explorer700Library.Explorer700();

            // Demo Display
            Graphics g = exp.Display.Graphics;
            g.DrawImage(Image.FromFile("./Ressources/test.png"), 0, 0);
            Pen pen = new Pen(Brushes.Black);
            g.DrawEllipse(pen, -10, -10, 30, 30);
            g.DrawEllipse(pen, 30, 10, 10, 10);
            pen.Width = 2;
            g.DrawBezier(pen, new Point(10, 30), new Point(30, 30), new Point(70, 40), new Point(75, 5));
            g.DrawString("Hello .NET Core :-)", new Font(new FontFamily("arial"), 8, FontStyle.Bold), Brushes.Black, new PointF(5, 50));
            exp.Display.Update();

            // Demo Led 1
            Console.WriteLine("Led1: " + exp.Led1.Enabled);
            exp.Led1.Toggle();
            Console.WriteLine("Led1: " + exp.Led1.Enabled);

            // Demo Led 2
            Console.WriteLine("Led2: " + exp.Led2.Enabled);
            exp.Led2.Toggle();
            Console.WriteLine("Led2: " + exp.Led2.Enabled);

            // Demo Joystick
            exp.Joystick.JoystickChanged += Joystick_JoystickChanged;

            // Demo Buzzer
            exp.Buzzer.Beep(200);

            Console.ReadKey();
            exp.Display.Clear();
        }

        private static void Joystick_JoystickChanged(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Joystick: " + e.Keys);
        }
    }
}