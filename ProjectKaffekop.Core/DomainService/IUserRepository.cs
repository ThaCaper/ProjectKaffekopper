using System.Collections.Generic;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core.DomainService
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetUserById(int id);
        User CreateUser(User newUser);
        User UpdateUser(User updatedUser);
        User DeleteUser(int id);
    }
}