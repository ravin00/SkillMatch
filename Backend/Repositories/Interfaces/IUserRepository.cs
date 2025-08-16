using Backend.models;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetEmailAsync(string email);
        Task AddAsync(User user);
    }
}