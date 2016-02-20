using System.IO;

namespace GetCompliance.Application.Queue
{
    public class UnparsedEmailMessage
    {
        public string Filename { get; set; }
        public Stream File { get; set; }

        public byte[] ToBytes()
        {

            return new byte[0];
        }
    }
}