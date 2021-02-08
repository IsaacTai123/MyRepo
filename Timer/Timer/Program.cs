using System;

namespace Timer
{
    class Program
    {
        public class Timer
        {
            private int _second = 0;

            public Timer(int s)
            {
                _second = s;
            }

            public int Minutes
            {
                get { return _second / 60; }
                set
                {
                    _second += value * 60;
                }
            }

            public int Seconds
            {
                get { return _second % 60; }
                set
                {
                    _second += value;
                }
            }
        }
        static void Main(string[] args)
        {
            Timer t = new Timer(699);
            Console.WriteLine("{0}:{1}", t.Minutes, t.Seconds);
            t.Seconds = 10;
            Console.WriteLine("{0}:{1}", t.Minutes, t.Seconds);
            t.Minutes = 19;
            Console.WriteLine("{0}:{1}", t.Minutes, t.Seconds);
        }
    }
}
