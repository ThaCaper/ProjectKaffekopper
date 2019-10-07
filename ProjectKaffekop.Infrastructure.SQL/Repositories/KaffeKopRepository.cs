using ProjectKaffekop.Core.DomainService;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Infrastructure.SQL.Repositories
{
    public class KaffeKopRepository : IKaffekopRepository
    {
        public CoffeeCup CreateCoffeeCup(CoffeeCup createCup)
        {
            createCup.Id = FakeDb.Id++;
            FakeDb.AllCups.ToList().Add(createCup);
            return createCup;
        }

        public CoffeeCup GetAllCoffeeCups()
        {
            return FakeDb.AllCups;
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
            var removed = _co(id);
            if (foundCup != null)
            {
                return null;
            }
            FakeDb.AllCups.ToList().Remove(foundCup);
            return foundCup;
        }

        public CoffeeCup GetCoffeeCupById(int id)
        {
            return FakeDb.AllCups.FirstOrDefault(cup => cup.Id == id);
        }
    }
}