using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confectionery
{
    class Program
    {
        static void Main(string[] args)
        {

            //create an instance of a confectionery shop
            var confectionery = new CityCenterConfectionery();
            //order sweets from the city center confectionery shop
            Console.WriteLine(confectionery.MakeCake().Name);
            confectionery.MakeMuffins(7).ForEach((m) => Console.WriteLine(m.Name));
            confectionery.MakeProfitroles(5).ForEach((p) => Console.WriteLine(p.Name));
        }
    }


    //Abstract Factory
    abstract class Confectionery
    {
        public abstract Cake MakeCake();
        public abstract List<Muffin> MakeMuffins(int number);
        public abstract List<Profiterole> MakeProfitroles(int number);
    }

    //abstract products
    abstract class Muffin
    {
        public string Name { get; protected set; }
    }
    abstract class Cake
    {
        public string Name { get; protected set; }
    }
    abstract class Profiterole
    {
        public string Name { get; protected set; }
    }


    //conctreate products
    class PragueCake:Cake
    {
        public PragueCake(string name)
        {
            Name = name;
        }
    }
    class ChocolateProfiterole:Profiterole
    {
        public ChocolateProfiterole(string name)
        {
            Name = name;
        }
    }
    class FrenchMuffin:Muffin
    {
        public FrenchMuffin(string name)
        {
            Name = name;
        }
    }


    //conctreat factory
    class CityCenterConfectionery:Confectionery
    {
        public override Cake MakeCake()
        {
            return new PragueCake("an amazing Prague Cake");
        }
        public override List<Muffin> MakeMuffins(int number)
        {
            List<Muffin> muffins = new List<Muffin>();
            for(int i=0;i<number;i++)
            {
                muffins.Add(new FrenchMuffin(String.Format("a beautiful French Muffin {0}", i + 1)));
            }
            return muffins;
        }
        public override List<Profiterole> MakeProfitroles(int number)
        {
            List<Profiterole> profiteroles = new List<Profiterole>();
            for (int i=0;i<number;i++)
            {
                profiteroles.Add(new ChocolateProfiterole(String.Format("a lovely Chocolate Profiterol {0}",i+1)));
            }
            return profiteroles;
        }
    }
}
