using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Orders.Models;

namespace Orders.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();

        Task<Order> CreateAsync(Order order);
        Task<Order> StartAsync(string orderId);
        
    }

    public class OrderService : IOrderService
    {
        private readonly IList<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
            _orders.Add(new Order("1000", "250 Conference brochures", 
                DateTime.Now, 1, "55060965-0be2-4e6a-a3e8-ce0cc73e28d2"));
            _orders.Add(new Order("2000", "250 T-Shirts", 
                DateTime.Now.AddHours(2), 2, "2af4ae58-06bc-4ad2-b7cd-d27942e4f0c9"));
            _orders.Add(new Order("3000", "500 Stickers", 
                DateTime.Now.AddHours(3), 3, "3879010c-75b3-4dfb-8d48-45200acbf507"));
            _orders.Add(new Order("4000", "10 Posters", 
                DateTime.Now.AddHours(4), 4, "fd5af473-845f-43f4-8d9f-fc1eb570733f"));
        }

        public Task<Order> GetOrderByIdAsync(string id)
        {
            return Task.FromResult(_orders.Single(x => x.Id == id));
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }

        public Task<Order> CreateAsync(Order order)
        {
            _orders.Add(order);
            return Task.FromResult(order);
        }

        private Order GetById(string id)
        {
            var order = _orders.SingleOrDefault(o => Equals(o.Id, id));
            if (order == null)
            {
                throw new ArgumentException($"Id {id} is invalid");
            }

            return order;
        }

        public Task<Order> StartAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Start();
            return Task.FromResult(order);
        }
    }
    
}