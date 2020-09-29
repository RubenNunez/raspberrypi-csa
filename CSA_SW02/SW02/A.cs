namespace SW01.SW02
{
    public class A
    {
        public delegate void Notifier(object sender);

        public event Notifier Greetings;

        public void Invoke()
        {
            Greetings?.Invoke(this);
        }
    }
}