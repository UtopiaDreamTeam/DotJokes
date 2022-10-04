namespace DotJokes.ResponeModels
{
    public class PostJokeResponse:BaseResponse
    {
        private const string JokeSubmited = "Joke submission was successfully saved. It will soon be checked out by the author.";
        private const string JokeSubmitedInDryRun = "Dry Run complete! No errors were found.";
        public JokeInfo? Submission { get; set; }
        public bool? Success => Message == JokeSubmited||Message==JokeSubmitedInDryRun;
    }
}
