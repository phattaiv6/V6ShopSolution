using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V6Shop.Application.Catalog.Productt.Dtos.Manage;
using V6Shop.Application.Catalog.Products.DTO;
using V6Shop.Application.Catalog.Productt.Dtos;

namespace V6Shop.Application.Catalog.Products
{
    public interface IManageProductService
    {
       Task <int> Create(ProductCreateRequest request);
       Task <int> Update(ProductUpdateRequest request);

       
       Task<bool> UpdatePrice(int productId, decimal NewPrice);
       
       Task<bool> UpdateStock(int productId, int addQuantity);
       Task AddViewCount(int productId);
       Task<int> Delete(int producId);
       Task< List<ProductViewModel>> GetAll();
       Task <PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request );
    }                                        // tìm kiếm , số trang , kích cỡ            
}
