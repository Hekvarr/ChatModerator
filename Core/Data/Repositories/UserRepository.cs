using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<User?> GetById(int id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task Update(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task<List<User>> GetTemporaryBannedUsers()
    {
        return await context.Users
            .Where(u => u.IsTemporarilyBanned)
            .ToListAsync();
    }
}