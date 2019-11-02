namespace Builder
{
    public class Recipient
    {
        public readonly string Username;
        public readonly string Address;

        public Recipient(string username, string address)
        {
            Username = username;
            Address = address;
        }

        public override string ToString() => $"{Username} [{Address}]";
    }
}