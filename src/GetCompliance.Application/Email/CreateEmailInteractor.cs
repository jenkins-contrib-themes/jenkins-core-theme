using System;
using System.Linq;
using System.Text;
using GetCompliance.Application.Queue;
using GetCompliance.Domain;

namespace GetCompliance.Application.Email
{
    public class CreateEmailInteractor : IRequestHandler<CreateEmailRequest, CreateEmailResponse>
    {
        private readonly IQueueManager _queueManager;

        public CreateEmailInteractor(IQueueManager queueManager)
        {
            _queueManager = queueManager;
        }

        public CreateEmailResponse Handle(CreateEmailRequest request)
        {
            var message = new UnparsedEmail
            {
                File = request.File,
                Filename = request.Name
            };

            ThrowExceptionIfMessageIsInvalid(message);

            var messageBytes = message.SerializeAsBytes();

            _queueManager.PutMessage("unparsed_emails", messageBytes);

            return new CreateEmailResponse
            {
                Success = true
            };
        }

        private static void ThrowExceptionIfMessageIsInvalid(UnparsedEmail message)
        {
            if (!message.GetBrokenRules().Any()) return;

            var brokenRules = new StringBuilder();
            brokenRules.AppendLine("There was a problem saving the unparsed email:");
            message.GetBrokenRules().ToList().ForEach(businessRule => brokenRules.AppendLine(businessRule.Rule));
            throw new ApplicationException(brokenRules.ToString());
        }
    }
}