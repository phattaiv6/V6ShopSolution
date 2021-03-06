using System;
using System.Collections.Generic;
using System.Text;
using V6Shop.Data.Entities;

namespace V6Shop.Data
{
    public class Product
    {
        public int ID {  set; get; }
        public Decimal Price {  set; get; }
        public Decimal OriginalPrice {  set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public string SeoAlias { set; get; }
        public List<ProductInCategory> ProductInCategories { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }

        public List<ProductImage> ProductImages { get; set; }
    }
}
