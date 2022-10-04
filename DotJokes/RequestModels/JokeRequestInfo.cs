using System.Text;

namespace DotJokes.RequestModels
{
    public class JokeRequestInfo
    {
        public JokeType Type { get; set; }

        public List<Flag>? BlackList { get; set; }
        public string? SearchString { get; set; }

        public int? FilterStart { get; set; }
        public int? FilterEnd { get; set; }
        public Language Language { get; set; }

        /// <summary>
        /// List of <see cref="Categories"/> leave it null for any
        /// </summary>
        public List<JokeCategory>? Categories { get; set; }

        public string Parse()
        {
            StringBuilder sb = new StringBuilder();
            if (Categories != null && Categories.Count > 0)
                sb.Append($"{string.Join(',', Categories)}");
            else sb.Append("Any");
            sb.Append('?');
            if (Type != JokeType.Any)
                sb.Append($"type={Type}&");
            if(!string.IsNullOrEmpty(SearchString))
                sb.Append($"contains={SearchString}&");
            if (FilterStart != null && FilterEnd != null)
            {
                if (FilterStart < 0)
                    throw new ArgumentOutOfRangeException(nameof(FilterStart));
                if (FilterEnd < 0)
                    throw new ArgumentOutOfRangeException(nameof(FilterEnd));
                else sb.Append($"idRange={FilterStart}-{FilterEnd}&");
            }
                if (BlackList != null && BlackList.Count > 0)
                    sb.Append($"blacklistFlags={string.Join(',', BlackList)}&");
            if(Language!=Language.en)
                sb.Append($"lang={Language}&");
            return sb.ToString();

        }
    }
}
