using dotNETCoreAPIRevamp.Models;
using dotNETCoreAPIRevamp.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dotNETCoreAPIRevamp.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IConfiguration _configuration;

        public IdentityService(UserManager<IdentityUser> userManager, JwtSettings jwtSettings, IConfiguration configuration)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings;
            _configuration = configuration;
        }

        public async Task<AuthenticationResult> RegisterAsync(string username, string email, string password)
        {
            var existingUser = await _userManager.FindByNameAsync(username);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Username already exists." },
                };
            };

            var newUser = new IdentityUser
            {
                UserName = username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = email
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description)
                };
            }

            return GenerateAuthenticationResultForUser(newUser);

        }

        public async Task<AuthenticationResult> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User does not exist" }
                };
            }

            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User/password combination is wrong" }
                };
            }

            return GenerateAuthenticationResultForUser(user);
        }

        private AuthenticationResult GenerateAuthenticationResultForUser(IdentityUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, newUser.Email),
                    new Claim("id", newUser.Id)
                }),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
            };
        }
    }
}
