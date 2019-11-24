namespace ChainOfResponsibility
{
    public abstract class RubleHandlerBase : BanknoteHandlerBase
    {
        protected override CurrencyType Currency => CurrencyType.Ruble;
        protected RubleHandlerBase(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class ThousandRubleHandler : RubleHandlerBase
    {
        protected override int Value => 1000;
        public ThousandRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class HundredRubleHandler : RubleHandlerBase
    {
        protected override int Value => 100;
        public HundredRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class FiftyRubleHandler : RubleHandlerBase
    {
        protected override int Value => 50;
        public FiftyRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }

    public class TenRubleHandler : RubleHandlerBase
    {
        protected override int Value => 10;
        public TenRubleHandler(BanknoteHandler nextHandler) : base(nextHandler) {}
    }
}