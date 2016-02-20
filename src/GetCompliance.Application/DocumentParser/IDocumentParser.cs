using System.IO;

namespace GetCompliance.Application.DocumentParser
{
    public interface IDocumentParser
    {
        Domain.Document Parse(Stream messageStream);
    }
}