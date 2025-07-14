using System.Collections.Generic;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        User CreateUser(User newUser);
        bool UpdateUser(int id, User updatedUser);
        bool DeleteUser(int id);
    }
}
