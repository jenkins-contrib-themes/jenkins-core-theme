using System.IO;
using GetCompliance.Application.Document;
using GetCompliance.Application.Queue;
using NUnit.Framework;

namespace GetCompliance.Application.Tests.Document
{
    public class CreateDocumentInteractorTest
    {
        private readonly IRequestHandler<CreateDocumentRequest, CreateDocumentResponse> _sut;
        private readonly IQueue _queue = new FakeQueue();

        public CreateDocumentInteractorTest()
        {
            _sut = new CreateDocumentInteractor(_queue);
        }

        [Test]
        public void ShouldEnqueueMessage()
        {

            var messageFile = new FileInfo(Assets.EmlTestFilePath);

            var request = new CreateDocumentRequest
            {
                Name = messageFile.Name,
                File = messageFile.OpenRead()
            };

            var result = _sut.Handle(request);

            var message = _queue.GetMessage();

            Assert.IsNotNull(message);
            Assert.IsTrue(result.Success);
        }
    }
}