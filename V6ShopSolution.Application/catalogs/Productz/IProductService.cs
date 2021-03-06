using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V6shopSolution.ViewModel.Catalog.ProductImages;
using V6shopSolution.ViewModel.Catalog.Products;
using V6shopSolution.ViewModel.Common;
using V6ShopSolution.Application.catalogs.ProductImages;

namespace V6ShopSolution.Application.catalogs.Productz
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);
        Task AddViewCount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId );

        Task<int> UpdateImage(int imageId,  ProductImageUpdateRequest request);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
        Task<ProductViewModel> GetById(int productId , string languageId);
        Task<ProductImageViewModel> GetImageById(int productId);
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);

    }
}
