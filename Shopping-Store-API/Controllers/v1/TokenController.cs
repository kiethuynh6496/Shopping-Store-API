using AutoMapper;
using Azure.Core;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
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
    [Route("api/v{version:apiVersion}/token")]
    public class TokenController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public TokenController(IMapper mapper, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(TokenRequestDTO tokenRequestDTO)
        {
            if (tokenRequestDTO is null) throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);

            string accessToken = tokenRequestDTO.AccessToken;
            string refreshToken = tokenRequestDTO.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var email = principal.Identity.Name;
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == email);

            var userToken = await _unitOfWork.Token.FindByCondition(u => u.UserId == user.Id && u.AccessToken == accessToken)
                                                   .FirstOrDefaultAsync();

            if (user is null || userToken.RefreshToken != refreshToken || userToken.ExpiresAt < DateTime.Now)
                throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);

            var newTokenUser = await _tokenService.GenerateAccessRefreshToken(user);

            var tokenResponseDTO = _mapper.Map<LogInResponseDTO>(newTokenUser);

            var IsCommitted = await _unitOfWork.CommitAsync();
            if (IsCommitted <= 0)
            {
                throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);
            }
            else
            {
                return CustomResult(ResponseMesssage.TokenAreRefreshedSuccessfully.DisplayName(), tokenResponseDTO, System.Net.HttpStatusCode.Created);
            }
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke()
        {
            // Extract the access token from the Authorization header
            string accessToken = Request.Headers["Authorization"];

            var userToken = await _unitOfWork.Token.FindByCondition(u => u.AccessToken == accessToken)
                                                   .AsTracking()
                                                   .FirstOrDefaultAsync();
            userToken.RefreshToken = null;
            var IsCommitted = await _unitOfWork.CommitAsync();
            if (IsCommitted <= 0)
            {
                throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);
            }
            else
            {
                return CustomResult(ResponseMesssage.TokenAreRevokedSuccessfully.DisplayName(), System.Net.HttpStatusCode.OK);
            }
        }
    }
}