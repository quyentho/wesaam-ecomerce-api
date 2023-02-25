using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WesaamEcomerce.API.DTOs.Coupon;
using WesaamEcomerce.EntityFramework.Models;
using WesaamEcomerce.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WesaamEcomerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IServices<Coupon> _couponServices;
        private readonly IMapper _mapper;

        public CouponController(IServices<Coupon> couponServices, IMapper mapper)
        {
            this._couponServices = couponServices;
            this._mapper = mapper;
        }
        // GET: api/<CouponController>
        [HttpGet]
        public async Task<IEnumerable<CouponDto>> GetAsync()
        {
            var coupons = await _couponServices.GetAllAsync();

            return _mapper.Map<IEnumerable<CouponDto>>(coupons);
        }

        // GET api/<CouponController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var coupon = await _couponServices.GetByIdAsync(id);
            if(coupon == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CouponDto>(coupon));
        }

        // POST api/<CouponController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCouponDto coupon)
        {
            int couponId = await _couponServices.CreateAsync(_mapper.Map<Coupon>(coupon));
            return CreatedAtAction(nameof(Coupon), couponId);
        }

        // PUT api/<CouponController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateCouponDto value)
        {
            await _couponServices.UpdateAsync(_mapper.Map<Coupon>(value), id);
            return Ok();
        }

        // DELETE api/<CouponController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await  _couponServices.DeleteAsync(id);
            return Ok();
        }
    }
}
