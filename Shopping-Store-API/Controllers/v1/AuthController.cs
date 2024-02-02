using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface.ServiceInterface;
using Shopping_Store_API.Service.Parameters;
using Shopping_Store_API.Users;
using System.Diagnostics.Metrics;

namespace Shopping_Store_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(IMapper mapper, UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (await IsUserExists(registerDTO.Email)) throw new ApiError((int)ErrorCodes.EmailIsAlreadyTaken);

            var user = _mapper.Map<AppUser>(registerDTO);
            user.UserName = registerDTO.Email.ToLower();

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), System.Net.HttpStatusCode.Created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LogInRequestDTO logInRequestDTO)
        {
            if (logInRequestDTO is null) throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);

            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == logInRequestDTO.Email);
            if (user == null) throw new ApiError((int)ErrorCodes.UserIsUnauthenticated);

            var result = await _userManager.CheckPasswordAsync(user, logInRequestDTO.Password);
            if (!result) throw new ApiError((int)ErrorCodes.UserIsUnauthorized);

            var token = await _tokenService.GenerateAccessToken(user);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), token);
        }

        /// <summary>
        /// Remove product item to shopping cart
        /// </summary>
        /// <returns></returns>
        //[HttpDelete]
        //public async Task<IActionResult> RemoveItemToShoppingCartAsync([FromQuery]ShoppingCartParameters shoppingCartParameters)
        //{
        //    var removeResult = await _shoppingCartService.RemoveItemToShoppingCart(Request.Cookies["userId"], shoppingCartParameters);

        //    if (!removeResult)
        //    {
        //        throw new ApiError((int)ErrorCodes.DataArentDeletedSuccessfully);
        //    }

        //    return CustomResult(ResponseMesssage.DataAreDeletedSuccessfully.DisplayName(), System.Net.HttpStatusCode.OK);
        //}

        private async Task<bool> IsUserExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}