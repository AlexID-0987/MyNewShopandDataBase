using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models
{
    public class Product
    {
        public int ProductId { get; set;}
        [Required(ErrorMessage="Please enter a PRODUCT NAME")]
        public string NameProduct { get; set; }
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage ="Please enter a positive price")]
        public double Price { get; set; }
        [Required(ErrorMessage ="Please category")]
        public string Category { get; set; }
        public decimal ConvertToDecimal()
        {
            return Convert.ToDecimal(Price);
        }
    }
}
