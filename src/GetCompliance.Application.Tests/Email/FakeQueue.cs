using System.Collections.Generic;
using GetCompliance.Application.Queue;

namespace GetCompliance.Application.Tests.Email
{
    public class FakeQueue : IQueue
    {
        readonly Queue<UnparsedEmailMessage> _queue = new Queue<UnparsedEmailMessage>();
        public void PutMessage(UnparsedEmailMessage unparsedEmailMessage)
        {
            _queue.Enqueue(unparsedEmailMessage);
        }

        public UnparsedEmailMessage GetMessage()
        {
            return _queue.Dequeue();
        }
    }
}