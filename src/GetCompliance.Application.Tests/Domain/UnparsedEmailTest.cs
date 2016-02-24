using System.IO;
using System.Linq;
using GetCompliance.Application.Queue;
using GetCompliance.Domain;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public class UnparsedEmailTest
    {
        [Test]
        public void ConvertToByteTest()
        {
            var emlFile = new FileInfo(Assets.EmlTestFilePath);
            var message = new UnparsedEmail
            {
                File = emlFile.OpenRead(),
                Filename = emlFile.Name
            };

            var result = message.SerializeAsBytes();
            Assert.Greater(result.Length, 0);

            var deserialized = new UnparsedEmail(result);

            Assert.AreEqual(deserialized.Filename, message.Filename);

            //rewind filestream
            message.File.Position = 0;
            var deserializedFileAsBytes = deserialized.File.ReadAsBytes();
            var messageFileAsBytes = message.File.ReadAsBytes();
            Assert.IsTrue(deserializedFileAsBytes.SequenceEqual(messageFileAsBytes));
        }

    }
}