namespace GetCompliance.Application.Queue
{
    public interface IQueue
    {
        void PutMessage(Message message);
        Message GetMessage();
    }
}