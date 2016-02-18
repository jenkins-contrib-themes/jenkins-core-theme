namespace GetCompliance.Application.Queue
{
    public abstract class Queue : IQueue
    { 
        public void PutMessage(Message message)
        {
            throw new System.NotImplementedException();
        }

        public Message GetMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}