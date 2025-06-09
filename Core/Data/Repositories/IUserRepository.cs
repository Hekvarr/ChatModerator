using Core.Data.Entities;

namespace Core.Data.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(int id);
    Task Update(User user);
    Task<List<User>> GetTemporaryBannedUsers();
}