using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainOfResponsibility
{
    public class Bancomat
    {
        private readonly BanknoteHandler _handler;

        public Bancomat()
        {
            _handler = new ErrorHandler(null);

            _handler = new FiveEuroHandler(_handler);
            _handler = new TenEuroHandler(_handler);
            _handler = new TwentyEuroHandler(_handler);
            _handler = new FiftyEuroHandler(_handler);
            _handler = new HundredEuroHandler(_handler);

            _handler = new TenRubleHandler(_handler);
            _handler = new FiftyRubleHandler(_handler);
            _handler = new HundredRubleHandler(_handler);
            _handler = new ThousandRubleHandler(_handler);

            _handler = new FiveDollarHandler(_handler);
            _handler = new TenDollarHandler(_handler);
            _handler = new TwentyDollarHandler(_handler);
            _handler = new FiftyDollarHandler(_handler);
            _handler = new HundredDollarHandler(_handler);
        }

        public bool Validate(IBanknote banknote) => _handler.Validate(banknote);

        public string CashOut(int value, CurrencyType currency)
        {
            try
            {
                var cashOutAmountList = new List<(int value, int count)>();
                _handler.CashOut(cashOutAmountList, new Banknote(value, currency));
                return $"{value}{(char)currency} = {string.Join(" + ", cashOutAmountList.Select(t => $"{t.value}{(char)currency}*{t.count}"))}";
            }
            catch (Exception)
            {
                return $"Sorry, the bancomat can not cash {value}{(char) currency}";
            }
        }
    }
}
