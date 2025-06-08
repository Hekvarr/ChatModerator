using Core.Data.Entities;

namespace Core.Services;

public interface IUserModerationService
{
    Task ProcessMessage(Message message);
}