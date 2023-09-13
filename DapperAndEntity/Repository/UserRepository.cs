using EntityFrameworkCoreExample.Models;
using EntityFrameworkCoreExample.Interfaces.Repository;

namespace EntityFrameworkCoreExample.Repository
{
    public class UserRepository : IUserRepository
    {

        public void InitialDataLoad()
        {
            using (var context = new ApiContext())
            {
                var users = new List<User>
                {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Gabriele",
                    Email = "teste_gabriele@mail.com",
                    IsActive = true
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Gilberto",
                    Email = "teste_gilberto@mail.com",
                    IsActive = true
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Rafael",
                    Email = "teste_rafael@mail.com",
                    IsActive = false
                },
                };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }

        public User AddUser(User user)
        {

            using (var context = new ApiContext())
            {
                context.Users.
                    Add(user);
                context.SaveChanges();

                var usr = context.Users
                   .Find(user.Id);
                return usr;
            }
        }

        public User DeleteUser(User user)
        {
            using (var context = new ApiContext())
            {
                 context.Users
                    .Remove(user);
                context.SaveChanges();
                return user;
            }
        }

        public User GetUser(Guid id)
        {
            using (var context = new ApiContext())
            {
                var usr = context.Users.
                    Find(id);
                return usr;
            }
        }

        public List<User> GetUsers()
        {
            using (var context = new ApiContext())
            {
                var list = context.Users
                    .ToList();
                return list;
            }
        }

        public User UpdateUser(User user)
        {
            using (var context = new ApiContext())
            {
                context.Users
                    .Update(user);
                context.SaveChanges();
                var usr = context.Users.Find(user);
                return usr;
            }
        }
    }
}
