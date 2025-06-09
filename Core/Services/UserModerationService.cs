using Core.Data.Entities;

namespace Core.Services;

public class UserModerationService(IContentModerationService contentModerationService, IUserService userService)
    : IUserModerationService
{
    public async Task ProcessMessage(Message message)
    {
        if (string.IsNullOrEmpty(message.Content)) return;
        var messageIsOffensive = await contentModerationService.IsOffensive(message.Content);
        if (messageIsOffensive) await userService.BanTemporarily(message.UserId, DateTime.UtcNow.AddHours(1));
    }
}