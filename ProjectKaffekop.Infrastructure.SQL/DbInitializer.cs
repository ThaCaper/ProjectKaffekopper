using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
using ProjectKaffekop.Core.AppService;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Infrastructure.SQL
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IAuthenticationHelper _authHelper;

        public DbInitializer(IAuthenticationHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void Initialize(ProjectKaffekopContext context)
        {
            SeedDB(context);

        }

        private void SeedDB(ProjectKaffekopContext ctx)
        {
            // Create the database, if it does not already exists. If the database
            // already exists, no action is taken (and no effort is made to ensure it
            // is compatible with the model for this context).
            ctx.Database.EnsureCreated();

            // Look for any 
            if (ctx.CoffeeCups.Any())
            {
                return;   // DB has been seeded
            }

            List<CoffeeCup> items = new List<CoffeeCup>
            {
                new CoffeeCup()
                {
                    Name = "FCK Nye kop",
                    Color = Color.Black,
                    Description = "New black tiger icon on the cup from FCK",
                    Material = Material.Steel,
                    Price = 300.00,
                    Volume = 33.33
                    
                },
                new CoffeeCup() 
                { 
                    Name = "Aab Nye Kop",
                    Color = Color.Red,
                    Description = "New Aab cop with their logo and some added details",
                    Material = Material.Steel,
                    Price = 200.00,
                    Volume = 33.33
                }
            };

            // Create two users with hashed and salted passwords
            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            _authHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            _authHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.CoffeeCups.AddRange(items);
            ctx.Users.AddRange(users);
            ctx.SaveChanges();
        }
    }
}