using System.IO;
using GetCompliance.Application.Queue;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public class UnparsedEmailQueueTest
    {
        // ref http://stackoverflow.com/questions/248989/unit-testing-that-an-event-is-raised-in-c-sharp
        private readonly UnparsedEmailQueue _sut;
        public UnparsedEmailQueueTest()
        {
            _sut = new UnparsedEmailQueue();
        }
        [Test]
        public void PutMessageTest()
        {
            var emlFile = new FileInfo(Assets.EmlTestFilePath);
            var message = new UnparsedEmailMessage
            {
                File = emlFile.OpenRead(),
                Filename = emlFile.Name
            };

            //_sut.PutMessage(message);
        }
    }

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