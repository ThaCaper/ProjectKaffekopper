using System.Collections.Generic;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core.AppService
{
    public interface IUserService
    {
        User NewCup(string userName);
        
        User CreateUser(User createUser);

        List<User> GetAllUsers();

        User UpdateUser(User updatedUser);

        User GetUserById(int id);
        
        User DeleteUserById(int id);
    }
}