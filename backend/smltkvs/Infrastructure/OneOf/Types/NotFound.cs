namespace Infrastructure.OneOf.Types;

public struct NotFound
{
    public NotFound(string message)
    {
        Message = message;
    }
    
    public string Message { get; init; }
}