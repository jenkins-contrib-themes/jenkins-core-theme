using GetCompliance.Application.Queue;

namespace GetCompliance.Application.Document
{
    public class CreateDocumentInteractor : IRequestHandler<CreateDocumentRequest, CreateDocumentResponse>
    {
        private readonly IQueue _documentQueue;

        public CreateDocumentInteractor(IQueue documentQueue)
        {
            _documentQueue = documentQueue;
        }

        public CreateDocumentResponse Handle(CreateDocumentRequest request)
        {
            var message = new Message
            {
                File = request.File,
                Filename = request.Name
            };

            _documentQueue.PutMessage(message);

            return new CreateDocumentResponse
            {
                Success = true
            };
        }
    }
}