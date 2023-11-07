using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models.Interface
{
    public class EFProductRepository:IProductRepository
    {
        private ApplicationsDbContext context;
        public EFProductRepository(ApplicationsDbContext applicationsDbContext)
        {
            context = applicationsDbContext;
        }
        public IQueryable<Product> Products => context.Products;
        
    }
}
