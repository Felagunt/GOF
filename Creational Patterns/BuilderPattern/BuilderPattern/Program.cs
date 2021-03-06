﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    /// <summary>
    /// MainApp startup class 
    /// Builder Design Pattern.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            VehicleBuilder builder;
            //Create shop with vehile builders
            Shop shop = new Shop();
            //Construct and display vehicles
            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            //wait for user
            Console.ReadKey();
        }
        /// <summary>
        /// The builder absract class
        /// </summary>
        abstract class VehicleBuilder
        {
            protected Vehicle vehicle;
            //Get vehicle instance
            public Vehicle Vehicle
            {
                get { return vehicle; }
            }

            //abstract build methods
            public abstract void BuildFrame();
            public abstract void BuildEngine();
            public abstract void BuildWheels();
            public abstract void BuildDoors();
        }
        ///<summary>
        /// the director class
        /// </summary>
        class Shop
        {
            //Builder user a complex series of steps
            public void Construct(VehicleBuilder vehicleBuilder)
            {
                vehicleBuilder.BuildFrame();
                vehicleBuilder.BuildEngine();
                vehicleBuilder.BuildWheels();
                vehicleBuilder.BuildDoors();
            }
        }

        ///<summary>
        /// the conreteBuilder1' class
        /// </summary>
        class MotorCycleBuilder:VehicleBuilder
        {
            public MotorCycleBuilder()
            {
                vehicle = new Vehicle("MotorCycle");
            }

            public override void BuildFrame()
            {
                vehicle["frame"] = "MotorCycle Frame";
            }
            public override void BuildEngine()
            {
                vehicle["engine"] = "500 cc";
            }
            public override void BuildWheels()
            {
                vehicle["wheels"] = "2";
            }
            public override void BuildDoors()
            {
                vehicle["doors"] = "0";
            }
        }
        ///<summary>
        /// the conreteBuilder2 class
        /// </summary>
        class CarBuilder : VehicleBuilder
        {
            public CarBuilder()
            {
                vehicle = new Vehicle("Car");
            }

            public override void BuildFrame()
            {
                vehicle["frame"] = "Car Frame";
            }
            public override void BuildEngine()
            {
                vehicle["engine"] = "2500 cc";
            }
            public override void BuildWheels()
            {
                vehicle["wheels"] = "4";
            }
            public override void BuildDoors()
            {
                vehicle["doors"] = "2";
            }
        }
        ///<summary>
        /// the conreteBuilder3 class
        /// </summary>
        class ScooterBuilder : VehicleBuilder
        {
            public ScooterBuilder()
            {
                vehicle = new Vehicle("Scooter");
            }

            public override void BuildFrame()
            {
                vehicle["frame"] = "Scooter Frame";
            }
            public override void BuildEngine()
            {
                vehicle["engine"] = "50 cc";
            }
            public override void BuildWheels()
            {
                vehicle["wheels"] = "2";
            }
            public override void BuildDoors()
            {
                vehicle["doors"] = "0";
            }
        }

        ///<summary>
        /// the product class
        /// </summary>
        class Vehicle
        {
            private string _vehicleType;
            private Dictionary<string, string> _parts =
                new Dictionary<string, string>();
            //constructor
            public Vehicle(string vehicleType)
            {
                this._vehicleType = vehicleType;
            }
            //indexer
            public string this[string key]
            {
                get { return _parts[key]; }
                set { _parts[key] = value; }
            }
            public void Show()
            {
                Console.WriteLine("\n--------------------");
                Console.WriteLine("Vehicle Type: {0}", _vehicleType);
                Console.WriteLine("Frame: {0}", _parts["frame"]);
                Console.WriteLine("Engine: {0}", _parts["engine"]);
                Console.WriteLine("#Wheels: {0}", _parts["wheels"]);
                Console.WriteLine("#Doors: {0}", _parts["doors"]);
            }
        }

    }
}
