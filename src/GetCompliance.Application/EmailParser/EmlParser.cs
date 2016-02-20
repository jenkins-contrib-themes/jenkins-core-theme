using System.IO;

namespace GetCompliance.Application.EmailParser
{
    public class EmlParser : IEmailParser
    {
        public Domain.Email Parse(Stream messageStream)
        {
            var emlMessage = S22.Mail.MailExtension.Load(messageStream);
            return emlMessage.ToGetComplianceEmail();
        }
    }
}