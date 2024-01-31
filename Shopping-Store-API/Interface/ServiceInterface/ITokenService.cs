using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Service.Parameters;
using System.Security.Claims;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface ITokenService
    {
        Task<Token> GenerateAccessRefreshToken(AppUser appUser);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
