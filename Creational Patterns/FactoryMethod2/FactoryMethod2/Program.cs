using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productList = new List<Product>();

            Creator[] creators = new Creator[2];
            creators[0] = new ComputerCreator();
            creators[1] = new CDPlayeCreator();

            foreach(Creator cr in creators)
            {
                if (cr is ComputerCreator)
                    productList.Add(cr.FactoryMethod("Custom", 600, 700));

                if (cr is CDPlayeCreator)
                    productList.Add(cr.FactoryMethod("List,Chopin,Pachelbel", 20, 30);
            }

            foreach (Product pr in productList)
            {
                Console.WriteLine("Class's oject {0};\n" +
                    "Desciption: {1};\n" +
                    "Purchase price: {2};\n" +
                    "Price for sale: {3};\n",
                    pr.GetType().Name,
                    pr.Description,
                    pr.PurchasePrice,
                    pr.Price);
            }

            Console.Read();
        }
    }


    abstract class Product
    {
        public abstract decimal PurchasePrice { get; set; }
        public abstract decimal Price { get; set; }
        public abstract string Description { get; set; }
    }


    class Computer : Product
    {
        private decimal _purchase_price;
        private decimal _price;
        private string _description;

        public Computer() : this(null) { }
        public Computer(string _description)
            : this(_description, 0)
        { }
        public Computer(string _description, decimal _purchase_price)
            : this(_description, _purchase_price, 0)
        { }
        public Computer(string _description, decimal _purchase_price,
            decimal _price)
        {
            this._description = _description;
            this._purchase_price = _purchase_price;
            this._price = _price;
        }
        public override string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public override decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public override decimal PurchasePrice
        {
            get { return _purchase_price; }
            set { _purchase_price = value; }
        }
    }

    abstract class Creator
    {
        public abstract Product FactoryMethod();
        public abstract Product FactoryMethod(string _description);
        public abstract Product FactoryMethod(string _description,
            decimal _purchase_price);
        public abstract Product FactoryMethod(string _description,
            decimal _purchase_price, decimal _price);
    }


    class ComputerCreator:Creator
    {
        public override Product FactoryMethod()
        {
            return new Computer();
        }
        public override Product FactoryMethod(string _description)
        {
            return new Computer(_description);
        }
        public override Product FactoryMethod(string _description, decimal _purchase_price)
        {
            return new Computer(_description, _purchase_price);
        }
        public override Product FactoryMethod(string _description, decimal _purchase_price, decimal _price)
        {
            return new Computer(_description, _purchase_price, _price);
        }
    }



    class CDPlayer:Product
    {
        private decimal _purchase_price;
        private decimal _price;
        private string _description;
        public CDPlayer() : this(null) { }
        public CDPlayer(string _desription)
            : this(_desription, 0)
        { }
        public CDPlayer(string _description, decimal _purchase_price)
            : this(_description, _purchase_price, 0)
        { }
        public CDPlayer(string _descrition,decimal _purchase_price,
            decimal _price)
        {
            this._description = _description;
            this._purchase_price = _purchase_price;
            this._price = _price;
        }
        public override string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public override decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public override decimal PurchasePrice
        {
            get { return _purchase_price; }
            set { _purchase_price = value; }
        }
    }


    class CDPlayeCreator:Creator
    {
        public override Product FactoryMethod()
        {
            return new CDPlayer();
        }
        public override Product FactoryMethod(string _description)
        {
            return new CDPlayer(_description);
        }
        public override Product FactoryMethod(string _description, decimal _purchase_price)
        {
            return new CDPlayer(_description, _purchase_price);
        }
        public override Product FactoryMethod(string _description, decimal _purchase_price, decimal _price)
        {
            return new CDPlayer(_description, _purchase_price, _price);
        }
    }
}
