namespace GetCompliance.Application.Queue
{
    public abstract class Queue : IQueue
    { 
        public void PutMessage(UnparsedEmailMessage unparsedEmailMessage)
        {
            throw new System.NotImplementedException();
        }

        public UnparsedEmailMessage GetMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}