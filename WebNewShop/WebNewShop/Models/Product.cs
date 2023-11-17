using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models
{
    public class Product
    {
        public int ProductId { get; set;}
        public string NameProduct { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public decimal ConvertToDecimal()
        {
            return Convert.ToDecimal(Price);
        }
    }
}
