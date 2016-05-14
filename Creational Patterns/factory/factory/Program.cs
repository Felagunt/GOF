using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory fact = new TripleFactory("Morgan");
            Vechicle vechicle = fact.Create();

            fact = new FourWheelFactory("Triumph");
            Vechicle vechicle2 = fact.Create();

            Console.ReadKey();
        }
    }

    abstract class Factory
    {
        public string Name { get;set;}

        public Factory(string n)
        {
            Name = n;
        }

        abstract public Vechicle Create();
    }

   class TripleFactory:Factory
    {
        public TripleFactory(string n):base(n)
        { }

        public override Vechicle Create()
        {
            return new TripleCycle();
        }
    }
    class FourWheelFactory:Factory
    {
        public FourWheelFactory(string n) : base(n)
        { }

        public override Vechicle Create()
        {
            return new FourWheelsCar();
        }
    }

    abstract class Vechicle
    { }
    class TripleCycle:Vechicle
    {
        public TripleCycle()
        {
            Console.WriteLine("Triplcycle done");
        }
    }
    class FourWheelsCar:Vechicle
    {
        public FourWheelsCar()
        {
            Console.WriteLine("4wheelsCar done");
        }
    }
}
