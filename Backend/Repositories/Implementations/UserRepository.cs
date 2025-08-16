using Microsoft.EntityFrameworkCore;
using Backend.models;

namespace Backend.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usery> GetByIdAsync(int Id) =>
        await _context.Users.FindAsync(id);

        public async Task<Usery> GetByEmailAsync(string email) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddSync(User user)
        {
            _context.User.Add(user);
            await _context.saveChangesAsync();
        }
    }
}