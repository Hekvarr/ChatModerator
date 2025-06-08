namespace Core.Exceptions;

public class InvalidBanPeriodException : Exception
{
    public InvalidBanPeriodException()
    {
    }

    public InvalidBanPeriodException(string? message) : base(message)
    {
    }

    public InvalidBanPeriodException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}