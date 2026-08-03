namespace DataParser.Models;

public enum ContentType
{
    CSV,
    INTERNAL_JSON
}

public class ParseRequest
{
    public ContentType Type { get; set; }
    public string Content { get; set; } = string.Empty;
}


public class ParseResponse
{
    public string Status { get; set; } = string.Empty;
    public int Count { get; set; }
    public object? Data { get; set; }
}
