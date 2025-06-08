namespace Core.Services;

public interface IContentModerationService
{
    Task<bool> IsOffensive(string text);
}