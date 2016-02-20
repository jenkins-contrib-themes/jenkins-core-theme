namespace GetCompliance.Application.Queue
{
    public interface IQueue
    {
        void PutMessage(UnparsedEmailMessage unparsedEmailMessage);
        UnparsedEmailMessage GetMessage();
    }
}