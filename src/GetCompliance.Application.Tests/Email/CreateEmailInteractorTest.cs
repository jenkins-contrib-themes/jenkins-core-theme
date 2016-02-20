using System.IO;
using GetCompliance.Application.Email;
using GetCompliance.Application.Queue;
using NUnit.Framework;

namespace GetCompliance.Application.Tests.Email
{
    public class CreateEmailInteractorTest
    {
        private readonly IRequestHandler<CreateEmailRequest, CreateEmailResponse> _sut;
        private readonly IQueue _queue = new FakeQueue();

        public CreateEmailInteractorTest()
        {
            _sut = new CreateEmailInteractor(_queue);
        }

        [Test]
        public void ShouldEnqueueMessage()
        {

            var messageFile = new FileInfo(Assets.EmlTestFilePath);

            var request = new CreateEmailRequest
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