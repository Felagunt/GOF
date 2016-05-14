using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLike
{
    class Program
    {
        static void Main(string[] args)
        {
            Programmer programmer = new Programmer();
            Tester tester = new Tester();
            Marketolog marketolog = new Marketolog();
            List<ICommand> commands = new List<ICommand>
            {
                new CodeCommand(programmer),
                new TestCommand(tester),
                new AdvertizeCommand(marketolog)
            };
            Manager manager = new Manager();
            manager.SetCommand(new MacroCommand(commands));
            manager.StartProject();
            manager.StopProject();

            Console.ReadKey();
        }
    }
    interface ICommand
    {
        void Execute();
        void Undo();
    }
    //class 
    class MacroCommand:ICommand
    {
        List<ICommand> commands;
        public MacroCommand(List<ICommand> coms)
        {
            commands = coms;
        }
        public void Execure()
        {
            foreach (ICommand c in commands)
                c.Execute();
        }
        public void Undo()
        {
            foreach (ICommand c in commands)
                c.Undo();
        }
    }
    class Programmer
    {
        public void StartCoding()
        {
            Console.WriteLine("Start write code");
        }
        public void StopCoding()
        {
            Console.WriteLine("Stop write code");
        }
    }
    class Tester
    {
        public void StartTest()
        {
            Console.WriteLine("Test's start");
        }
        public void StopTest()
        {
            Console.WriteLine("Test's ended");
        }
    }
    class Marketolog
    {
        public void StartAdvertize()
        {
            Console.WriteLine("Advertizing start");
        }
        public void StopAdvertize()
        {
            Console.WriteLine("Advertized stoped");
        }
    }


    class CodeCommand : ICommand
    {
        Programmer programmer;
        public CodeCommand(Programmer p)
        {
            programmer = p;
        }
        public void Execute()
        {
            programmer.StartCoding();
        }
        public void Undo()
        {
            programmer.StartCoding();
        }
    }
    class TestCommand : ICommand
    {
        Tester tester;
        public TestCommand(Tester t)
        {
            tester = t;
        }
        public void Execute()
        {
            tester.StartTest();
        }
        public void Undo()
        {
            tester.StopTest();
        }
    }
    class AdvertizeCommand : ICommand
    {
        Marketolog marketolog;
        public AdvertizeCommand(Marketolog m)
        {
            marketolog = m;
        }
        public void Execute()
        {
            marketolog.StartAdvertize();
        }
        public void Undo()
        {
            marketolog.StopAdvertize();
        }
    }

    class Manager
    {
        ICommand command;
        public void SetCommand(ICommand com)
        {
            command = com;
        }
        public void StartProject()
        {
            if (command != null)
                command.Execute();
        }
        public void StopProject()
        {
            if (command != null)
                command.Undo();
        }
    }
}
