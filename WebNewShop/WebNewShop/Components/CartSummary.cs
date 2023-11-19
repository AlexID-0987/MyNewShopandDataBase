using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNewShop.Models;

namespace WebNewShop.Components
{
    public class CartSummary:ViewComponent
    {
        private Cart cart;
        public CartSummary(Cart cartservice)
        {
            cart = cartservice;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
