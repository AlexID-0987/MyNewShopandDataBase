using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebNewShop.Models.Interface;

namespace WebNewShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository product;
        public ProductController(IProductRepository repository)
        {
            product = repository;
        }
        public IActionResult Index()
        {
            return View(product.Products);
        }
    }
}