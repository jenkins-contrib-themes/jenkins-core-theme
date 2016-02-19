using System.IO;

namespace GetCompliance.Application.Tests
{
    public static class DocumentParserFactory
    {
        public static IDocumentParser CreateDocumentParser(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            switch (fileInfo.Extension)
            {
                case ".eml":
                    return new EmlParser();
                default:
                    return new NullParser();
            }
        }
    }
}