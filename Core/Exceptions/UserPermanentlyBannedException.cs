namespace Core.Exceptions;

public class UserPermanentlyBannedException : Exception
{
    public UserPermanentlyBannedException()
    {
    }

    public UserPermanentlyBannedException(string? message) : base(message)
    {
    }

    public UserPermanentlyBannedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}