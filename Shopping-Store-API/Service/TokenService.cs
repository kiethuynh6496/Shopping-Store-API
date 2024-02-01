using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;
using Shopping_Store_API.Service.Parameters;
using Shopping_Store_API.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Shopping_Store_API.Service
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public TokenService(UserManager<AppUser> userManager, IConfiguration config, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _config = config;
            _unitOfWork = unitOfWork;
        }

        public async Task<Token> GenerateAccessRefreshToken(AppUser appUser)
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Sid, appUser.Id),
                new Claim(ClaimTypes.Name, appUser.Email),
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim("Audience", _config["JWT:ValidAudience"]),
                new Claim("Issuer", _config["JWT:ValidIssuer"])
            };
            var roles = await _userManager.GetRolesAsync(appUser);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"])), SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = creds,
                Audience = _config["JWT:ValidAudience"],
                Issuer = _config["JWT:ValidIssuer"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            var tokenUser = new Token { 
                                        UserId = appUser.Id,
                                        AccessToken = accessToken,
                                        RefreshToken = refreshToken,
                                        ExpiresAt = DateTime.Now.AddDays(7),
                                        IsDeleted = false,
                                        CreatedDate = DateTime.Now,
                                        CreatedBy = appUser.Email,
                                        UpdatedBy = string.Empty
                                        };
            var result = await _unitOfWork.Token.Add(tokenUser);
            if(result == false) throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);
            var IsCommitted = await _unitOfWork.CommitAsync();
            if (IsCommitted > 0) return tokenUser;
            return null;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["JWT:ValidIssuer"],
                ValidAudience = _config["JWT:ValidAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase))
                throw new ApiError((int)ErrorCodes.TokenIsInValid);

            return principal;
        }
    }
}
