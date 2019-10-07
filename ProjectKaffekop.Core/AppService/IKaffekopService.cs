
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core.AppService
{
    public interface IKaffekopService
    {
        CoffeeCup NewCup(string name, Color color, double volume, Material material, string description, double price);
        
        CoffeeCup CreateCoffeeCup(CoffeeCup createCup);

        CoffeeCup GetAllCups();

        CoffeeCup UpdateCoffeeCup(CoffeeCup updated);

        CoffeeCup GetCoffeeCupById(int id);
        
        CoffeeCup DeleteCoffeeCup(int id);
    }
}