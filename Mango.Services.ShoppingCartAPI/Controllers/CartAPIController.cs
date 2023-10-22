using AutoMapper;
using Mango.Services.ShoppingCartAPI.Data;
using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartAPIController : ControllerBase
    {
        private ResponseDto _responseDto;
        private IMapper _mapper;
        private readonly AppDbContext _db;

        public CartAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // Update + Insert = Upsert
        [HttpPost("CartUpsert")]
        public async Task<ResponseDto> CartUpsert(CartDto cartDto)
        {
            try
            {
                var cartHeaderFromDb = await _db.CartHeaders.FirstOrDefaultAsync(
                     u => u.UserId == cartDto.CartHeader.UserId);
                if (cartHeaderFromDb == null)
                {
                    // create header
                    CartHeader cartHeader = _mapper.Map<CartHeader>(cartDto.CartHeader);
                    _db.CartHeaders.Add(cartHeader);
                    await _db.SaveChangesAsync();

                    cartDto.CartDetails.First().CartHeaderId = cartHeader.CartHeaderId;
                    CartDetail cartDetail = _mapper.Map<CartDetail>(cartDto.CartDetails.First());
                    await _db.SaveChangesAsync();
                }
                else
                {
                    // check if details has the same product
                }
                var cartDetailsFromDb = await _db.CartDetails.FirstOrDefaultAsync(
                     u => u.CartHeaderId == cartHeaderFromDb.CartHeaderId &&
                     u.ProductId == cartDto.CartDetails.First().ProductId);
                if(cartDetailsFromDb == null) 
                {
                    // create cartDetails
                }
                else
                {
                    // update count 
                }
            }
            catch (Exception ex)
            {
                _responseDto.Message = ex.Message.ToString();
                _responseDto.IsSuccess = false;
            }

            return null;
        }
    }
}
