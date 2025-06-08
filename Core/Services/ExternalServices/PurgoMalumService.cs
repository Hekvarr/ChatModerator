using Core.Exceptions;

namespace Core.Services.ExternalServices;

public class PurgoMalumService(HttpClient httpClient) : IContentModerationService
{
    public async Task<bool> IsOffensive(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return false;
        var requestUri = $"https://www.purgomalum.com/service/containsprofanity?text={Uri.EscapeDataString(text)}";
        var result = await httpClient.GetStringAsync(requestUri);
        if (!bool.TryParse(result, out var isOffensive))
            throw new ContentModerationException("The moderation service returned an invalid response.");
        return isOffensive;
    }
}