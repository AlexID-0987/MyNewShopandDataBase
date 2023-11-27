using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebNewShop.Models;
using WebNewShop.Models.Interface;

namespace WebNewShop.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository product;
        public AdminController(IProductRepository productRepository)
        {
            product = productRepository;
        }
        public IActionResult Index() => View(product.Products);
        public IActionResult Create() => View("Edit", new Product());
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletePr = product.Delete(productId);
            if(deletePr!=null)
            {
                TempData["message"] = $"{deletePr.NameProduct} was deleted!";
            }
            return Redirect("Index");
        }
        public IActionResult Edit(int productId) => View(product.Products.FirstOrDefault(p => p.ProductId == productId));
        [HttpPost]
        public IActionResult Edit(Product productEdit)
        {
            if(ModelState.IsValid)
            {
                product.SaveProduct(productEdit);
                TempData["message"] = $"{productEdit.NameProduct} has been saved";
                return Redirect("Index");
            }
            else
            {
                return View(productEdit);
            }
        }
    }
}