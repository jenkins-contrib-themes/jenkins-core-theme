using System.Collections.Generic;
using GetCompliance.Application.Queue;

namespace GetCompliance.Application.Tests.Email
{
    public class FakeQueueManager : IQueueManager
    {
        public string LastName { get; set; }
        public byte[] LastMessage { get; set; }
        public void PutMessage(string queueName, byte[] unparsedEmailMessage)
        {
            LastName = queueName;
            LastMessage = unparsedEmailMessage;
        }
    }
}