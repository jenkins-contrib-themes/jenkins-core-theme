using GetCompliance.Application.Queue;
using NUnit.Framework;

namespace GetCompliance.Application.Tests
{
    public class DocumentQueueTest
    {
        private readonly DocumentQueue _sut;
        public DocumentQueueTest()
        {
            _sut = new DocumentQueue();
        }
        [Test]
        public void PutMessageTest()
        {
            // ref http://stackoverflow.com/questions/248989/unit-testing-that-an-event-is-raised-in-c-sharp
            var message = new Message();
            _sut.PutMessage(message);
            _sut.GetMessage();
        }
    }
}