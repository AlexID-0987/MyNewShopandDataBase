using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models.Interface
{
    public interface IOrderRepository
    {
        IQueryable<Order> orders { get; }
        void SaveOrder(Order order);
    }
}
