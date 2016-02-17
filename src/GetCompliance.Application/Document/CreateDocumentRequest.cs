using System.IO;

namespace GetCompliance.Application.Document
{
    public class CreateDocumentRequest
    {
        public string Name { get; set; }
        public Stream Bytes { get; set; }
    }
}