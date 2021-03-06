using System;
using System.Collections.Generic;
using System.Text;
using V6Shop.Data.EF.Enums;
using V6Shop.Data.Entities;

namespace V6Shop.Data.Entities
{
    public class Category
    {
        public int Id { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public int? ParentID { set; get; }
        public Status Status { set; get; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}
