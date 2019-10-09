using ProjectKaffekop.Core.DomainService.Filtering;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core.DomainService
{
    public interface IOrderRepository
    {
        //Create Data
        //No Id when enter, but Id when exits
        Order Create(Order order);
        //Read Data
        Order ReadById(int id);
        FilteredList<Order> ReadAll(Filter filter = null);
        int Count();
        //Update Data
        Order Update(Order OrderUpdate);
        //Delete Data
        Order Delete(int id);
    }
}