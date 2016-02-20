using GetCompliance.Application.DocumentParser;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public class DocumentParserFactoryTest
    {
        [Test]
        public void ShouldCreateEmlParserWhenTheFileHasEmlExtension()
        {
            var result = DocumentParserFactory.CreateDocumentParser("email.eml");
            Assert.IsInstanceOf<EmlParser>(result);
        }

        [Test]
        public void ShouldCreateNullParserWhenTheExtensionIsUnknow()
        {
            var result = DocumentParserFactory.CreateDocumentParser("email.unknowExtension");
            Assert.IsInstanceOf<NullParser>(result);
        }
    }


}