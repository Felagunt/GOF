using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            Circle figure = new Circle(30,50,60);
            Circle clonedFigure = figure.DeepCopy() as Circle;
            figure.Point.X = 100;
            figure.GetInfo();
            clonedFigure.GetInfo();
            Console.Read();
        }
    }
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
    [Serializable]
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Rectangle:IFigure
    {
        int width;
        int height;
        public Rectangle(int w,  int h)
        {
            width = w;
            height = h;
        }
        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }
        
        public void GetInfo()
        {
            Console.WriteLine("Прямугольник длиной {0} и шириной {1} ", height,width);
        }
    }
    [Serializable]
    class Circle:IFigure
    {
        int radius;
        public Point Point { get; set; }
        public Circle(int r,int x, int y)
        {
            radius = r;
            this.Point = new Point { X = x, Y = y };
        }
        public IFigure Clone()
        {
            return this.MemberwiseClone() as IFigure;
        }
        public object DeepCopy()
        {
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null,
                    new StreamingContext(StreamingContextStates.Clone));
                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);
                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0}и центро в точке ({1},{2})", radius,Point.X,Point.Y);
        }
    }
}
