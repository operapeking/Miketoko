using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var quotes = JsonSerializer.Deserialize<string[]>(File.ReadAllText("quotes.json"));

if (quotes is null)
{
    Console.WriteLine("Can not open file quotes.json.");
    return;
}

var rand = new Random();

app.MapGet("/", () =>
{
    var id = rand.Next(0, quotes.Length);
    return quotes[id];
});

app.Run();