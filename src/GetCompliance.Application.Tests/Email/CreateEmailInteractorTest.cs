using System.IO;
using GetCompliance.Application.Email;
using GetCompliance.Application.Queue;
using NUnit.Framework;

namespace GetCompliance.Application.Tests.Email
{
    public class CreateEmailInteractorTest
    {
        private readonly IRequestHandler<CreateEmailRequest, CreateEmailResponse> _sut;
        private readonly FakeQueueManager _queueManager = new FakeQueueManager();

        public CreateEmailInteractorTest()
        {
            _sut = new CreateEmailInteractor(_queueManager);
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
            Assert.AreEqual("unparsed_emails", _queueManager.LastName);
            Assert.IsNotNull(_queueManager.LastMessage);
            Assert.IsTrue(result.Success);
        }
    }
}