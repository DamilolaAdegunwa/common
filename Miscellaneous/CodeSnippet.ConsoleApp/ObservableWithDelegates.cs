using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet.ConsoleApp
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
        static void Main()
        {
            Observable observable = new Observable();
            Observer observer = new Observer();
            observable.SomethingHappened += observer.HandleEvent;

            observable.DoSomething();
        }
    }
}

namespace CodeSnippet.ConsoleApp
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
