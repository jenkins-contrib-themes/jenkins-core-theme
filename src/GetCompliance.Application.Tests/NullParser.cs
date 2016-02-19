using System.IO;

namespace GetCompliance.Application.Tests
{
    public class NullParser : IDocumentParser
    {
        public Domain.Document Parse(Stream messageStream)
        {
            throw new System.NotImplementedException();
        }
    }
}