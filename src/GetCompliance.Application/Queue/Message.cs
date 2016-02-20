using System.IO;

namespace GetCompliance.Application.Queue
{
    public class Message
    {
        public string Filename { get; set; }
        public Stream File { get; set; }
    }
}