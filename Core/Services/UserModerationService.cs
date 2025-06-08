using Core.Data.Entities;

namespace Core.Services;

public class UserModerationService(IContentModerationService contentModerationService, IUserService userService)
    : IUserModerationService
{
    public async Task ProcessMessage(Message message)
    {
        var messageIsOffensive = await contentModerationService.IsOffensive(message.Content);
        if (messageIsOffensive) await userService.BanTemporarily(message.UserId, DateTime.Now.AddHours(1));
    }
}