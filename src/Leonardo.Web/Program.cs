using System.Text.Json.Serialization;
using Leonardo;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 2!");

app.MapGet("/fibonacci", async () =>
{
    var result = await new Fibonacci(new FibonacciDataContext()).RunAsync(new string[] { "42"});
    return Results.Json((List<FibonacciResult>?)result, FibonacciContext.Default.ListFibonacciResult);
});

app.Run();

[JsonSerializable(typeof(List<FibonacciResult>))]
internal partial class FibonacciContext : JsonSerializerContext
{
}