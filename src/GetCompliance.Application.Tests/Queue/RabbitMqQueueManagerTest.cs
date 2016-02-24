using GetCompliance.Application.Queue;
using NUnit.Framework;

namespace GetCompliance.Application.Tests.Queue
{
    public class RabbitMqQueueManagerTest
    {
        private readonly RabbitMqQueueManager _sut;
        public RabbitMqQueueManagerTest()
        {
            _sut = new RabbitMqQueueManager();
        }

        [Test]
        public void ProduceAndConsumeTest()
        {
            var anyByteArray = new byte[] {0, 1, 255};
            _sut.PutMessage("test", anyByteArray);
            /*var consumer = new FakeQueueConsumer();
            _sut.RegisterConsumer("test", consumer);
            Thread.Sleep(10000);
            Assert.IsTrue(consumer.LastMessage.SequenceEqual(anyByteArray), "The retrieve message should equal the initial message");*/
        }

        
        public class FakeQueueConsumer : IQueueConsumer
        {
            public byte[] LastMessage { get; set; }
            public void Consume(byte[] message)
            {
                LastMessage = message;
            }
        }
    }
}