using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectKaffekop.Core;
using ProjectKaffekop.Core.DomainService.Filtering;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Infrastructure.SQL
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ProjectKaffekopContext _context;

        public OrderRepository(ProjectKaffekopContext context)
        {
            _context = context;
        }
        public Order Create(Order order)
        {
            _context.Attach(order).State = EntityState.Added;
            _context.SaveChanges();
            return order;
        }

        public Order ReadById(int id)
        {
            return _context.Orders.Include(o => o.Customer)
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public FilteredList<Order> ReadAll(Filter filter)
        {
            if (filter == null)
            {
                return new FilteredList<Order>() { List = _context.Orders.ToList(), Count = _context.Orders.Count() };
            }

            var items = _context.Orders.Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                .Include(o => o.Customer)
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage)
                .ToList();
            return new FilteredList<Order>() { List = items, Count = Count() };
        }

        public int Count()
        {
            return _context.Orders.Count();
        }

        public Order Update(Order OrderUpdate)
        {
            _context.Attach(OrderUpdate);
            _context.SaveChanges();
            return OrderUpdate;
        }

        public Order Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            var removed = _context.Remove(order).Entity;
            _context.RemoveRange(order.OrderLines);
            _context.SaveChanges();
            return removed;
        }
    }
}