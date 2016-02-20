using System.IO;
using System.Linq;
using GetCompliance.Application.DocumentParser;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public class EmlParserTest
    {
        [Test]
        public void ParseTest()
        {
            var sut = new EmlParser();
            var stream = new FileInfo(Assets.EmlTestFilePath);

            var result = sut.Parse(stream.OpenRead());

            Assert.AreEqual("rodrigo.rodrigues@gastecnologia.com.br", result.To.First());
        }
    }
}