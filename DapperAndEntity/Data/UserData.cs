using EntityFrameworkCoreExample.DTO;
using EntityFrameworkCoreExample.Interfaces.Data;
using EntityFrameworkCoreExample.Interfaces.Repository;
using EntityFrameworkCoreExample.Models;
using EntityFrameworkCoreExample.Repository;

namespace EntityFrameworkCoreExample.Data
{
    public class UserData : IUserData
    {
        //This class is almost useless. 
        //I only coded it because, if we weren't using Entity in memory,
        //We would have our queries here.
        private readonly IUserRepository _repository;

        public UserData(IUserRepository repository)
        {
            _repository = repository;
        }
        
        public User AddUser(User user)
        {

            return _repository.AddUser(user);
        }


        public User DeleteUser(User user)
        {
            return _repository.DeleteUser(user);
        }

        public List<User> GetAllUsers()
        {
            return _repository.GetUsers();
        }


        public User GetUser(Guid id)
        {
            return _repository.GetUser(id);
        }

        public User GetUser(string email)
        {
            List<User> lst = GetAllUsers();
            return lst.Find(x => x.Email.Equals(email));
        }

        public void InitialDataLoad()
        {
            _repository.InitialDataLoad();
        }

        public User UpdateUser(User user)
        {
           return _repository.UpdateUser(user);
        }
    }
}
