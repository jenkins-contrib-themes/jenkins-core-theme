using System.IO;

namespace GetCompliance.Application.EmailParser
{
    public static class EmailParserFactory
    {
        public static IEmailParser CreateEmailParser(string fileName)
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