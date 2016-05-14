using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver(false, true, true);

            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymetHandler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
            bankPaymentHandler.Successor = paypalPaymentHandler;
            paypalPaymentHandler.Successor = moneyPaymetHandler;
            bankPaymentHandler.Handle(receiver);
            Console.Read();
        }
    }
    class Receiver
    {
        //банковские переводы
        public bool BankTransfer { get; set; }
        //перевод WU
        public bool MoneyTransfer { get; set; }
        //PayPal
        public bool PayPalTransfer { get; set; }
        public Receiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
    }
    abstract class PaymentHandler
    {
        public PaymentHandler Successor { get; set; }
        public abstract void Handle(Receiver receiver);
    }

    class BankPaymentHandler:PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.BankTransfer == true)
                Console.WriteLine("Выполняем банковский перевод");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    class PayPalPaymentHandler:PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.PayPalTransfer == true)
                Console.WriteLine("Выполняем перевод через PayPal");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    class MoneyPaymentHandler:PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.MoneyTransfer == true)
                Console.WriteLine("перевод в системе WU");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
}
