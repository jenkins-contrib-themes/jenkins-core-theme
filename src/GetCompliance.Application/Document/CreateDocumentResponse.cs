﻿using System.Collections.Generic;

namespace GetCompliance.Application.Document
{
    public class CreateDocumentResponse
    {
        public bool Success { get; set; }
        public ICollection<string> Errors { get; set; }
        public int DocumentId { get; set; }
    }
}