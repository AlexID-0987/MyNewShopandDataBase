﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models.Interface
{
    public interface IProductRepository
    {
        IQueryable<Product> Products {get;}
        void SaveProduct(Product product);
        Product Delete(int productId);
    }
}
