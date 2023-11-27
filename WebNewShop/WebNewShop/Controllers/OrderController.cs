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
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository order, Cart cart1)
        {
            repository = order;
            cart = cart1;
        }
        [Authorize]
        public ViewResult List() => View(repository.orders.Where(o => !o.Shipped));

        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderId)
        {
            Order order = repository.orders
                .FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {
                order.Shipped = true;
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order myOrder)
        {
            if (ModelState.IsValid)
            {
                myOrder.lines = cart.Lines.ToArray();
                repository.SaveOrder(myOrder);
                return Redirect(nameof(Completed));
            }
            return View(myOrder);

        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}