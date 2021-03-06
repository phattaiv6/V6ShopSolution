using System;
using System.Collections.Generic;
using System.Text;

namespace V6Shop.Application.Catalog.Productt.Dtos
{
    public class ProductViewModel
    {
        //lấy những thuộc tính mà muốn hiên thị
        public int ID { set; get; }
        public Decimal Price { set; get; }
        public Decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public string SeoAlias { set; get; }
        public int ProductId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

       
        public string LanguageId { set; get; }
    }
}
