using System;
using System.Collections.Generic;
using System.Linq;
        using System.Text;
using System.Threading.Tasks;

namespace DesignPatternn
{
    class revision
    {

        #region abstract class
        public abstract class abstraction
        {
            //contain access modifire
            //cintain membars
            //you have all right to override method or not
            //method can not have implemntation in abstract class
            //you can not take object from abstract class
            public int x { set; get; }
            //لازم تورث وهنا بتكون بدون امبليمنتيشن
            public abstract int sum(int a, int b);
            public void print()
            {
                Console.WriteLine("hallo");
            }
        }

        public class s : abstraction
        {
            public override int sum(int a, int b)
            {
                return a * b;
            }
        }
      
        #endregion
        #region interface class
        public interface interfacee
        {
            //not contain access modifire(as all is public)
            //not contain membars
            //you must override method that you right in interface
            //method can not have implemntation in abstract class(defination only)
            //you can not take object     
            //لازم تورث وهنا بتكون بدون امبليمنتيشن
            int sum(int a, int b);

        }

        class f : interfacee
        {
            public int sum(int a, int b)
            {
                return a * b;
            }
        }
        #endregion

        #region polymarphism
        //تعدد الاشكال(one thing have multiple form )
        // مثلا عندك class have function sound  for animal    
        // فدلوقتى عندك كلب وقطة وحمار هل كلهم نفس الصوت لا طبعا هنا بقى يجى مفهوم البوليمرفيزم
        //هيورثو من الكلاس دة وكل واحد هيعمل امبليمنتيشن لفانكشن الصوا دى بطريقة مختلفة حسب استخدامة    
        //فى نوعين compile time(overloading) && run time polymarphism(overriding)
        class sound
        {
            public virtual void so()
            {
                Console.WriteLine("i,m the parent");
            }
        }

        class dog : sound
        {
            public override void so()
            {
                Console.WriteLine("i,m dog");
            }
        }

        class cat : sound
        {
            public override void so()
            {
                Console.WriteLine("i,m cat");
            }
        }
        #endregion

        #region encapsolation(data-hiding.)
        //he variables or data of a class are hidden from any other class and can be accessed ....
        //only through any member function of own class in which they are declared.
        //seter and geter
        public class enc
        {
            private int x { set; get; }
        }
        #endregion
    }
}
