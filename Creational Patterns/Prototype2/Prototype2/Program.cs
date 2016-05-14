using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype2
{
    /// <summary>
    /// MinApp startup class 
    /// Prototype design pattern
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry poin into console application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ColorManager colormanager = new ColorManager();
            //initialize with standard colors
            colormanager["red"] = new Color(255, 0, 0);
            colormanager["green"] = new Color(0, 255, 0);
            colormanager["blue"] = new Color(0, 0, 255);

            //user clones personalized colors
            colormanager["angry"] = new Color(255, 54, 0);
            colormanager["peace"] = new Color(128, 211, 128);
            colormanager["flame"] = new Color(211, 34, 20);

            //user clones selected colors
            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;

            //wait for user
            Console.ReadKey();
        }
    }
    ///<summary>
    /// the prototype abstract class
    /// </summary>
    /// 
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    ///<summary>
    /// the concreteprototype class
    /// </summary>
    /// 
    class Color:ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;
        //constructor
        public Color(int red,int green,int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }
        //create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine(
                "Cloning color RGB: {0,3},{1,3},{2,3}",
                _red, _green, _blue);
            return this.MemberwiseClone() as ColorPrototype;
        }
    }
    ///<summary>
    /// prototype manager
    /// </summary>
    /// 
    class ColorManager
    {
        private Dictionary<string, ColorPrototype> _colors =
            new Dictionary<string, ColorPrototype>();
        //indexer
        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}
