using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V6Shop.Application.Catalog.Productt.Dtos.Manage;
using System.Linq;
using V6Shop.Application.Catalog.Products.DTO;
using V6Shop.Data;
using V6Shop.Data.EF;
using V6Shop.Application.Catalog.Productt.Dtos;
using V6Shop.Data.Entities;
using V6ShopSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;
namespace V6Shop.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly V6ShopDBContext _context; //biến nội bộ để gán vào
        public ManageProductService(V6ShopDBContext context)
        {
            _context = context; // gán vào
        }

        public  async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task <int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation> // kiểu cha con
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId 
                    }
                }

            };
            _context.Products.Add(product);
         return await  _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new V6ShopException($"Can't find a product : {productId }");
            _context.Products.Remove(product);
           return await _context.SaveChangesAsync();
        }

       

      

        public async Task <int> Update(ProductUpdateRequest request)
        {
           var product = await _context.Products.FindAsync(request.Id);
           var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId) ;
           if (product == null || productTranslations == null) throw new V6ShopException($"Can't find a product  with Id: {request.Id }");
            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;

           return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal NewPrice)
        {
            var product = _context.Products.FindAsync(productId);
            if (product == null) throw new V6ShopException($"Can't find a product  with Id: {productId }");
            else { product.Price = NewPrice; }
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> UpdateStock(int productId, int addQuantity)
        {
            throw new NotImplementedException();
        }
        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keywork))
                query = query.Where(x => x.pt.Name.Contains(request.Keywork));

            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    ID = x.p.ID,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}
