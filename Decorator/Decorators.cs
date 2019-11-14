using System;
using System.Text;

namespace Decorator
{
    public class ChatDecoratorBase : IChatClient
    {
        private readonly IChatClient decoratedChatClient;

        protected ChatDecoratorBase(IChatClient chatClient) => decoratedChatClient = chatClient;

        public void SendMessage(Message message) => decoratedChatClient.SendMessage(ToSentMessage(message));

        public void ReceiveMessage(Message message) => decoratedChatClient.ReceiveMessage(ToReceivedMessage(message));

        protected virtual Message ToSentMessage(Message message) => message;

        protected virtual Message ToReceivedMessage(Message message) => message;
    }

    public class AnonymousDecorator : ChatDecoratorBase
    {
        private readonly Func<string, string> anonymizer;

        public AnonymousDecorator(IChatClient chatClient) : base(chatClient) => anonymizer = user => "<anonymous>";

        protected override Message ToSentMessage(Message message)
        {
            message.From = anonymizer(message.From);
            return message;
        }
    }

    public class CryptoDecorator : ChatDecoratorBase
    {
        private readonly Func<string, string> encrypt;
        private readonly Func<string, string> decrypt;

        public CryptoDecorator(IChatClient chatClient) : base(chatClient)
        {
            encrypt = s => $"<code>{s}</code>";
            decrypt = s => s.StartsWith("<code>") && s.EndsWith("</code>") ? s.Substring(6, s.Length - 13) : s;
        }

        protected override Message ToSentMessage(Message message)
        {
            message.Text = encrypt(message.Text);
            return message;
        }

        protected override Message ToReceivedMessage(Message message)
        {
            message.Text = decrypt(message.Text);
            return message;
        }
    }
}