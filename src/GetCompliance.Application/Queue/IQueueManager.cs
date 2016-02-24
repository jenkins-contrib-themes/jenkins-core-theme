namespace GetCompliance.Application.Queue
{
    public interface IQueueManager
    {
        void PutMessage(string queueName, byte[] unparsedEmailMessage);

        
    }
}