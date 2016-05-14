using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstarctFactory
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    //абстрактыный класс оружие
    abstract class Weapon
    {
        public abstract void Hit();
    }

    //абтрактный класс движеия
    abstract class Movement
    {
        public abstract void Move();
    }

    //клас арбалет
    class Arbalet:Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арблета");
        }
    }
    //класс меч
    class Sword:Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем мечем");
        }
    }
    //движение бег
    class RunMovement:Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }
    //полет
    class FlyMovement:Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }

    //абстрактная фабрика
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWaapon();
    }
    //летун с арболетом
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }
        public override Weapon CreateWaapon()
        {
            return new Arbalet();
        }
    }
    class HumanFactory : HeroFactory
    {
        public override Weapon CreateWaapon()
        {
            return new Sword();
        }
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }
    }
    //клиент - маин хиро
    class Hero
    {
        private Weapon weapon;
        private Movement movement;
        public Hero(HeroFactory fatory)
        {
            weapon = fatory.CreateWaapon();
            movement = fatory.CreateMovement();
        }
        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
}
