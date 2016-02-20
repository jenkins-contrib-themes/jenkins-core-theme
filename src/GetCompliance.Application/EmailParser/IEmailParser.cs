using System.IO;

namespace GetCompliance.Application.EmailParser
{
    public interface IEmailParser
    {
        Domain.Email Parse(Stream messageStream);
    }
}