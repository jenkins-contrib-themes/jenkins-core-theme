using System.Collections.Generic;
using GetCompliance.Application.Queue;

namespace GetCompliance.Application.Tests.Document
{
    public class FakeQueue : IQueue
    {
        readonly Queue<Message> _queue = new Queue<Message>();
        public void PutMessage(Message message)
        {
            _queue.Enqueue(message);
        }

        public Message GetMessage()
        {
            return _queue.Dequeue();
        }
    }
}