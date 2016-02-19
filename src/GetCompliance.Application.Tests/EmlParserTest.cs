using System.IO;
using System.Linq;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public class EmlParserTest
    {
        [Test]
        public void ParseTest()
        {
            var sut = new EmlParser();
            Domain.Document result;
            var emlPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Assets", "test.eml");
            using (var messageAsStream = new FileStream(emlPath, FileMode.Open))
            {
                result = sut.Parse(messageAsStream);
            }
            Assert.AreEqual("rodrigo.rodrigues@gastecnologia.com.br", result.To.First());
        }
    }
}