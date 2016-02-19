using System.IO;

namespace GetCompliance.Application.Tests
{
    public interface IDocumentParser
    {
        Domain.Document Parse(Stream messageStream);
    }
}