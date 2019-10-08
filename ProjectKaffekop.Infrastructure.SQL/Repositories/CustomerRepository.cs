using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectKaffekop.Core.DomainService;
using ProjectKaffekop.Core.DomainService.Filtering;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Infrastructure.SQL.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ProjectKaffekopContext _context;

        public CustomerRepository(ProjectKaffekopContext context)
        {
            _context = context;
        }
        public Customer Create(Customer customer)
        {
            if (customer.Type != null)
            {
                _context.Attach(customer.Type).State = EntityState.Unchanged;
            }
            var customerSaved = _context.Customers.Add(customer).Entity;
            _context.SaveChanges();
            return customerSaved;
        }

        public Customer ReadyById(int id)
        {
            return _context.Customers
                .Include(c => c.Type)
                .FirstOrDefault(c => c.Id == id);
        }

        public FilteredList<Customer> ReadAll(Filter filter)
        {
            //Create a Filtered List
            var filteredList = new FilteredList<Customer>();

            //If there is a Filter then filter the list and set Count
            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                filteredList.List = _context.Customers
                    .Include(c => c.Type)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
                filteredList.Count = _context.Customers.Count();
                return filteredList;
            }

            //Else just return the full list and get the count from the list (to save a SQL call)
            filteredList.List = _context.Customers
                .Include(c => c.Type);
            filteredList.Count = filteredList.List.Count();
            return filteredList;
        }

        public int Count()
        {
            return _context.Customers.Count();
        }

        public Customer Update(Customer customerUpdate)
        {
            _context.Attach(customerUpdate).State = EntityState.Modified;
            _context.Entry(customerUpdate).Collection(c => c.Orders).IsModified = true;
            _context.Entry(customerUpdate).Reference(c => c.Type).IsModified = true;
            var orders = _context.Orders.Where(o => o.Customer.Id == customerUpdate.Id
                                                && !customerUpdate.Orders.Exists(co => co.Id == o.Id));
            foreach (var order in orders)
            {
                order.Customer = null;
                _context.Entry(order).Reference(o => o.Customer)
                    .IsModified = true;
            }
            _context.SaveChanges();
            return customerUpdate;
        }

        public Customer Delete(int id)
        {
            var custRemoved = _context.Remove(new Customer { Id = id }).Entity;
            _context.SaveChanges();
            return custRemoved;
        }

        public Customer ReadyByIdIncludeOrders(int id)
        {
            return _context.Customers
                .Include(c => c.Type)
                .Include(c => c.Orders)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}