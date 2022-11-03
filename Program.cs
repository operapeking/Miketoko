using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var connection = new SqliteConnection("Data Source=./data.db");
connection.Open();

app.MapGet("/", () =>
{
    var command = connection.CreateCommand();
    command.CommandText = @"
    SELECT text
    FROM main
    ORDER BY random()
    LIMIT 1
    ";

    var reader = command.ExecuteReader();

    while (reader.Read())
    {
        var name = reader.GetString(0);
        return name;
    }
    return "";
});

app.Run();