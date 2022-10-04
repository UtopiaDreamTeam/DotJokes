using System.Text.Json.Serialization;

namespace DotJokes.ResponeModels
{
    public abstract class BaseResponse
    {
        public string? TimeStamp { get; }
        [JsonPropertyName("Error")]
        public bool? Failed { get; }
        public bool? InternalError { get; set; }
        public int? Code { get; set; }
        public string? Message { get; set; }
        public string? AdditionalInfo { get; set; }
        public List<string>? CausedBy { get; set; }
    }
}
