using System.IO;

namespace GetCompliance.Application.EmailParser
{
    public class NullParser : IEmailParser
    {
        public Domain.Email Parse(Stream messageStream)
        {
            throw new System.NotImplementedException();
        }
    }
}