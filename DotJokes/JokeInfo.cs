using System.Text.Json.Serialization;

namespace DotJokes
{
    public class JokeInfo
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public JokeType Type { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public JokeCategory Category { get; set; }
        public string? Setup { get; set; }
        public string? Delivery { get; set; }
        public string? Joke { get; set; }
        public List<Flag>? FlagList
        {
            get => flagList;
            set
            {
                flagList = value;
                foreach (var flag in (Flag[])Enum.GetValues(typeof(Flag)))
                {
                    flagsString ??= new();
                    if (flagList == null)
                        flagsString.Add(flag, false);
                    else flagsString.Add(flag, flagList.Contains(flag));
                }
            }
        }


        private Dictionary<Flag, bool>? flagsString;
        private List<Flag>? flagList;

        [JsonPropertyName("Flags")]
        public Dictionary<Flag, bool>? FlagsString
        {
            get => flagsString;
            set
            {
                flagsString = value;
                if (value == null)
                    return;
                foreach (var pair in value)
                {
                    if (pair.Value)
                    {
                        flagList ??= new();
                        flagList?.Add(pair.Key);
                    }
                }
            }
        }
        [JsonIgnore]
        public string FormatVersion { get; set; } = "3";

        public int Id { get; set; }
        public bool Safe { get; set; }
        [JsonPropertyName("Lang")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Language Language { get; set; }
    }
    public enum JokeCategory
    {
        Programming, Misc, Dark, Pun, Spooky, Christmas
    }
    public enum JokeType
    {
        Any, Single, TwoPart
    }
    public enum Flag
    {
        Nsfw, Religious, Political, Racist, Sexist, Explicit
    }
    public enum Language
    {
        en, cs, de, es, fr, pt
    }
}
