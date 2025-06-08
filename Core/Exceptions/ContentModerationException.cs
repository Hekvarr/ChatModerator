namespace Core.Exceptions;

public class ContentModerationException : Exception
{
    public ContentModerationException()
    {
    }

    public ContentModerationException(string? message) : base(message)
    {
    }

    public ContentModerationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}