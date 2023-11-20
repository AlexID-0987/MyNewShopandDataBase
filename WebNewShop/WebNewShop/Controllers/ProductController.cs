using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebNewShop.Models.Interface;
using WebNewShop.Models.ViewModels;

namespace WebNewShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository product;
        public int PageSize = 4;
        public ProductController(IProductRepository repository)
        {
            product = repository;
        }
        public IActionResult Index(string category, int page=1)
        {
            var item = product.Products.ToList();
            var count = item.Count();
            int size = 3;
            var pagination = item.OrderBy(p => p.ProductId).Skip((page - 1) * size).Take(size).ToList();
            PagingInfo pagingInfo = new PagingInfo(count, page, size);
            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                PagingInfo = pagingInfo,
                Products = pagination,
                CurrentCategory=category
            };
            ViewBag.Count = count;
            ViewBag.Page = pagingInfo;
            ViewBag.PageNumber = page;


            return View(pagination);
        }
        [HttpPost]
         public IActionResult ChoiseProduct(int page=1)
        {
            var form = Request.Form;
            var categ = form["select"];
            var item = product.Products.ToList();
            var count = item.Count();
            int size = 2;
            var pagination1 = item.Where(p =>p.Category == categ).OrderBy(p => p.ProductId).ToList();
            
            return View(pagination1);
        }
        
    }
}