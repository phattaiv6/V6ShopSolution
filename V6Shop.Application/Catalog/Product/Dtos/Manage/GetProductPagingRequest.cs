using System;
using System.Collections.Generic;
using System.Text;
using V6Shop.Application.Catalog.ProductS.DTO;

namespace V6Shop.Application.Catalog.Productt.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase

    {
        public string Keywork { set; get; }
        public List<int> CategoryIds { set; get; } //truyền vào để search
    }
}
