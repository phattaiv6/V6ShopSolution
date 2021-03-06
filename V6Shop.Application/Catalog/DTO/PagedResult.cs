using System;
using System.Collections.Generic;
using System.Text;

namespace V6Shop.Application.Catalog.Products.DTO
{
    public class PagedResult<T>
    {
        public List<T> Items { set; get; } //generic
        public int TotalRecord { set; get; }
    }
}
