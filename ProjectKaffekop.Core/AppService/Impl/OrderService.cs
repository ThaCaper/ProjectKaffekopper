using System;
using System.Collections.Generic;
using System.IO;
using ProjectKaffekop.Core.DomainService;
using ProjectKaffekop.Core.DomainService.Filtering;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekop.Core
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ICustomerRepository _customerRepo;

        public OrderService(IOrderRepository orderRepo, ICustomerRepository customerRepo)
        {
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
        }
        public Order New()
        {
            return new Order();
        }

        public Order CreateOrder(Order order)
        {
            if (order.Customer == null || order.Customer.Id <= 0)
                throw new InvalidDataException("To create Order you need a Customer");
            if (_customerRepo.ReadyById(order.Customer.Id) == null)
                throw new InvalidDataException("Customer Not found");
            if (order.OrderDate == null)
                throw new InvalidDataException("Order needs a Order Date");
            if (order.DeliveryDate <= DateTime.MinValue)
                throw new InvalidDataException("To create Order you need a deliveryDate");

            return _orderRepo.Create(order);
        }

        public Order FindOrderById(int id)
        {
            return _orderRepo.ReadById(id);
        }

        public FilteredList<Order> GetAllOrders()
        {
            return _orderRepo.ReadAll();
        }

        public Order UpdateOrder(Order orderUpdate)
        {
            return _orderRepo.Update(orderUpdate);
        }

        public Order DeleteOrder(int id)
        {
            return _orderRepo.Delete(id);
        }
    }
}