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
        
        public void SaveProduct(Product prod)
        {
            if(prod.ProductId==0)
            {
                context.Products.Add(prod);
            }
            else
            {
                Product dbEntry = context.Products
                    .FirstOrDefault(w => w.ProductId == prod.ProductId);
                if (dbEntry!=null)
                {
                    dbEntry.NameProduct = prod.NameProduct;
                    dbEntry.Price = prod.Price;
                    dbEntry.Category = prod.Category;
                }
                
            }
            context.SaveChanges();
        }
        public Product Delete(int productId)
        {
            Product dbEntry = context.Products.FirstOrDefault(p => p.ProductId == productId);
            if(dbEntry!=null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
