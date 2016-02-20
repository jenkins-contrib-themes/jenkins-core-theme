using System.Linq;
using System.Net.Mail;

namespace GetCompliance.Application.EmailParser
{
    public static class MailMessageExtensions
    {
        public static Domain.Email ToGetComplianceEmail(this MailMessage message)
        {

            var document = new Domain.Email
            {
                Subject = message.Subject,
                Body = message.Body,
                From = message.From.Address,
                To = message.To.Select(GetAddress),
                BCC = message.Bcc.Select(GetAddress)
            };
            return document;
        }

        private static string GetAddress(MailAddress message)
        {
            return message.Address;
        }

    }
}