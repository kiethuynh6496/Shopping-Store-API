using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    [Route("api/v{version:apiVersion}/token")]
    [Authorize]
    public class TokenController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public TokenController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokenRequestDTO tokenRequestDTO)
        {
            if (tokenRequestDTO is null) throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);

            // Extract the access token from the Authorization header
            string authorizationHeader = Request.Headers["Authorization"];
            string accessToken = string.Empty;
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                accessToken = authorizationHeader.Substring("Bearer ".Length).Trim();
            }
            string refreshToken = tokenRequestDTO.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var email = principal.Identity.Name; // this is mapped to the Name claim by default
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == email);

            var userToken = await _unitOfWork.Token.FindByCondition(u => u.UserId == user.Id && u.RefreshToken == refreshToken)
                                                   .FirstOrDefaultAsync();

            if (user is null || userToken is null || userToken.RefreshToken != refreshToken || userToken.ExpiresAt < DateTime.Now)
                throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);

            var newTokenUser = await _tokenService.GenerateAccessToken(user);

            return CustomResult(ResponseMesssage.TokenAreRefreshedSuccessfully.DisplayName(), newTokenUser, System.Net.HttpStatusCode.Created);

        }

        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke(TokenRequestDTO tokenRequestDTO)
        {
            if (tokenRequestDTO.RefreshToken.IsNullOrEmpty()) throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);

            var userToken = await _unitOfWork.Token.FindByCondition(u => u.RefreshToken == tokenRequestDTO.RefreshToken)
                                                   .AsTracking()
                                                   .FirstOrDefaultAsync();

            if (userToken is null) throw new ApiError((int)ErrorCodes.TokenIsInValid);

            userToken.RefreshToken = null;
            var IsCommitted = await _unitOfWork.CommitAsync();
            if (IsCommitted <= 0)
            {
                throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);
            }

            return CustomResult(ResponseMesssage.TokenAreRevokedSuccessfully.DisplayName(), System.Net.HttpStatusCode.OK);
        }
    }
}