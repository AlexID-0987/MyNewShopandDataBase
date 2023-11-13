using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models
{
    public class ContextData
    {
        public static void Ensure(IApplicationBuilder app)
        {
            ApplicationsDbContext applicationsDb = app.ApplicationServices
                .GetRequiredService<ApplicationsDbContext>();
            applicationsDb.Database.Migrate();
            if (!applicationsDb.Products.Any())
            {
                applicationsDb.Products.AddRange(
                    new Product
                    {
                       NameProduct="Lavender sashe",
                       Price=65758,
                       Category="Party"
                    },
                    new Product
                    {
                        NameProduct = "Lavender flowers",
                        Price = 64658,
                        Category = "Party"
                    },
                    new Product
                    {
                        NameProduct = "Lavender tea",
                        Price = 64558,
                        Category = "Women"
                    },
                    new Product
                    {
                        NameProduct = "Lavender water",
                        Price = 98758,
                        Category = "Women"
                    },
                    new Product
                    {
                        NameProduct = "Lavender air",
                        Price = 78686858,
                        Category = "Women"
                    },
                    new Product
                    {
                        NameProduct = "Lavender tree",
                        Price = 68,
                        Category = "Women"
                    }
                    );
                applicationsDb.SaveChanges();
            }
                
                
        }
    }
}
