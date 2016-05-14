using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// facade
/// </summary>
namespace Facade
{
    /// <summary>
    /// entry point
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            CLR clr = new CLR();

            VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);

            Programmer programmer = new Programmer();
            programmer.CreateApplication(ide);

            //Wait
            Console.ReadKey();
        }
    }
    //component
    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Writing code");
        }
        public void Save()
        {
            Console.WriteLine("Saving code");
        }
    }

    //component
    class Compiller
    {
        public void Compile()
        {
            Console.WriteLine("Compiling code");
        }
        public void Finish()
        {
            Console.WriteLine("Finishing work app");
        }
    }

    //component
    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Application's working");
        }
        public void Finish()
        {
            Console.WriteLine("Finishing works of app");
        }
    }

    //facade
    class VisualStudioFacade
    {
        TextEditor textEditor;
        Compiller compiller;
        CLR clr;
        public VisualStudioFacade(TextEditor te,Compiller cp,CLR clr)
        {
            this.textEditor = te;
            this.compiller = cp;
            this.clr = clr;
        }

        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiller.Compile();
            clr.Execute();
        }
        public void Stop()
        {
            clr.Finish();
        }
    }
    
    //client
    class Programmer
    {
        public void CreateApplication(VisualStudioFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
