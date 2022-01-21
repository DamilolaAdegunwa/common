using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publico
{
    #region Phone Factory
    public interface PhoneContract
    {
        bool Call(string number);
    }
    //
    public interface IPhoneInterface : PhoneContract
    {
    }
    //
    public class IPhone : IPhoneInterface
    {
        public bool Call(string number)
        {
            Console.WriteLine("From my iPhone");
            return true;
            //throw new NotImplementedException();
        }
    }
    public class Samsung : PhoneContract
    {
        public bool Call(string number)
        {
            Console.WriteLine("from my samsung phone");
            return true;
            //throw new NotImplementedException();
        }
    }
    public class Motorola : PhoneContract
    {
        public bool Call(string number)
        {
            Console.WriteLine("from my Motorola phone");
            return true;
            //throw new NotImplementedException();
        }
    }
    public class PhoneFactory : PhoneFactoryContract
    {
        //there also the part of using constructor injection or
        //mediator to bring in services instead of newing up services
        private readonly IPhoneInterface _phoneInterface;
        public PhoneFactory(IPhoneInterface phoneInterface)
        {
            _phoneInterface = phoneInterface;
        }
        public PhoneContract GetPhone(PhoneType phoneType)
        {
            switch (phoneType)
            {
                //case PhoneType.IPhone: return new IPhone();
                case PhoneType.IPhone: return _phoneInterface;
                case PhoneType.Samsung: return new Samsung();
                case PhoneType.Motorola: return new Motorola();
            }
            throw new Exception("invalid!!");
        }
    }
    public interface PhoneFactoryContract
    {
        PhoneContract GetPhone(PhoneType phoneType);
    }
    public enum PhoneType
    {
        IPhone = 0,
        Samsung = 1,
        Motorola = 2
    }
    #endregion
}
