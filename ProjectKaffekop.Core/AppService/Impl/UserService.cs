using System.Collections.Generic;
using System.IO;
using ProjectKaffekop.Core.DomainService;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core.AppService.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRep;

        public UserService(IUserRepository userRep)
        {
            _userRep = userRep;
        }
        public User NewCup(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new InvalidDataException("please insert name!");
            }

            var user = new User()
            {
                Username = userName

            };
            return user;
        }

        public User CreateUser(User createUser)
        {
            return _userRep.CreateUser(createUser);
        }

        public List<User> GetAllUsers()
        {
            return _userRep.GetAll();
        }

        public User UpdateUser(User updatedUser)
        {
            return _userRep.UpdateUser(updatedUser);
        }

        public User GetUserById(int id)
        {
            return _userRep.GetUserById(id);
        }

        public User DeleteUserById(int id)
        {
            return _userRep.DeleteUser(id);
        }
    }
}