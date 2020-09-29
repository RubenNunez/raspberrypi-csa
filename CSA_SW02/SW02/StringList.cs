namespace SW01.SW02
{
    public class StringList
    {
        private int _size;
        public int Size
        {
            get => _size;
            set
            {
                _size = value;
                Data = new string[_size];
            }
        }

        public string[] Data { get; private set; }

        public string this[int i]
        {
            get => Data[i];
            set => Data[i] = value;

        }
    }
}