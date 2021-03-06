using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V6shopSolution.ViewModel.Catalog.Products;
using V6ShopSolution.Application.catalogs.ProductImages;
using V6ShopSolution.Application.catalogs.Productz;

namespace V6ShopSolution.BackEndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {


        private readonly IProductService _iProductService;
        public ProductsController(  IProductService iProductService)
        {
            
            _iProductService = iProductService;
        }
       
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPaging(string languageId, [FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await _iProductService.GetAllByCategoryId(languageId, request);
            return Ok(products);
        }
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _iProductService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("cannot find  product");
            return Ok(product);
        }
        [HttpPost] // tạo mới
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request) //post nên frombody
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }    
            var productId = await _iProductService.Create(request);
            if (productId == 0)
                return BadRequest();
            var product = await _iProductService.GetById(productId, request.LanguageId); // truyền về productId
            return CreatedAtAction(nameof(GetById),new {id = productId }, product);

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request) //using data để sử dụng trên aplication swagger
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _iProductService.Update(request);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();

        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete([FromForm] int productId) //using data
        {
            var affectedResult = await _iProductService.delete(productId);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();

        }
        [HttpPatch("{productId}/{newPrice}")] //update 1 phần của bản ghi
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice) 
        {
            var isSuccesful = await _iProductService.UpdatePrice(productId, newPrice);
            if (isSuccesful)
                return Ok();

            return BadRequest();

        }
        //image
        [HttpPost("{productId}/images")] // tạo mới
        public async Task<IActionResult> CreateImage(int productId,[FromForm] ProductImageCreateRequest request) //post nên frombody
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _iProductService.AddImage(productId,request);
            if (imageId == 0)
                return BadRequest();
            var image = await _iProductService.GetImageById(imageId); // truyền về productId
            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image); //post sử dụng created trả về 201 

        }
        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _iProductService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _iProductService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _iProductService.GetImageById(imageId);
            if (image == null)
                return BadRequest("cannot find  product");
            return Ok(image);
        }
    }
   
}

