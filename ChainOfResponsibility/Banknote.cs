namespace ChainOfResponsibility
{
    public enum CurrencyType
    {
        Eur = '€',
        Dollar = '$',
        Ruble = '₽'
    }

    public interface IBanknote
    {
        CurrencyType Currency { get; }
        int Value { get; }
    }

    public class Banknote : IBanknote
    {
        public Banknote(int value, CurrencyType currency)
        {
            Value = value;
            Currency = currency;
        }

        public CurrencyType Currency { get; }
        public int Value { get; }
    }
}