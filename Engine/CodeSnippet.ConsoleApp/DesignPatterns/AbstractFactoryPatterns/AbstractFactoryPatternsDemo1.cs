using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippet.ConsoleApp.DesignPatterns.AbstractFactoryPatterns
{
    #region Things
    public enum ThingsType
    {
        Metal = 0,
        NonMetal = 1
    }
    public enum ThingsExample
    {
        Gold = 0,
        Silver = 2,
        Bronze = 4,
        //
        Plastic = 1,
        Paper = 3,
        Nylon = 5
    }
    public class ThingsFactoryProducer
    {
        public AbstractThingsFactory GetFactory(ThingsType thingsType)
        {
            switch (thingsType)
            {
                case ThingsType.Metal:
                    return new MetalFactory();
                case ThingsType.NonMetal:
                    return new NonMetalFactory();
            }
            throw new Exception("invalid thing type");
        }
    }
    public abstract class AbstractThingsFactory
    {
        public abstract Things GetThings(ThingsExample example);
    }
    public interface Things
    {
        double GetMass();
    }
    public class MetalFactory : AbstractThingsFactory
    {
        public override Things GetThings(ThingsExample example)
        {
            switch (example)
            {
                case ThingsExample.Gold: return new Gold();
                case ThingsExample.Silver: return new Silver();
                case ThingsExample.Bronze: return new Bronze();
            }
            throw new Exception("invalid metal example");
        }
    }
    public class NonMetalFactory : AbstractThingsFactory
    {
        public override Things GetThings(ThingsExample example)
        {
            switch (example)
            {
                case ThingsExample.Paper: return new Paper();
                case ThingsExample.Plastic: return new Plastic();
                case ThingsExample.Nylon: return new Nylon();
            }
            throw new Exception("invalid non-metal example");
        }
    }
    public class Gold : Things
    {
        public double GetMass()
        {
            return (double)ThingsExample.Gold;
            //throw new NotImplementedException();
        }
    }
    public class Silver : Things
    {
        public double GetMass()
        {
            return (double)ThingsExample.Silver;
            //throw new NotImplementedException();
        }
    }
    public class Bronze : Things
    {
        public double GetMass()
        {
            return (double)ThingsExample.Bronze;
            //throw new NotImplementedException();
        }
    }
    public class Plastic : Things
    {
        public double GetMass()
        {
            return (double)ThingsExample.Plastic;
        }
    }
    public class Paper : Things
    {
        public double GetMass()
        {
            return (double)ThingsExample.Paper;
        }
    }
    public class Nylon : Things
    {
        public double GetMass()
        {
            return (double)ThingsExample.Nylon;
        }
    }
    #endregion
}
