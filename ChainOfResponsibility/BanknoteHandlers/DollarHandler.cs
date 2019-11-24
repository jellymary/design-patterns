namespace ChainOfResponsibility
{
    public abstract class DollarHandlerBase : BanknoteHandlerBase
    {
        protected override CurrencyType Currency => CurrencyType.Dollar;
        protected DollarHandlerBase(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class HundredDollarHandler : DollarHandlerBase
    {
        protected override int Value => 100;
        public HundredDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class FiftyDollarHandler : DollarHandlerBase
    {
        protected override int Value => 50;
        public FiftyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class TwentyDollarHandler : DollarHandlerBase
    {
        protected override int Value => 20;
        public TwentyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class TenDollarHandler : DollarHandlerBase
    {
        protected override int Value => 10;
        public TenDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class FiveDollarHandler : DollarHandlerBase
    {
        protected override int Value => 5;
        public FiveDollarHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }
}