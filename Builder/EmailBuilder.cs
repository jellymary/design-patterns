using System;
using System.Collections.Generic;
using System.Linq;

namespace Builder
{
    public interface IEmailRecipientsBuilder
    {
        IEmailOptionalFieldsBuilder AddRecipients(params Recipient[] recipients);
    }

    public interface IEmailOptionalFieldsBuilder : IFinalEmailBuilder
    {
        IEmailOptionalFieldsBuilder AddSubject(string subject);
        IEmailOptionalFieldsBuilder AddCopyRecipients(params Recipient[] copyRecipients);
    }

    public interface IFinalEmailBuilder
    {
        string GetEmailToSend { get; }
    }

    public class EmailBuilder
    {
        public IEmailRecipientsBuilder AddBody(string emailBody) => new EmailRecipientsBuilder(emailBody);

        private class EmailRecipientsBuilder : IEmailRecipientsBuilder
        {
            private readonly string body;

            public EmailRecipientsBuilder(string body) => this.body = body;

            public IEmailOptionalFieldsBuilder AddRecipients(params Recipient[] recipients)
            {
                if (recipients.Length < 1)
                {
                    throw new ArgumentException("There must be recipients");
                }

                return new EmailOptionalFieldsBuilder(this.body, recipients);
            }
        }

        private class EmailOptionalFieldsBuilder : IEmailOptionalFieldsBuilder
        {
            private string Body { get; }
            private Recipient[] Recipients { get; }
            private string Subject { set; get; }
            private Recipient[] CopyRecipients { set; get; }

            public EmailOptionalFieldsBuilder(string body, Recipient[] recipients)
            {
                Body = body;
                Recipients = recipients;
            }

            public IEmailOptionalFieldsBuilder AddSubject(string subject)
            {
                if (Subject == null) Subject = subject;
                return this;
            }

            public IEmailOptionalFieldsBuilder AddCopyRecipients(params Recipient[] copyRecipients)
            {
                if (CopyRecipients == null) CopyRecipients = copyRecipients;
                return this;
            }

            public string GetEmailToSend => string.Join('\n',
                $"To: {string.Join("; ", Recipients.Select(r => r.ToString()))}",
                $"CopyTo: {string.Join("; ", CopyRecipients.Select(r => r.ToString()))}",
                $"Subject: {Subject}",
                new string('~', 10),
                Body
            );
        }
    }
}