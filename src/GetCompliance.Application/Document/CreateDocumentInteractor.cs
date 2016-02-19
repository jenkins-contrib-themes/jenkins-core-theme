using GetCompliance.Application.Queue;
using GetCompliance.Infra.Data.Interfaces;

namespace GetCompliance.Application.Document
{
    public class CreateDocumentInteractor : IRequestHandler<CreateDocumentRequest, CreateDocumentResponse>
    {
        private readonly IQueue _documentQueue;
        private readonly IRepository<Domain.Document> _documentRepository;

        public CreateDocumentInteractor(IQueue documentQueue, IRepository<Domain.Document> documentRepository)
        {
            _documentQueue = documentQueue;
            _documentRepository = documentRepository;
        }

        public CreateDocumentResponse Handle(CreateDocumentRequest request)
        {
            return new CreateDocumentResponse();
        }
    }
}