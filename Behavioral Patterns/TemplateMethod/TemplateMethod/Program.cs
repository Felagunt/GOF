using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    abstract class Learning
    {
        public abstract void Learn();
    }

    abstract class Education:Learning
    {
        public sealed override void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }
        public abstract void Enter();
        public abstract void Study();
        public virtual void PassExams()
        {
            Console.WriteLine("Сдаем выпускные экзамены");
        }
        public abstract void GetDocument();
    }
    class School :Education
    {
        public override void Enter()
        {
            Console.WriteLine("Идем в первый класс");
        }

        public override void Study()
        {
            Console.WriteLine("Посешаем уроки, делаем дз");
        }
        public override void GetDocument()
        {
            Console.WriteLine("Получем аттестат о среднем образовнии");
        }
    }

    class University :Education
    {
        public override void Enter()
        {
            Console.WriteLine("Сдаем вступиельные экзамены");
        }
        public override void Study()
        {
            Console.WriteLine("Посещаем лекции");
            Console.WriteLine("Проходим практику");
        }

        public override void PassExams()
        {
            Console.WriteLine("Сдаем госэкзамен");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем диплом о высшем образовании");
        }
    }
}
