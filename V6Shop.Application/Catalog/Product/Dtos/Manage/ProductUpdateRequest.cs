using System;
using System.Collections.Generic;
using System.Text;

namespace V6Shop.Application.Catalog.Productt.Dtos.Manage
{
    public class ProductUpdateRequest

    {
        public int Id { set; get; }
        public decimal Price { set;  get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public int Stock { set; get; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }

        
    }
}
