using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace CodeSnippet.ConsoleApp
{
    public class SampleStateMachine
    {
        
    }
    public class MyClass_Enumerator : IEnumerable<int>
    {
        public int state0 = 0;// internal member
        public int current0;  // internal member
        public MyClass this0; // implicit parameter to CountFrom
        public int start;      // explicit parameter to CountFrom
        int i;          // local variable of CountFrom
        
        public int Current
        {
            get { return current0; }
        }


        public bool MoveNext()
        {
            switch (state0)
            {
                case 0: goto resume0;
                case 1: goto resume1;
                case 2: return false;
            }


        resume0:;
            for (i = start; i <= this0.limit; i++)
            {
                current0 = i;
                state0 = 1;
                return true;
                //resume1:;
            }
        resume1:;
            state0 = 2;
            return false;
        }
         public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        
    }
    public class MyClass
    {
        public int limit = 0;
        public MyClass(int limit) { this.limit = limit; }

        public IEnumerable<int> CountFrom(int start)
        {
            for (int i = start; i <= limit; i++)
            {
                yield return i;
            }
        }
        #region under the hood!! "public IEnumerable<int> CountFrom(int start)"
        //public IEnumerable<int> CountFrom(int start)
        //{
        //    MyClass_Enumerator e = new MyClass_Enumerator();
        //    e.this0 = this;
        //    e.start = start;
        //    return e;
        //}
        #endregion
    }
}
