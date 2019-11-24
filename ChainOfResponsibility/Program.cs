using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var bancomat = new Bancomat();
            Console.WriteLine(bancomat.CashOut(1415, CurrencyType.Dollar));
            Console.WriteLine(bancomat.CashOut(2110, CurrencyType.Ruble));
            Console.WriteLine(bancomat.CashOut(1285, CurrencyType.Eur));
        }
    }
}