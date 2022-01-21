using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp.DesignPatterns.FactoryPatterns
{
    #region Shape Factory
    public interface IShape
    {
        void Draw();
    }
    public enum ShapeType
    {
        Cirle = 0,
        Square = 1,
        Rectangle = 2
    }
    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("This is a Circle");
        }
    }
    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("This is a Square");
        }
    }
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("This is a Rectangle");
        }
    }
    public class ShapeFactory
    {
        public IShape GetShape(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Cirle: return new Circle();
                case ShapeType.Square: return new Square();
                case ShapeType.Rectangle: return new Rectangle();
            }
            return null;
        }
    }
    #endregion

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
    public class PhoneFactory
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
    public enum PhoneType
    {
        IPhone = 0,
        Samsung = 1,
        Motorola = 2
    }
    #endregion

    #region Laptop Factory
    public enum LaptopType
    {
        Asus = 0,
        Dell = 1,
        Acer = 2,
        HP = 3,
        Lenovo = 4,
        Mac = 5
    }
    public enum Colour
    {
        Black = 0,
        White = 1
    }
    public interface ILaptopFactory
    {
        ILaptop GetLaptop(LaptopType laptopType);
        ILaptop GetLaptop(LaptopType laptopType, Colour colour);

    }
    public class LaptopFactory : ILaptopFactory
    {
        public LaptopFactory()
        {
            //optional DI
        }
        public ILaptop GetLaptop(LaptopType laptopType)
        {
            switch (laptopType)
            {
                case LaptopType.Acer: return new Acer();
                case LaptopType.Asus: return new Asus();
                case LaptopType.Dell: return new Dell();
                case LaptopType.HP: return new HP();
                case LaptopType.Lenovo: return new Lenovo();
                case LaptopType.Mac: return new Mac();
            }
            return null;
        }

        public ILaptop GetLaptop(LaptopType laptopType, Colour colour)
        {
            switch (laptopType)
            {
                case LaptopType.Acer: return new Acer();
                case LaptopType.Asus: return new Asus(colour);
                case LaptopType.Dell: return new Dell();
                case LaptopType.HP: return new HP();
                case LaptopType.Lenovo: return new Lenovo();
                case LaptopType.Mac: return new Mac();
            }
            return null;
        }
    }

    //optional: interface for each service, possibly implementing the common contract/interface

    public interface ILaptop
    {
        bool StartUp();
    }
    public class Asus : ILaptop
    {
        private readonly Colour _colour;
        public Asus()
        {

        }
        public Asus(Colour colour)
        {
            _colour = colour;
        }
        public bool StartUp()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
    public class Dell : ILaptop
    {
        public bool StartUp()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
    public class Acer : ILaptop
    {
        public bool StartUp()
        {
            Console.WriteLine("The Acer laptop is on!");
            return true;
            //throw new NotImplementedException();
        }
    }
    public class HP : ILaptop
    {
        public bool StartUp()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
    public class Lenovo : ILaptop
    {
        public bool StartUp()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
    public class Mac : ILaptop
    {
        public bool StartUp()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
    #endregion
}
