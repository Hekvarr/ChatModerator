using Core.Data.Repositories;
using Core.Exceptions;

namespace Core.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task BanForever(int userId)
    {
        var user = await repository.GetById(userId);
        if (user == null) throw new UserNotFoundException("User with the specified ID was not found.");
        if (user.IsBannedForever)
            throw new UserAlreadyBannedException("User is already banned and cannot be banned again.");
        user.IsBannedForever = true;
        user.IsTemporarilyBanned = false;
        user.BannedUntil = null;
        await repository.Update(user);
    }

    public async Task BanTemporarily(int userId, DateTime bannedUntil)
    {
        if (bannedUntil <= DateTime.UtcNow)
            throw new InvalidBanPeriodException("The ban end date must be in the future.");
        var user = await repository.GetById(userId);
        if (user == null) throw new UserNotFoundException("User with the specified ID was not found.");
        if (user.IsBannedForever)
            throw new UserAlreadyBannedException("User is already banned and cannot be banned again.");
        if (user.IsTemporarilyBanned && bannedUntil < user.BannedUntil)
            throw new InvalidBanPeriodException("The new ban period is shorter than the current one.");
        user.IsTemporarilyBanned = true;
        user.BannedUntil = bannedUntil;
        await repository.Update(user);
    }

    public async Task LiftTemporaryBans()
    {
        var temporaryBannedUsers = await repository.GetTemporaryBannedUsers();
        foreach (var user in temporaryBannedUsers.Where(user => user.BannedUntil < DateTime.UtcNow))
        {
            user.IsTemporarilyBanned = false;
            user.BannedUntil = null;
            await repository.Update(user);
        }
    }
}