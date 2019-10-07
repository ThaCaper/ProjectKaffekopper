
namespace ProjectKaffekop.Core.AppService
{
    public interface IKaffekopService
    {
        CoffeeCup NewCup(string name, Color color, double Volume, Material Material, string Description, double price);
        
        CoffeeCup CreateCoffeeCup(CoffeeCup createCup);

        CoffeeCup GetAllCups();

        CoffeeCup UpdateCoffeeCup(CoffeeCup updated);

        CoffeeCup GetCoffeeCupById(int id);
        
        CoffeeCup DeleteCoffeeCup(int id);
    }
}