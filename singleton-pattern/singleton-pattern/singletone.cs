using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton_pattern
{
    public sealed class Singleton
    {
        //private static int c = 0;
        //private static Singleton instance = null;
        //private Singleton()
        //{
        //    c++;
        //    Console.WriteLine(c);
        //}

        //public static Singleton GetInstance
        //{
        //    get
        //    {
        //        if (instance == null)
        //            instance = new Singleton();
        //        return instance;
        //    }
        //}


        private Singleton()
        {
        }

        public static Singleton Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly Singleton instance = new Singleton();
        }
        public  void congig(string message)
        {
            Console.WriteLine(message);
        }
    }
}

