using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);

            Console.Read();
        }
    }
    class Book
    {
        public string Name { get; set; }
    }
    interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }
    interface IBookNumerable
    {
        IBookIterator CreateNumerator();
        int Count { get; }
        Book this[int index] { get; }
    }
    class Library : IBookNumerable
    {
        private Book[] books;
        public Library()
        {
            books = new Book[]
            {
                new Book {Name="Alice in wonderland" },
                new Book {Name="Отцы  дети" },
                new Book {Name="Idiot" }
            };
        }

        public int Count
        {
            get { return books.Length; }
        }

        public Book this[int index]
        {
            get { return books[index]; }
        }
        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }

    class LibraryNumerator :IBookIterator
    {
        IBookNumerable aggregate;
        int index = 0;
        public LibraryNumerator(IBookNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }
        public Book Next()
        {
            return aggregate[index++];
        }
    }
    class Reader
    {
        public void SeeBooks(Library library)
        {
            IBookIterator iterator = library.CreateNumerator();
            while(iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }
}
