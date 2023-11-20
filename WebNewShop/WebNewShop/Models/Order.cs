using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [BindNever]
        public ICollection<CartLine> lines { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
        [Required(ErrorMessage="Please enter Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Phone!")]
        public string Phone { get; set; }

    }
}
