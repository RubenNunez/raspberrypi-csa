using System;
using System.Drawing;
using Explorer700Library.Joystick;

namespace CSA_GAME
{
    public static class Test
    {
        public static void Module()
        {
            var exp = new Explorer700Library.Explorer700();

            // Demo Display
            var g = exp.Display.Graphics;
            g.DrawImage(Image.FromFile("CSA_GAME/Resources/test.png"), 0, 0);
            var pen = new Pen(Brushes.Black);
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
