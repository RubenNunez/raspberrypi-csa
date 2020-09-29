using System;
using SW01.SW02;

namespace SW01
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var b = new B();
            
            var stringList = new StringList
            {
                Size = 5, Data = {[0] = "data0", [1] = "data1", [2] = "data2"}, 
                [3] = "Hello"
            };


            foreach (var d in stringList.Data)
            {
                Console.WriteLine(d);
            }
            
            Console.WriteLine(stringList.Size);
        }
    }
}