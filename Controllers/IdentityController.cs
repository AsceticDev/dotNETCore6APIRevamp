using dotNETCoreAPIRevamp.Contracts.V1;
using dotNETCoreAPIRevamp.Contracts.V1.Requests;
using dotNETCoreAPIRevamp.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotNETCoreAPIRevamp.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            //var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            return Ok();
        }
    }
}
