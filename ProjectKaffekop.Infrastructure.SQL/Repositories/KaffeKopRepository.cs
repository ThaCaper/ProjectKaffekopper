using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectKaffekop.Core.DomainService;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Infrastructure.SQL.Repositories
{
    public class KaffeKopRepository : IKaffekopRepository
    {

        private readonly ProjectKaffekopContext _context;

        public KaffeKopRepository(ProjectKaffekopContext context)
        {
            _context = context;
        }
        public CoffeeCup CreateCoffeeCup(CoffeeCup createCup)
        {
            _context.Attach(createCup).State = EntityState.Added;
            _context.SaveChanges();
            return createCup;
        }

        public List<CoffeeCup> GetAllCoffeeCups()
        {
            return _context.Cups.ToList();
        }

        public CoffeeCup UpdateCoffeeCup(CoffeeCup updated)
        {
            var cupFromDatabase = GetCoffeeCupById(updated.Id);
            if (cupFromDatabase == null)
            {
                return null;
            }

            cupFromDatabase.Name = updated.Name;
            cupFromDatabase.Price = updated.Price;
            cupFromDatabase.Color = updated.Color;
            cupFromDatabase.Volume = updated.Volume;
            cupFromDatabase.Description = updated.Description;
            cupFromDatabase.Material = updated.Material;

            return cupFromDatabase;
        }

        public CoffeeCup DeleteCoffeeCup(int id)
        {
            var removed = _context.Remove(new CoffeeCup() { Id = id }).Entity;
            _context.SaveChanges();
            return removed;
        }

        public CoffeeCup GetCoffeeCupById(int id)
        {
            return _context.Cups
                .Include(cup => cup.Name)
                .ThenInclude(cup => cup)
                .FirstOrDefault(cup => cup.Id == id);
        }
    }
}