using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebNewShop.Models;
using WebNewShop.Models.Interface;

namespace WebNewShop.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartSession cartSession;
        private Cart cart;
        public CartController(IProductRepository repository1, Cart servicecart)
        {
            repository = repository1;
            cart = servicecart;
        }
        
        
        [HttpPost]
        public RedirectToActionResult AddToCart(int productId)
        {
            Product onecart = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (onecart!=null)
            {
                
                cart.AddItem(onecart, 1);
                
            }
            
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveCart(int product)
        {
            Product onecart = repository.Products.FirstOrDefault(p => p.ProductId == product);
            if (onecart != null)
            {

                cart.RemoveLine(onecart);

            }

            return RedirectToAction("Index");
        }
         
        public IActionResult Index()
        {
            return View(new CartSession
            {
                Cart = cart
            });
            
        }
        
    }
}