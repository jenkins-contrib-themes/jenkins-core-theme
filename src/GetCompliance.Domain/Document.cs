using System;
using System.Collections.Generic;
using GetCompliance.Domain.Infrastructure;

namespace GetCompliance.Domain
{
    public class Document : EntityBase
    {
        protected override void Validate()
        {
        }
        public string Subject { get; set; }
        public string From { get; set; }
        public IEnumerable<string> To { get; set; }
        public DateTime SentOn { get; set; }
        public IEnumerable<string> BCC { get; set; }
        public string CC { get; set; }
        public string Body { get; set; }
        public string HtmlBody { get; set; }
        public string TextBody { get; set; }
    }
}
