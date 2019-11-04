using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectKaffekop.Core.DomainService;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Infrastructure.SQL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectKaffekopContext _ctx;

        public UserRepository(ProjectKaffekopContext ctx)
        {
            _ctx = ctx;
        }

        public List<User> GetAll()
        {
            return _ctx.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _ctx.Users
                .FirstOrDefault(user => user.Id == id);
        }

        public User CreateUser(User newUser)
        {
            _ctx.Attach(newUser).State = EntityState.Added;
            _ctx.SaveChanges();
            return newUser;
        }

        public User UpdateUser(User updatedUser)
        {
            _ctx.Entry(updatedUser).State = EntityState.Modified;
            _ctx.SaveChanges();
            return updatedUser;
        }

        public User DeleteUser(int id)
        {
            var removed = _ctx.Remove(new User() { Id = id }).Entity;
            _ctx.SaveChanges();
            return removed;
        }
    }
}