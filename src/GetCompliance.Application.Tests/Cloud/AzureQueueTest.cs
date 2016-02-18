using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using GetCompliance.Application.Cloud;
using NUnit.Framework;
using GetCompliance.Application.Queue;

namespace GetCompliance.Application.Tests.Cloud
{
    public class AzureQueueTest
    {
        private readonly AzureQueue _sut;

        public AzureQueueTest()
        {
            _sut = new AzureQueue();
        }

        [Test]
        public void PutMessageTest()
        {
            var anyMessage = new Message();
            _sut.PutMessage(anyMessage);
        }
    }
}