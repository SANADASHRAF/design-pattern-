using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternn
{
    class Program
    {
        static void Main(string[] args)
        {
            #region strategy pattern
            batta b1 = new batta1();
            b1.perform();
            Console.WriteLine("//////////////////////");
            batta b2 = new batta2();
            b2.perform();
            ((batta1)b1).shot();
            b1.perform();
            #endregion
        }
    }
    #region strategy pattern
    public abstract class batta
    {
        private static int id = 1;
        private string name = "batta";

        //member variable
        protected flybehavior myflybehavior;

        public batta()
        {
            Console.WriteLine("i'm" + name + id);
            id++;
            this.myflybehavior = new flywithwings();
        }
        public string swim()
        {
            return "i'm swim ";
        }

        public abstract string disply();

        public void perform()
        {
            Console.WriteLine(this.swim());
            Console.WriteLine(this.disply());
            Console.WriteLine(this.myflybehavior.fly());

        }
    }

    public class batta1 : batta
    {

        public override string disply()
        {
            return "i'm real batta";
        }

        public void shot()
        {
            this.myflybehavior = new nofly();
        }
    }

    public class batta2 : batta
    {
        public batta2()
        {
            this.myflybehavior = new nofly();
        }
        public override string disply()
        {
            return "i'm toy batta";
        }

    }
    public interface flybehavior
    {
        string fly();
    }
    public class nofly : flybehavior
    {
        public string fly()
        {
            return "i can't fly";
        }
    }

    public class flywithwings : flybehavior
    {
        public string fly()
        {
            return "i fly with my wings";
        }
    }
    #endregion
}
