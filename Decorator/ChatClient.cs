using System;

namespace Decorator
{
    public interface IChatClient
    {
        void SendMessage(Message message);

        void ReceiveMessage(Message message);
    }

    public class ChatClient : IChatClient
    {
        public void SendMessage(Message message) => Console.WriteLine(message);

        public void ReceiveMessage(Message message) => Console.WriteLine(message);
    }
}