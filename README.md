An unofficial wrapper for Sv443's jokeapi.

<h1>Why jokes?</h1>

As a self-taught and hobbyist programmer, I wanted to demonstrate to the companies that I take this seriously. So what's better than "jokes"?

<h1>Features</h1>

Ping:

```csharp
var result=await new JokesManager().PingAsync();
```

Getting basic info :

```csharp
var result=await new JokesManager().GetInfoAsync();
```

Get one Joke :
```csharp
var joke = await new JokesManager().GetJoke(new JokeRequestInfo()
{
  BlackList = new List<Flag>() { Flag.Nsfw },
  Categories = new List<JokeCategory>() { JokeCategory.Misc, JokeCategory.Programming },
  Language = Language.en,
  //FilterEnd = 10,
  //FilterStart = 0,
  SearchString = "Bill",
  Type = JokeType.Any
});
```

Get multiple jokes :
```csharp
var jokes = (await new JokesManager().GetJokes(new JokeRequestInfo()
{

  Language = Language.en,
  Type = JokeType.Any
},count:3)).Jokes;
```

Post a Joke :
```csharp
await jokesManager.PostJokes(new JokeInfo()
{
Type = JokeType.Single,
Category = JokeCategory.Misc,
Joke = "I forgot my line",
FlagList = new List<Flag>(),
Language=Language.en,
},dryRun:true);
```


