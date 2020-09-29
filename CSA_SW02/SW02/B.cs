using System;

namespace SW01.SW02
{
    public class B
    {
        public B()
        {
            var a = new A();
            a.Greetings += sender => Console.WriteLine(GetType());
            a.Invoke();
        }
    }
}