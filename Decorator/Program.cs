using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IChatClient chat = new CryptoDecorator(new AnonymousDecorator(new ChatClient()));
            chat.SendMessage(new Message("alice", "bob", "hello!"));
            chat.ReceiveMessage(new Message("alice", "bob", "<code>hello!</code>"));
        }
    }
}