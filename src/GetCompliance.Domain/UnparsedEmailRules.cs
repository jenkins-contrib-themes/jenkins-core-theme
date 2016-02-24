using GetCompliance.Domain.Infrastructure;

namespace GetCompliance.Domain
{
    public class UnparsedEmailRules
    {
        public static readonly BusinessRule FilenameMaxLength = new BusinessRule("Filename", "Filename should contain at most 255 characters");
    }
}