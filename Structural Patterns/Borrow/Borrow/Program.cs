using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrow
{
    /// <summary>
    /// decorator design pattern
    /// </summary>
    class Program
    {
        /// <summary>
        /// entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //crete book
            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            //crete video
            Video video = new Video("Spielberg", "Sunshine", 23, 92);
            video.Display();

            //make video borrowable,then borrow and display
            Console.WriteLine("\nMaking video borrowable:");

            Borrowable borrowvideo = new Borrowable(video);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");

            borrowvideo.Display();

            Console.WriteLine("\nMaking book borrowable");

            Borrowable borrowbook = new Borrowable(book);
            borrowbook.BorrowItem("Writer #1");
            borrowbook.Display();

            //wait
            Console.ReadKey();
        }
    }


    ///<summary>
    /// component abstract class
    /// </summary>
    abstract class LibraryItem
    {
        private int _numCopies;

        //property
        public int NumCopies
        {
            get { return _numCopies; }
            set { _numCopies = value; }
        }

        public abstract void Display();
    }

    ///<summary>
    /// concreteComponent class
    /// </summary>
    class Book : LibraryItem
    {
        private string _author;
        private string _title;

        //constructor
        public Book(string author, string title, int numCopies)
        {
            this._author = author;
            this._title = title;
            this.NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------");
            Console.WriteLine(" Author: {0}", _author);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}\n", NumCopies);
        }
    }

    ///<summary>
    /// concreteComponent class
    /// </summary>
    class Video : LibraryItem
    {
        private string _director;
        private string _title;
        private int _playTime;

        //Constructor
        public Video(string director, string title,
            int numCopies, int playTime)
        {
            this._director = director;
            this._title = title;
            this.NumCopies = numCopies;
            this._playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ------");
            Console.WriteLine(" Director: {0}", _director);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }

    ///<summary>
    /// decorator abstract class
    /// </summary>
    abstract class Decorator : LibraryItem
    {
        protected LibraryItem libraryItem;

        //constructor
        public Decorator(LibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }
        public override void Display()
        {
            libraryItem.Display();
        }
    }

    ///<summary>
    /// concreteDecorator class
    /// </summary>
    class Borrowable:Decorator
    {
        protected List<string> borrowers = new List<string>();

        //constructor
        public Borrowable(LibraryItem libraryItem)
            : base(libraryItem)
        {
        }

        public void BorrowItem(string name)
        {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }

        public override void Display()
        {
            base.Display();

            foreach(string borrower in borrowers)
            {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }
}
