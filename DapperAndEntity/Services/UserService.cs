using EntityFrameworkCoreExample.DTO;
using EntityFrameworkCoreExample.Interfaces.Data;
using EntityFrameworkCoreExample.Interfaces.Services;
using EntityFrameworkCoreExample.Models;
using System.Net;

namespace EntityFrameworkCoreExample.Services
{
    public class UserService : IUserService
    {
        private readonly IUserData _userData;
        
        public UserService(IUserData userData)
        {
            _userData = userData;
        }

        public Response<User> AddUser(UserDTO user)
        {
            Response<User> response = new Response<User>();
            try
            {
                User usr = _userData.GetUser(user.Email);
                if (usr != null)
                {
                    response.responseContent = usr;
                    response.statusCode = HttpStatusCode.BadRequest;
                    response.message = "User already exists!";
                    return response;
                }
                
                User add = new User();
                add.Id = Guid.NewGuid();
                add.Name = user.Name;
                add.Email = user.Email;

                User added = _userData.AddUser(add);
                response.responseContent = added;
                response.statusCode = HttpStatusCode.OK;
                response.message = "User created successfully";
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.message = ex.Message;
            }

            return response;
        }

        public Response<User> DeleteUser(Guid id)
        {
            Response<User> response = new Response<User>();
            try
            {
                User user = _userData.GetUser(id);
                response.responseContent = user;
                if (user == null)
                {
                    response.statusCode = HttpStatusCode.NotFound;
                    response.message = "User not found";
                    return response;
                }
                _userData.DeleteUser(user);
                response.statusCode = HttpStatusCode.OK;
                response.message = "User deleted successfully";
            } catch (Exception ex)
            {
                response.statusCode =HttpStatusCode.BadRequest;
                response.message = ex.Message;
            }

            return response;
        }

        public Response<List<User>> GetAllUsers()
        {
            Response<List<User>> response = new Response<List<User>>();
            try
            {
                List<User> users = _userData.GetAllUsers();
                
                response.statusCode = HttpStatusCode.OK;
                response.message = "Users retrieved successfully";
                if (users.Count == 0) response.message += " - But there is no content";
                response.responseContent = users;

            } catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.message = ex.Message;
            }

            return response;
        }

        public Response<User> GetUser(Guid id)
        {
            Response<User> response = new Response<User>();
            try
            {
                User user = _userData.GetUser(id);

                response.statusCode = HttpStatusCode.OK;
                if(user != null ) response.message = "User retrieved successfully";
                else              response.message = "Operation successfull - But the user was not found";
                response.responseContent = user;

            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.message = ex.Message;
            }

            return response;
        }

        public Response<User> GetUserByEmail(string email)
        {
            Response<User> response = new Response<User>();
            try
            {
                User user = _userData.GetUser(email);

                response.statusCode = HttpStatusCode.OK;
                if (user != null) response.message = "User retrieved successfully";
                else response.message = "Operation successfull - But the user was not found";
                response.responseContent = user;

            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.message = ex.Message;
            }

            return response;
        }

        public void InitialDataLoad()
        {
            _userData.InitialDataLoad();
        }

        public Response<User> UpdateUser(User usr)
        {
            Response<User> response = new Response<User>();
            try
            {
                User user = _userData.GetUser(usr.Id);
                if (user == null)
                {
                    response.statusCode = HttpStatusCode.NotFound;
                    response.message = "User not found";
                    return response;
                }


                User updatedUser = _userData.UpdateUser(usr);
                response.responseContent = updatedUser;
                response.statusCode = HttpStatusCode.OK;
                response.message = "User updated successfully";
            }
            catch (Exception ex)
            {
                response.statusCode = HttpStatusCode.BadRequest;
                response.message = ex.Message;
            }

            return response;
        }
    }
}
