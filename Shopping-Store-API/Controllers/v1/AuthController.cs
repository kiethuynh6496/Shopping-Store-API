using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;

namespace Shopping_Store_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public AuthController(IMapper mapper, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
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

            // Creata Shopping Cart and save userId to Cookie
            var shoppingCart = _unitOfWork.ShoppingCart.CreateShoppingCart(user.Id, Response);

            // Add Shopping Cart
            var createShoppingCartResult = await _unitOfWork.ShoppingCart.Add(shoppingCart);
            if (createShoppingCartResult == false)
            {
                throw new ApiError((int)ErrorCodes.ShoppingCartCantBeCreated);
            }

            if(await _unitOfWork.CommitAsync() <= 0)
            {
                throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);
            }

            return CustomResult(ResponseMesssage.UserRegisteredSuccessfully.DisplayName(), System.Net.HttpStatusCode.Created);
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

            Helpers.SaveDataToCookie(user.Id, Response);


            return CustomResult(ResponseMesssage.LoggedInSuccessfully.DisplayName(), token, System.Net.HttpStatusCode.OK);
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            // Remove the authentication cookie
            Response.Cookies.Delete("userId");
            return CustomResult(ResponseMesssage.LoggedOutSuccessfully.DisplayName(), System.Net.HttpStatusCode.Created);
        }

        private async Task<bool> IsUserExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}