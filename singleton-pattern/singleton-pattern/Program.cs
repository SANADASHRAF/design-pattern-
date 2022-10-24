using System;

namespace singleton_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Singleton x = Singleton.Instance;
            x.congig("c");
            Singleton y = Singleton.Instance;
            y.congig("d");

        }
    }
}