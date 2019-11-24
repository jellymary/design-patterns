using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    public abstract class BanknoteHandler
    {
        private readonly BanknoteHandler _nextHandler;

        protected BanknoteHandler(BanknoteHandler nextHandler) => _nextHandler = nextHandler;

        public virtual bool Validate(IBanknote banknote) => _nextHandler != null && _nextHandler.Validate(banknote);

        public virtual void CashOut(List<(int value, int count)> cashOutAmount, IBanknote banknote)
        {
            _nextHandler?.CashOut(cashOutAmount, banknote);
        }
    }

    public abstract class BanknoteHandlerBase : BanknoteHandler
    {
        protected abstract int Value { get; }
        protected abstract CurrencyType Currency { get; }

        public override bool Validate(IBanknote banknote)
        {
            return banknote.Value == Value && banknote.Currency == Currency || base.Validate(banknote);
        }

        public override void CashOut(List<(int value, int count)> cashOutAmount, IBanknote banknote)
        {
            if (banknote.Currency == Currency && banknote.Value >= Value)
            {
                var b = banknote.Value / Value;
                cashOutAmount.Add((Value, b));
                base.CashOut(cashOutAmount, new Banknote(banknote.Value - b * Value, banknote.Currency));
                return;
            }
            base.CashOut(cashOutAmount, banknote);
        }
        
        protected BanknoteHandlerBase(BanknoteHandler nextHandler) : base(nextHandler) {}
    }  

    public class ErrorHandler : BanknoteHandler
    {
        public ErrorHandler(BanknoteHandler nextHandler) : base(nextHandler) {}

        public override void CashOut(List<(int value, int count)> cashOutAmount, IBanknote banknote)
        {
            if (banknote.Value != 0) throw new Exception("The bancomat can not issue such an amount");
        }
    }
}
