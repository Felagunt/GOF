using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //фабрика 1
            CarFactory bmwCar = new BMWFactory();
            Client c1 = new Client(bmwCar);
            c1.Run();

            //фабрика 2
            CarFactory audiCar = new AudiFactory();
            Client c2 = new Client(audiCar);
            c2.Run();

            Console.Read();
        }
    }
    abstract class CarFactory
    {
        public abstract AbstractCar CreateCar();
        public abstract AbstractEngine CreateEngine();
    }
    class BMWFactory:CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new BMWCar();
        }
        public override AbstractEngine CreateEngine()
        {
            return new BMWEngine();
        }
    }

    class AudiFactory:CarFactory
    {
        public override AbstractCar CreateCar()
        {
            return new AudiCar();
        }
        public override AbstractEngine CreateEngine()
        {
            return new AudiEngine();
        }
    }
    abstract class AbstractEngine
    {
        public int maxSpeed;
    }
    abstract class AbstractCar
    {
        public abstract void MaxSpeed(AbstractEngine engine);
    }
    class BMWCar:AbstractCar
    {
        public override void MaxSpeed(AbstractEngine engine)
        {
            Console.WriteLine("maximum speed: "+engine.maxSpeed.ToString());
        }
    }
    class BMWEngine:AbstractEngine
    {
        public BMWEngine()
        {
            maxSpeed = 200;
        }
    }
    class AudiCar:AbstractCar
    {
        public override void MaxSpeed(AbstractEngine engine)
        {
            Console.WriteLine("maximum speed: "+engine.maxSpeed.ToString());
        }
    }
    class AudiEngine:AbstractEngine
    {
        public AudiEngine()
        {
            maxSpeed = 180;
        }
    }

    class Client
    {
        private AbstractCar abstractCar;
        private AbstractEngine abstractEngine;
        public Client(CarFactory carFactory)
        {
            abstractCar = carFactory.CreateCar();
            abstractEngine = carFactory.CreateEngine();
        }
        public void Run()
        {
            abstractCar.MaxSpeed(abstractEngine);
        }
    }
}
