using System;

namespace singleton_pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Singleton s = Singleton.GetInstance;
            s.congig("data");
        }
    }
}