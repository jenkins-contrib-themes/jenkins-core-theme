using System.IO;

namespace GetCompliance.Application.Email
{
    public class CreateEmailRequest
    {
        public string Name { get; set; }
        public Stream File { get; set; }
    }
}