using dotNETCoreAPIRevamp.Models;
using Microsoft.AspNetCore.Identity;

namespace dotNETCoreAPIRevamp.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            var existingUser = await _userManager.FindByNameAsync(email);

            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    //Errors = new[] { "User with this email already exists."}
                };
            };

            var newUser = new IdentityUser
            {

            };

            return new AuthenticationResult { Error = new[] { "bingbong" } };
        }
    }
}
