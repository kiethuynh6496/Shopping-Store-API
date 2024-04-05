using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs.AuthDTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;
using static Shopping_Store_API.Commons.Constants;

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
        private readonly ILogger<AuthController> _logger;


        public AuthController(IMapper mapper, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, ITokenService tokenService, ILogger<AuthController> logger)
        {
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _logger = logger;
        }

        /// <summary>
        /// Sign up a User (the default role : User)
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/v1/auth/register
        ///     {        
        ///       "email": "userdemo@gmail.com",
        ///       "password": "1234"
        ///     }
        /// </remarks>
        /// <param name="registerDTO"></param>
        /// <returns></returns>
        /// <exception cref="ApiError"></exception>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            _logger.LogInformation("Start Register!");
            if (await IsUserExists(registerDTO.Email))
            {
                _logger.LogInformation("Email existed!");
                throw new ApiError((int)ErrorCodes.EmailIsAlreadyTaken);
            }

            var user = _mapper.Map<AppUser>(registerDTO);
            user.UserName = registerDTO.Email.ToLower();

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                _logger.LogInformation("User is created successfully!");
                return BadRequest(result.Errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, Role.User.ToString());

            if (!roleResult.Succeeded)
            {
                _logger.LogInformation("Role User is created successfully!");
                return BadRequest(roleResult.Errors);
            }

            // Creata Shopping Cart and save userId to Cookie
            var shoppingCart = _unitOfWork.ShoppingCart.CreateShoppingCart(user.Id, Response);

            // Add Shopping Cart
            var createShoppingCartResult = await _unitOfWork.ShoppingCart.Add(shoppingCart);
            if (createShoppingCartResult == false) throw new ApiError((int)ErrorCodes.ShoppingCartCantBeCreated);
            _logger.LogInformation("Shopping Cart is created successfully!");

            if(await _unitOfWork.CommitAsync() <= 0) throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);

            _logger.LogInformation("Close Register!");
            return CustomResult(ResponseMesssage.UserRegisteredSuccessfully.DisplayName(), System.Net.HttpStatusCode.Created);
        }

        /// <summary>
        /// Sign in a User (after signing in successfully, "userId" is stored in Cookies)
        /// </summary>
        /// <remarks>
        /// Sample request: Here is an Admin Account (role: Admin)
        /// 
        ///     POST api/v1/auth/login
        ///     {        
        ///       "email": "admin@gmail.com",
        ///       "password": "12345"
        ///     }
        /// </remarks>
        /// <param name="logInRequestDTO"></param>
        /// <returns></returns>
        /// <exception cref="ApiError"></exception>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LogInRequestDTO logInRequestDTO)
        {
            _logger.LogInformation("Start Login!");
            if (logInRequestDTO is null)
            {
                _logger.LogInformation("Enter your email and password, Please!");
                throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Email == logInRequestDTO.Email);
            if (user == null)
            {
                _logger.LogInformation("Email is not correct!");
                throw new ApiError((int)ErrorCodes.UserIsUnauthenticated);
            }


            var result = await _userManager.CheckPasswordAsync(user, logInRequestDTO.Password);
            if (!result)
            {
                _logger.LogInformation("Password is not correct!");
                throw new ApiError((int)ErrorCodes.UserIsUnauthorized);
            }

            var token = await _tokenService.GenerateAccessToken(user);
            if(token is not null)
            {
                _logger.LogInformation("Generate 2 tokens successfully!");
            }

            Helpers.SaveDataToCookie(user.Id, Response);
            _logger.LogInformation("Login Successfully!");
            _logger.LogInformation("Close Login!");

            return CustomResult(ResponseMesssage.LoggedInSuccessfully.DisplayName(), token, System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// Log out a User by deleting "userId"
        /// </summary>
        /// <returns></returns>
        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            // Remove the authentication cookie
            Response.Cookies.Delete("userId");
            _logger.LogInformation("userId isn't remove from Coockies.");

            return CustomResult(ResponseMesssage.LoggedOutSuccessfully.DisplayName(), System.Net.HttpStatusCode.Created);
        }

        private async Task<bool> IsUserExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }
}