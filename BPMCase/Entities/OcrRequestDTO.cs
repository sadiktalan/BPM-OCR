using System;
namespace BPMCase.Entities
{
    public class OcrRequestDTO
    {
        public string? BillNumber { get; set; }
        public DocumentType DocumentType { get; set; }
        public string? DocumentData { get; set; }
    }
}

