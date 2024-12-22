namespace Web_Programlama_Proje.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public string? ErrorMessage { get; set; }
        public int? StatusCode { get; set; }
        public DateTime? Timestamp { get; set; }
        public string? Details { get; set; }
        public string? Page { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
