using System;
using System.Collections.Generic;
using System.Text;
using V6Shop.Application.Catalog.Productt.Dtos.Public;
using V6Shop.Application.Catalog.Products.DTO;
using V6Shop.Application.Catalog.Productt.Dtos;

namespace V6Shop.Application.Catalog.Products
{
    public  interface IPublicProductService
    {
        PagedResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request ); //lấy danh sách sản phẩm
    }
}
