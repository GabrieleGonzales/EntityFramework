using EntityFrameworkCoreExample.DTO;
using EntityFrameworkCoreExample.Models;

namespace EntityFrameworkCoreExample.Interfaces.Data
{
    public interface IUserData
    {
        public List<User> GetAllUsers();
        public User GetUser(Guid id);
        public User GetUser(string email);
        public User UpdateUser(User user);
        public User DeleteUser(User user);
        public User AddUser(User user);
        public void InitialDataLoad();
    }
}
