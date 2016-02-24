using System.IO;
using GetCompliance.Application.Queue;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public class UnparsedEmailQueueTest
    {
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
}