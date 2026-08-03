using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataParser.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/api/v1/parse-content", (ParseRequest request) =>
{

    if (!Enum.IsDefined(typeof(ContentType), request.Type))
    {
        return Results.BadRequest("Invalid content type. Supported types: CSV, INTERNAL_JSON");
    }

    try
    {
        byte[] data = Convert.FromBase64String(request.Content);
        string decodedText = Encoding.UTF8.GetString(data);

        if (request.Type == ContentType.CSV)
        {
            var lines = decodedText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var result = lines.Select(line => line.Split(',').Select(p => p.Trim()).ToArray()).ToList();

            return Results.Ok(new ParseResponse
            {
                Status = "success",
                Count = result.Count,
                Data = result
            });
        }
    else if (request.Type == ContentType.INTERNAL_JSON)
    {
        var jsonElement = JsonSerializer.Deserialize<JsonElement>(decodedText);
        int itemsCount = 1;

        if (jsonElement.ValueKind == JsonValueKind.Array)
        {
            itemsCount = jsonElement.GetArrayLength();
        }

        return Results.Ok(new ParseResponse
        {
            Status = "success",
            Count = itemsCount,
            Data = jsonElement
        });
    }
    return Results.BadRequest("Unsupported type");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error parsing content: {ex.Message}");
    }
});

app.Run();