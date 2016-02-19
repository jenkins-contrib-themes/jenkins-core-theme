using System.IO;

namespace GetCompliance.Application.Tests
{
    public class EmlParser : IDocumentParser
    {
        public Domain.Document Parse(Stream messageStream)
        {
            var emlMessage = S22.Mail.MailExtension.Load(messageStream);
            return emlMessage.ToDocument();
        }
    }
}