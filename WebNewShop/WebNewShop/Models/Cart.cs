using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        
        public virtual void AddItem( Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(s => s.Product.ProductId == product.ProductId)
                .FirstOrDefault();
            if(line==null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });

            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product) =>
            lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);
        public virtual decimal TotalValue() =>
            lineCollection.Sum(s => s.Product.ConvertToDecimal() * s.Quantity);
        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }
}
