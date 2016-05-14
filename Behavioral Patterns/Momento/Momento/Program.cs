using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momento
{
    /// <summary>
    /// memento paterns
    /// </summary>
    class Program
    {
        /// <summary>
        /// entyre point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            hero.Shout();//make shout, remain 9 patrons
            GameHistory game = new GameHistory();
            game.History.Push(hero.SaveState());//save state
            hero.Shout();//make shout, remain 8 patrons
            hero.RestoreState(game.History.Pop());
            hero.Shout();//make shout, remain 8 patrons

            //wite
            Console.ReadKey();
        }
    }
    //originator
    class Hero
    {
        private int patrons = 10;//
        private int lives = 5;
        public void Shout()
        {
            if (patrons > 0)
            {
                patrons--;
                Console.WriteLine("Shout.Lost: {0}", patrons);
            }
            else
                Console.WriteLine("Patrons over");
        }
        //save state
        public HeroMemento SaveState()
        {
            Console.WriteLine("Save game. Params: {0} patrons, {1} lives", patrons, lives);
            return new HeroMemento(patrons, lives);
        }
        //
        public void RestoreState(HeroMemento memento)
        {
            this.patrons = memento.Patrons;
            this.lives = memento.Lives;
            Console.WriteLine("Restore. Params: {0} patrons, {1} lives", patrons, lives);
        }
    }
    //Mometo
    class HeroMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }
        public HeroMemento(int patrons,int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }
    //Caretaker
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
