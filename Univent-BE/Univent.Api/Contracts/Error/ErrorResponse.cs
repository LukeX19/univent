namespace Univent.Api.Contracts.Error
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<string> Errors { get; } = new List<string>();
        public DateTime Timestamp { get; set; }
    }
}
