using System.IO;
using GetCompliance.Application.Queue;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public class UnparsedEmailMessageTest
    {
        [Test]
        public void ConvertToByteTest()
        {
            var emlFile = new FileInfo(Assets.EmlTestFilePath);
            var message = new UnparsedEmailMessage
            {
                File = emlFile.OpenRead(),
                Filename = emlFile.Name
            };

            var result = message.ToBytes();

            Assert.Greater(0, result.Length);
        }
    }
}