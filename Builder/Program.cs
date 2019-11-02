using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = new EmailBuilder()
                .AddBody("Hello World!")
                .AddRecipients(
                    new Recipient("Bob", "bob@example.com"),
                    new Recipient("Alice", "alice@example.com")
                )
                .AddCopyRecipients(new Recipient("Mallory", "mallory@example.com"))
                .AddSubject("Greeting")
                .GetEmailToSend;
            Console.WriteLine(email);
        }
    }
}