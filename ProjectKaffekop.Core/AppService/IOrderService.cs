using ProjectKaffekop.Core.DomainService.Filtering;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core.AppService
{
    public interface IOrderService
    {
        //New Order
        Order New();

        //Create //POST
        Order CreateOrder(Order order);
        //Read //GET
        Order FindOrderById(int id);
        FilteredList<Order> GetAllOrders();
        //Update //PUT
        Order UpdateOrder(Order orderUpdate);

        //Delete //DELETE
        Order DeleteOrder(int id);
    }
}