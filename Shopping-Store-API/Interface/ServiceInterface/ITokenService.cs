using Shopping_Store_API.DTOs.AuthDTOs;
using Shopping_Store_API.Entities.ERP;
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
