namespace GetCompliance.Application.Queue
{
    public interface IQueueConsumer
    {
        void Consume(byte[] message);
    }
}