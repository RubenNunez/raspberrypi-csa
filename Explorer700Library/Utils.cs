using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Explorer700Library
{
    public static class Utils
    {

        /// <summary>
        /// This function waits until the Debugger has been attached or the Enter Key has been pressed
        /// </summary>
        /// <returns>
        /// true => Debugger is attached
        /// false => Enter Key was pressed
        /// </returns>
        public static bool WaitForDebugger()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1] == "--debug")
            {
                Console.WriteLine("Waiting for Debugger or press <Enter> to continue");
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        return true;
                    }
                    Thread.Sleep(100);
                }
            }
            return false;
        }
    }

}
