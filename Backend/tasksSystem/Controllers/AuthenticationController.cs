using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tasksSystem.Requests;
using tasksSystem.Services;

namespace tasksSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthService _authService;
        public AuthenticationController(IAuthService authService) {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Authentication([FromBody] AuthRequest request)
        {
            var result = await _authService.Authentication(request);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request)
        {
            var result = await _authService.Register(request, User);

            return Ok(result);
        }

        //[Authorize]
        //[HttpPost]
        //[Route("/testJwt")]
        //public async Task<IActionResult> testJwt()
        //{
        //    var result = await _authService.testJwt(User);

        //    return Ok(result);
        //}

    }
}
