using GetCompliance.Application.EmailParser;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public class EmailParserFactoryTest
    {
        [Test]
        public void ShouldCreateEmlParserWhenTheFileHasEmlExtension()
        {
            var result = EmailParserFactory.CreateEmailParser("email.eml");
            Assert.IsInstanceOf<EmlParser>(result);
        }

        [Test]
        public void ShouldCreateNullParserWhenTheExtensionIsUnknow()
        {
            var result = EmailParserFactory.CreateEmailParser("email.unknowExtension");
            Assert.IsInstanceOf<NullParser>(result);
        }
    }


}