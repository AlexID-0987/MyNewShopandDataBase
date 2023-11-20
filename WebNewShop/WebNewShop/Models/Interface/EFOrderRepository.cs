using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models.Interface
{
    public class EFOrderRepository:IOrderRepository
    {
        private ApplicationsDbContext context;
        public EFOrderRepository(ApplicationsDbContext dbContext)
        {
            context = dbContext;
        }
        public IQueryable<Order> orders => context.Orders
            .Include(o => o.lines)
            .ThenInclude(l => l.Product);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.lines.Select(i => i.Product));
            if(order.OrderId==0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
        
    }
}
