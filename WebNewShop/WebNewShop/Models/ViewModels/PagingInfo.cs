using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNewShop.Models.ViewModels
{
    public class PagingInfo
    {
        public int PageNumber { get; private set; }
        public int TotalItem { get; private set; }
        
        public PagingInfo(int count, int pageNumber,int pageSize)
        {
            PageNumber = pageNumber;
            TotalItem = (int)Math.Ceiling(count / (double)pageSize);
        }
        public bool Increment
        {
            get { return (PageNumber > 0); }
        }
        public bool Decrement
        {
            get { return (PageNumber < TotalItem); }
        }
    }
}
