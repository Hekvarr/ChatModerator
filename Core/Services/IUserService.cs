namespace Core.Services;

public interface IUserService
{
    Task BanForever(int userId);
    Task BanTemporarily(int userId, DateTime bannedUntil);
    Task LiftTemporaryBans();
}