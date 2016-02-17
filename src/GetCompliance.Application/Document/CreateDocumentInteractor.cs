namespace GetCompliance.Application.Document
{
    public class CreateDocumentInteractor : IRequestHandler<CreateDocumentRequest, CreateDocumentResponse>
    {
        public CreateDocumentResponse Handle(CreateDocumentRequest request)
        {
            return new CreateDocumentResponse();
        }
    }
}