using Backend.Models.User;

namespace Backend.Repositories
{
    public class UserRepository
    {
        private static readonly List<User> users = new();
        public List<User> GetAll() => users;
        public void Add(User user) => users.Add(user);
    }
}
