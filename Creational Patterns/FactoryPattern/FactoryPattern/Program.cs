using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    /// <summary>
    /// MainApp startup class
    /// Factory method
    /// </summary>
    class Program
    {
        /// <summary>
        /// entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //note:constuctors call factory method
            Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();

            //display document pages
            foreach(Document document in documents)
            {
                Console.WriteLine("\n" + documents.GetType().Name + ("--");
                foreach(Page page in document.Pages)
                {



                    Console.WriteLine(" " + page.GetType().Name);
                }
            }

            //wait for user
            Console.ReadKey();
        }
    }
    ///<summary>
    /// ptoduct abstract class
    /// </summary>
    /// 
    abstract class Page
    { }
    ///<summary>
    /// concreteProduct class
    /// </summary>
    /// 
    class SkillsPage : Page
    { }
    ///<summary>
    /// concreteProduct
    /// </summary>
    /// 
    class EducationPage : Page
    { }
    ///<summary>
    /// concreteProduct class
    /// </summary>
    class ExperiencePage : Page
    { }
    ///<summary>
    /// concreteProduct class
    /// </summary>
    class ResultPage : Page
    { }
    ///<summary>
    /// concreteProduct class
    /// </summary>
    class ConclusionPage : Page
    { }
    ///<summary>
    /// concreteProduct class
    /// </summary>
    class BibliographyPage : Page
    { }
    ///<summary>
    /// concreteProduct class
    /// </summary>
    class IntroductionPage : Page
    { }
    ///<summary>
    /// concreteProduct class
    /// </summary>
    class SummaryPage : Page
    { }


    ///<summary>
    /// creator abstract class
    /// </summary>
    abstract class Document
    {
        private List<Page> _pages = new List<Page>();
        //constructor calls abstract Factory method
        public Document()
        {
            this.CreatePages();
        }
        public List<Page> Pages
        {
            get { return _pages; }
        }
        //factory method
        public abstract void CreatePages();
    }

    ///<summary>
    /// concreteCreator class
    /// </summary>
    class Resume : Document
    {
        //factory method implementation
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }
    ///<summary>
    /// concreteCreator class
    /// </summary>
    class Report:Document
    {
        //factory method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }
}
