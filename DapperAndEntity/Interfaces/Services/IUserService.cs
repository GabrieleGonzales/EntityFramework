using EntityFrameworkCoreExample.DTO;
using EntityFrameworkCoreExample.Models;

namespace EntityFrameworkCoreExample.Interfaces.Services
{
    public interface IUserService
    {
        public void InitialDataLoad();
        public Response<List<User>> GetAllUsers();
        public Response<User> GetUser(Guid id);
        public Response<User> GetUserByEmail(string email);
        public Response<User> UpdateUser(User user);
        public Response<User> DeleteUser(Guid id);
        public Response<User> AddUser(UserDTO user);

    }
}
