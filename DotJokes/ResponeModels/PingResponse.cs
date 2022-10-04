namespace DotJokes.ResponeModels
{
    public class PingResponse:BaseResponse
    {
        public const string DefaultPingString = "Pong!";
        public string? Ping { get; set; }
        public bool PingSucces => Ping!=null && Ping == DefaultPingString;
    }
}
