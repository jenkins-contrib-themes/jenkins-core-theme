using System.Collections.Generic;

namespace GetCompliance.Application.Email
{
    public class CreateEmailResponse
    {
        public bool Success { get; set; }
        public ICollection<string> Errors { get; set; }
        public int EmailId { get; set; }
    }
}