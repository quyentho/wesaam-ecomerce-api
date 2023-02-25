using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WesaamEcomerce.API.DTOs.Category;
using WesaamEcomerce.EntityFramework.Models;
using WesaamEcomerce.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WesaamEcomerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServices<Category> _categoryServices;
        private readonly IMapper _mapper;

        public CategoryController(IServices<Category> categoryServices, IMapper mapper)
        {
            this._categoryServices = categoryServices;
            this._mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAsync()
        {
            var categorys = await _categoryServices.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categorys);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var category = await _categoryServices.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCategoryDto category)
        {
            int categoryId = await _categoryServices.CreateAsync(_mapper.Map<Category>(category));
            return CreatedAtAction(nameof(GetAsync), new { id = categoryId });
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateCategoryDto value)
        {
            await _categoryServices.UpdateAsync(_mapper.Map<Category>(value), id);
            return Ok();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryServices.DeleteAsync(id);
            return Ok();
        }
    }
}
