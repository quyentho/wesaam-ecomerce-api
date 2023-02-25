using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WesaamEcomerce.API.DTOs.Product;
using WesaamEcomerce.API.Helpers;
using WesaamEcomerce.EntityFramework.Models;
using WesaamEcomerce.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WesaamEcomerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServices<Product> _productServices;
        private readonly IMapper _mapper;

        public ProductController(IServices<Product> productServices, IMapper mapper)
        {
            this._productServices = productServices;
            this._mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAsync()
        {
            var products = await _productServices.GetAllAsync();
            if (products == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await _productServices.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateProductDto product)
        {
            int productId = await _productServices.CreateAsync(_mapper.Map<Product>(product));
            return CreatedAtAction(nameof(GetAsync), new { id = productId });
        }

        // POST api/<ProductController>/images/{id}
        [HttpPost("/images/{id}")]
        public async Task<IActionResult> UploadImagesAsync([FromBody] List<IFormFile> files, int id)
        {
            var imageUrls = await FileUploadHelper.UploadFiles(files);
            var product = await _productServices.GetByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            product!.ImageUrls = imageUrls;
            await _productServices.UpdateAsync(product, id);

            return Ok();
        }

        // POST api/<ProductController>/story-images
        [HttpPost("/story-images/{id}")]
        public async Task<IActionResult> UploadStoryImagesAsync([FromBody] List<IFormFile> files, int id)
        {
            var imageUrls = await FileUploadHelper.UploadFiles(files);
            var product = await _productServices.GetByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            product!.StoryImageUrls = imageUrls;
            await _productServices.UpdateAsync(product, id);

            return Ok();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateProductDto value)
        {
            await _productServices.UpdateAsync(_mapper.Map<Product>(value), id);
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productServices.DeleteAsync(id);
            return Ok();
        }
    }
}
