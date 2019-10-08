using System.Collections.Generic;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core
{
    public interface IOrderService
    {
        //New Order
        Order New();

        //Create //POST
        Order CreateOrder(Order order);
        //Read //GET
        Order FindOrderById(int id);
        List<Order> GetAllOrders();
        //Update //PUT
        Order UpdateOrder(Order orderUpdate);

        //Delete //DELETE
        Order DeleteOrder(int id);
    }
}