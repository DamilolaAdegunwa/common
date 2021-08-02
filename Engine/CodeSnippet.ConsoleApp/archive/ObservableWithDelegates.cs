using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.ConsoleApp.Sample1
{
    public class ObservableWithDelegates
    {
    }

    class Observable
    {
        public event EventHandler SomethingHappened;

        public void DoSomething() => SomethingHappened?.Invoke(this, EventArgs.Empty);

        //public void DoSomething()
        //{
        //    var handler = SomethingHappened;
        //    if (handler != null)
        //    {
        //        handler(this, EventArgs.Empty);
        //    }
        //}
    }

    class Observer
    {
        public void HandleEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Something happened to " + sender);
        }
    }

    class Test
    {
        static void MainTest()
        {
            Observable observable = new Observable();
            Observer observer = new Observer();
            observable.SomethingHappened += observer.HandleEvent;

            observable.DoSomething();
        }
    }
}

namespace CodeSnippet.ConsoleApp.Sample2
{
    public class ObservableClass
    {
        private Int32 _Value;

        public Int32 Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    OnValueChanged();
                }
            }
        }

        public event EventHandler ValueChanged;

        protected void OnValueChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, EventArgs.Empty);
        }
    }

    public class ObserverClass
    {
        public ObserverClass(ObservableClass observable)
        {
            observable.ValueChanged += TheValueChanged;
        }

        private void TheValueChanged(Object sender, EventArgs e)
        {
            Console.Out.WriteLine("Value changed to " +
                ((ObservableClass)sender).Value);
        }
    }

    public class ProgramClass
    {
        public static void MainClass()
        {
            ObservableClass observable = new ObservableClass();
            ObserverClass observer = new ObserverClass(observable);
            observable.Value = 10;
        }
    }
}

namespace CodeSnippet.ConsoleApp.Sample3
{
    public class Publisher//main publisher class which will invoke methods of all subscriber classes
    {
        public delegate void TickHandler(Publisher m, EventArgs e); //declaring a delegate
        public TickHandler Tick;     //creating an object of delegate
        public EventArgs e = null;   //set 2nd paramter empty
        public void Start()     //starting point of thread
        {
            while (true)
            {
                System.Threading.Thread.Sleep(300);
                if (Tick != null)   //check if delegate object points to any listener classes method
                {
                    Tick(this, e);  //if it points i.e. not null then invoke that method!
                }
            }
        }
    }
    public class Subscriber1//1st subscriber class
    {
        public void Subscribe(Publisher m)  //get the object of pubisher class
        {
            m.Tick += HeardIt;              //attach listener class method to publisher class delegate object
        }
        private void HeardIt(Publisher m, EventArgs e)   //subscriber class method
        {
            System.Console.WriteLine("Heard It by Listener");
        }

    }
    public class Subscriber2//2nd subscriber class
    {
        public void Subscribe2(Publisher m)    //get the object of pubisher class
        {
            m.Tick += HeardIt;               //attach listener class method to publisher class delegate object
        }
        private void HeardIt(Publisher m, EventArgs e)   //subscriber class method
        {
            System.Console.WriteLine("Heard It by Listener2");
        }

    }
    class Test3
    {
        static void MainTest3()
        {
            Publisher m = new Publisher();//create an object of publisher class which will later be passed on subscriber classes
            Subscriber1 l = new Subscriber1();//create object of 1st subscriber class
            Subscriber2 l2 = new Subscriber2();//create object of 2nd subscriber class
            l.Subscribe(m);     //we pass object of publisher class to access delegate of publisher class
            l2.Subscribe2(m);   //we pass object of publisher class to access delegate of publisher class

            m.Start();          //starting point of publisher class
        }
    }
}
namespace ObservablePattern
{
    using System;
    using System.Collections.Generic;

    internal static class Program
    {
        private static void MainProgram()
        {
            var observable = new Observable();
            var anotherObservable = new AnotherObservable();

            using (IObserver observer = new Observer(observable))
            {
                observable.DoSomething();
                observer.Add(anotherObservable);
                anotherObservable.DoSomething();
            }

            Console.ReadLine();
        }
    }

    internal interface IObservable
    {
        event EventHandler SomethingHappened;
    }

    internal sealed class Observable : IObservable
    {
        public event EventHandler SomethingHappened;

        public void DoSomething()
        {
            var handler = this.SomethingHappened;

            Console.WriteLine("About to do something.");
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }

