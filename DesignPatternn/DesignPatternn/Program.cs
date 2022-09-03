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

            #region strategy pattern example 1
            //batta b1 = new batta1();
            //b1.perform();
            //Console.WriteLine("//////////////////////");
            //batta b2 = new batta2();
            //b2.perform();
            //((batta1)b1).shot();
            //b1.perform();
            //Console.WriteLine("===========end of strategy patern batta=============");
            #endregion

            #region strategy patern example2
            //dog d1 = new german();
            //d1.show();
            //dog d2 = new potpol();
            //d2.show();
            //dog d3 = new wilf();
            //d3.show();
            //Console.WriteLine("===========end of strategy patern dog=============");
            #endregion
            var observer1 = new HRSpecialist("Bill");
            var observer2 = new HRSpecialist("John");
            var provider = new ApplicationsHandler();
            observer1.Subscribe(provider);
            observer2.Subscribe(provider);
            provider.AddApplication(new (1, "Jesus"));
            provider.AddApplication(new (2, "Dave"));
            observer1.ListApplications();
            observer2.ListApplications();
            observer1.Unsubscribe();
            Console.WriteLine();
            Console.WriteLine($"{observer1.Name} unsubscribed");
            Console.WriteLine();

        }

    }
    #region observer pattern

    public class Application//observers
    {
        public int JobId { get; set; }
        public string ApplicantName { get; set; }

        public Application(int jobId, string applicantName)
        {
            JobId = jobId;
            ApplicantName = applicantName;
        }
    }

    ///////////////////////////////////

    public class HRSpecialist : IObserver<Application>
    {
        private IDisposable _cancellation;

        // previous code
        public string Name { get; set; }
        public List<Application> Applications { get; set; }
        public HRSpecialist(string name, List<Application> Applications)
        {
            Name = name;
           this. Applications =Applications ;
        }

        public void ListApplications()
        {
            if (Applications.Any())
                foreach (var app in Applications)
                    Console.WriteLine($"Hey, {Name}! {app.ApplicantName} has just applied for job no. {app.JobId}");
            else
                Console.WriteLine($"Hey, {Name}! No applications yet.");
        }
        //////////////////////
        public virtual void Subscribe(ApplicationsHandler provider)
        {
            _cancellation = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            _cancellation.Dispose();
            Applications.Clear();
        }

        public void OnCompleted()
        {
            Console.WriteLine($"Hey, {Name}! We are not accepting any more applications");
        }

        public void OnError(Exception error)
        {
            // This is called by the provider if any exception is raised, no need to implement it here
        }

        public void OnNext(Application value)
        {
            Applications.Add(value);
        }
    }


    /// //////////////////////////////



    /// /////////////////////////
    public class ApplicationsHandler : IObservable<Application>
    {
        private readonly List<IObserver<Application>> _observers;
        public List<Application> Applications { get; set; }

        public ApplicationsHandler(List<IObserver<Application>> _observers, List<Application> Applications)
        {
            this._observers = _observers;
            this.Applications = Applications;
        }

        public IDisposable Subscribe(IObserver<Application> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);

                foreach (var item in Applications)
                    observer.OnNext(item);
            }

            return new Unsubscriber(_observers, observer);
        }

        public void AddApplication(Application app)
        {
            Applications.Add(app);

            foreach (var observer in _observers)
                observer.OnNext(app);
        }

        public void CloseApplications()
        {
            foreach (var observer in _observers)
                observer.OnCompleted();

            _observers.Clear();
        }
    }


    /// //////////////////////////
    public class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<Application>> _observers;
        private readonly IObserver<Application> _observer;

        public Unsubscriber(List<IObserver<Application>> observers, IObserver<Application> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
    /////////////////////////////////////////////////
    

    #endregion

    #region strategy pattern examble 1
    public abstract class batta
    {
        private static int id = 1;
        private string name = "batta";

        //member variable
        //combosition
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

    #region strategy patern example2
    public abstract class dog
    {
       static int id = 1;
       

        //member variable (acomposion from interface class encapsolate what varus)
        public ferocitybehaviour force;

       public dog()
        {
            Console.WriteLine("i,m " + this.display()+" "+"num "+id );
            id++;
            this.force = new strongforocity();
        }

        public  string sound()
        {
            return "my sound is hoho";
        }

        public string swim()
        {
            return "i,m agood swimmer dog";
        }
        public abstract string display();

        public void show()
        {
            Console.WriteLine(this.force.ferocity());
            Console.WriteLine(this.sound());
            Console.WriteLine(this.swim());
        }
        
    }

    //extended class
     public class german:dog
    {
         public  german()
            {
            this.force = new weekforocity();
            }

        public override string display()
        {
            return "german";
        }
    }

    //extended class
    public class potpol : dog
    {
        public potpol()
        {
            this.force = new mediumforocity();
        }

        public override string display()
        {
            return "potpol";
        }
    }

    //extended class
    public class wilf : dog
    {
        public wilf()
        {
            this.force = new strongforocity();
        }

        public override string display()
        {
            return "wilf";
        }
    }

    ///هنا بقى هطبق الcomposition (هستخدم الانترفيس كلاس ك member variable)
    public interface  ferocitybehaviour
    {
        string ferocity();
    }

    //extended class1
    public class strongforocity:ferocitybehaviour
    {
      public  string ferocity()
        {
            return "strong forocity";
        }
    }

    //extended class2
    public class mediumforocity : ferocitybehaviour
    {
        public string ferocity()
        {
            return "medium forocity";
        }
    }

    //extended class3
    public class weekforocity : ferocitybehaviour
    {
        public string ferocity()
        {
            return "week forocity";
        }
    }
    #endregion
}
