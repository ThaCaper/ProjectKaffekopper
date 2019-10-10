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
            return _context.CoffeeCups.ToList();
        }

        public CoffeeCup UpdateCoffeeCup(CoffeeCup updated)
        {
            var oldCup = _context.CoffeeCups.FirstOrDefault(c => c.Id == updated.Id);

            oldCup.Name = updated.Name;
            oldCup.Color = updated.Color;
            oldCup.Material = updated.Material;
            oldCup.Description = updated.Description;
            oldCup.Volume = updated.Volume;
            oldCup.Price = updated.Price;

            _context.SaveChanges();
            return updated;
        }

        public CoffeeCup DeleteCoffeeCup(int id)
        {
            var removed = _context.Remove(new CoffeeCup() { Id = id }).Entity;
            _context.SaveChanges();
            return removed;
        }

        public CoffeeCup GetCoffeeCupById(int id)
        {
            return _context.CoffeeCups
                .FirstOrDefault(cup => cup.Id == id);
        }
    }
}