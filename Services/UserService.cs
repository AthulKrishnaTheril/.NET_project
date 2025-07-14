using System.Collections.Generic;
using System.Linq;
using UserManagementAPI.Models;

namespace UserManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> users = new();

        public IEnumerable<User> GetAllUsers()
        {
            return users;
        }

        public User? GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User CreateUser(User newUser)
        {
            newUser.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            users.Add(newUser);
            return newUser;
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            var existingUser = users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
                return false;

            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Email = updatedUser.Email;
            existingUser.Role = updatedUser.Role;

            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return false;

            users.Remove(user);
            return true;
        }
    }
}
