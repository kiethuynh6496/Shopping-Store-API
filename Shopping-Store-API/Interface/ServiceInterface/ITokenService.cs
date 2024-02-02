using Shopping_Store_API.DTOs;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Service.Parameters;
using System.Security.Claims;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface ITokenService
    {
        Task<LogInResponseDTO> GenerateAccessToken(AppUser appUser);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
