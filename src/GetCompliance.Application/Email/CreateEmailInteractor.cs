using GetCompliance.Application.Queue;

namespace GetCompliance.Application.Email
{
    public class CreateEmailInteractor : IRequestHandler<CreateEmailRequest, CreateEmailResponse>
    {
        private readonly IQueue _unparsedEmailQueue;

        public CreateEmailInteractor(IQueue unparsedEmailQueue)
        {
            _unparsedEmailQueue = unparsedEmailQueue;
        }

        public CreateEmailResponse Handle(CreateEmailRequest request)
        {
            var message = new Message
            {
                File = request.File,
                Filename = request.Name
            };

            _unparsedEmailQueue.PutMessage(message);

            return new CreateEmailResponse
            {
                Success = true
            };
        }
    }
}