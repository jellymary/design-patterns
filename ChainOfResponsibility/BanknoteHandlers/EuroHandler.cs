namespace ChainOfResponsibility
{
    public abstract class EuroHandlerBase : BanknoteHandlerBase
    {
        protected override CurrencyType Currency => CurrencyType.Eur;
        protected EuroHandlerBase(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class HundredEuroHandler : EuroHandlerBase
    {
        protected override int Value => 100;
        public HundredEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class FiftyEuroHandler : EuroHandlerBase
    {
        protected override int Value => 50;
        public FiftyEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class TwentyEuroHandler : EuroHandlerBase
    {
        protected override int Value => 20;
        public TwentyEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class TenEuroHandler : EuroHandlerBase
    {
        protected override int Value => 10;
        public TenEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class FiveEuroHandler : EuroHandlerBase
    {
        protected override int Value => 5;
        public FiveEuroHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }
}