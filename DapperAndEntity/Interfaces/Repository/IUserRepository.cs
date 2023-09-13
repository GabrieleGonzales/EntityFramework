using EntityFrameworkCoreExample.Models;

namespace EntityFrameworkCoreExample.Interfaces.Repository
{
    public interface IUserRepository
    {
        public List<User> GetUsers();
        public User GetUser(Guid id);
        public User UpdateUser(User user);
        public User DeleteUser(User user);
        public User AddUser(User user);

        public void InitialDataLoad();
    }
}
