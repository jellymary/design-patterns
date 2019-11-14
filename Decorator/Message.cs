namespace Decorator
{
    public class Message
    {
        public Message(string from, string to, string text)
        {
            From = from;
            To = to;
            Text = text;
        }
        public string From { get; set; }
        public string To { get; set; }
        public string Text { get; set; }

        public override string ToString() => $"{From} -> {To}\n{Text}\n";
    }
}