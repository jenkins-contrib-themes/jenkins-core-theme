using System.IO;

namespace GetCompliance.Application.DocumentParser
{
    public class NullParser : IDocumentParser
    {
        public Domain.Document Parse(Stream messageStream)
        {
            throw new System.NotImplementedException();
        }
    }
}