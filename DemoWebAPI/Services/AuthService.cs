using DemoWebAPI.Configs;
using DemoWebAPI.Repository;
using DemoWebAPI.Requests;
using DemoWebAPI.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DemoWebAPI.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;

        private readonly JwtConfig _jwtConfig;

        public AuthService(UserRepository userRepository, IOptions<JwtConfig> jwtConfig)
        {
            _userRepository = userRepository;
            _jwtConfig = jwtConfig.Value;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                // Check user
                var user = await _userRepository.GetUserByEmailAsync(request.Email);
                if (user is null)
                    throw new Exception("User is not found");
                if (!user.Password.Equals(request.Password))
                {
                    throw new Exception("Password is not correct");
                }
                // Gán claims
                var claims = new List<Claim>
                {
                    new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new (ClaimTypes.Name, user.Email ?? string.Empty),
                };

                // Config access token
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.Now.AddMinutes(_jwtConfig.ExpireMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfig.Secret)), SecurityAlgorithms.HmacSha256),
                    Subject = new ClaimsIdentity(claims)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var accessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

                return new LoginResponse
                {
                    UserId = user.Id,
                    AccessToken = accessToken,
                    ExpireTime = tokenDescriptor.Expires.Value.ToString("dd/MM/yyyy HH:mm:ss")
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi hệ thống");
            }
        }
    }
}
