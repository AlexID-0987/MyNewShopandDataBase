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
        public CartController(IProductRepository repository1)
        {
            repository = repository1;
        }
        
        
        [HttpPost]
        public RedirectToActionResult AddToCart(int productId)
        {
            Product onecart = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (onecart!=null)
            {
                Cart cart = GetCart();
                cart.AddItem(onecart, 1);
                SaveCart(cart);
            }
            
            return RedirectToAction("Index");
        }
        
        public IActionResult Index()
        {
            return View(new CartSession
            {
                Cart = GetCart()
            });
            
        }
        private Cart GetCart()
        {
            Cart sessioncart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            
            return sessioncart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}