    internal sealed class AnotherObservable : IObservable
    {
        public event EventHandler SomethingHappened;

        public void DoSomething()
        {
            var handler = this.SomethingHappened;

            Console.WriteLine("About to do something different.");
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }

    internal interface IObserver : IDisposable
    {
        void Add(IObservable observable);

        void Remove(IObservable observable);
    }

    internal sealed class Observer : IObserver
    {
        private readonly Lazy<IList<IObservable>> observables =
            new Lazy<IList<IObservable>>(() => new List<IObservable>());

        public Observer()
        {
        }

        public Observer(IObservable observable) : this()
        {
            this.Add(observable);
        }

        public void Add(IObservable observable)
        {
            if (observable == null)
            {
                return;
            }

            lock (this.observables)
            {
                this.observables.Value.Add(observable);
                observable.SomethingHappened += HandleEvent;
            }
        }

        public void Remove(IObservable observable)
        {
            if (observable == null)
            {
                return;
            }

            lock (this.observables)
            {
                observable.SomethingHappened -= HandleEvent;
                this.observables.Value.Remove(observable);
            }
        }

        public void Dispose()
        {
            for (var i = this.observables.Value.Count - 1; i >= 0; i--)
            {
                this.Remove(this.observables.Value[i]);
            }
        }

        private static void HandleEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Something happened to " + sender);
        }
    }
}
namespace CodeSnippet.ConsoleApp.Sample4
{
    public class Stock
    {

        //declare a delegate for the event
        public delegate void AskPriceChangedHandler(object sender,
              AskPriceChangedEventArgs e);
        //declare the event using the delegate
        public event AskPriceChangedHandler AskPriceChanged;

        //instance variable for ask price
        object _askPrice;

        //property for ask price
        public object AskPrice
        {

            set
            {
                //set the instance variable
                _askPrice = value;

                //fire the event
                OnAskPriceChanged();
            }

        }//AskPrice property

        //method to fire event delegate with proper name
        protected void OnAskPriceChanged()
        {

            AskPriceChanged(this, new AskPriceChangedEventArgs(_askPrice));

        }//AskPriceChanged

    }//Stock class

    //specialized event class for the askpricechanged event
    public class AskPriceChangedEventArgs : EventArgs
    {

        //instance variable to store the ask price
        private object _askPrice;

        //constructor that sets askprice
        public AskPriceChangedEventArgs(object askPrice) { _askPrice = askPrice; }

        //public property for the ask price
        public object AskPrice { get { return _askPrice; } }

    }//AskPriceChangedEventArgs
}
namespace AnotherSimpleExample
{
    /**********************Simple Example ***********************/

    class Program
    {
        static void MainSimpleExample(string[] args)
        {
            Parent p = new Parent();
        }
    }

    ////////////////////////////////////////////

    public delegate void DelegateName(string data);

    class Child
    {
        public event DelegateName delegateName;

        public void call()
        {
            delegateName("Narottam");
        }
    }

    ///////////////////////////////////////////

    class Parent
    {
        public Parent()
        {
            Child c = new Child();
            c.delegateName += new DelegateName(print);
            //or like this
            //c.delegateName += print;
            c.call();
        }

        public void print(string name)
        {
            Console.WriteLine("yes we got the name : " + name);
        }
    }
}
namespace OneMore
{
    // interface implementation publisher
    public delegate void eiSubjectEventHandler(eiSubject subject);

    public interface eiSubject
    {
        event eiSubjectEventHandler OnUpdate;

        void GenereteEventUpdate();

    }

    // class implementation publisher
    class ecSubject : eiSubject
    {
        private event eiSubjectEventHandler _OnUpdate = null;
        public event eiSubjectEventHandler OnUpdate
        {
            add
            {
                lock (this)
                {
                    _OnUpdate -= value;
                    _OnUpdate += value;
                }
            }
            remove { lock (this) { _OnUpdate -= value; } }
        }

        public void GenereteEventUpdate()
        {
            eiSubjectEventHandler handler = _OnUpdate;

            if (handler != null)
            {
                handler(this);
            }
        }

    }

    // interface implementation subscriber
    public interface eiObserver
    {
        void DoOnUpdate(eiSubject subject);

    }

    // class implementation subscriber
    class ecObserver : eiObserver
    {
        public virtual void DoOnUpdate(eiSubject subject)
        {
        }
    }
}