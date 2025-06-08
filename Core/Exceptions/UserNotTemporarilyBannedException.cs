namespace Core.Exceptions;

public class UserNotTemporarilyBannedException : Exception
{
    public UserNotTemporarilyBannedException()
    {
    }

    public UserNotTemporarilyBannedException(string? message) : base(message)
    {
    }

    public UserNotTemporarilyBannedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}