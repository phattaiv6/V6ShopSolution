using System;
using System.Collections.Generic;
using System.Text;

namespace V6Shop.Application.Catalog.ProductS.DTO
{
   public class PagingRequestBase
    {
        public int PageIndex { set; get; } // vị trí lấy trang số bao nhiêu
        public int PageSize { set; get; }
    }
}
