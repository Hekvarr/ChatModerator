using Core.Data.Entities;

namespace Core.Data.Repositories;

public class UserRepository(ApplicationDbContext applicationDbContext) : IUserRepository
{
    public async Task<User?> GetById(int id)
    {
        return await applicationDbContext.Users.FindAsync(id);
    }

    public async Task Update(User user)
    {
        applicationDbContext.Users.Update(user);
        await applicationDbContext.SaveChangesAsync();
    }
}