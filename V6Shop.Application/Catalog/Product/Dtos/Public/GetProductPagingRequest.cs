using System;
using System.Collections.Generic;
using System.Text;
using V6Shop.Application.Catalog.ProductS.DTO;

namespace V6Shop.Application.Catalog.Productt.Dtos.Public
{
    public class GetProductPagingRequest : PagingRequestBase

    {
        public int CategoryId { get; set; }
    }
}
