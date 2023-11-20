using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models
{
    public class ApplicationsDbContext:DbContext
    {
        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> dbContext) : base(dbContext) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
