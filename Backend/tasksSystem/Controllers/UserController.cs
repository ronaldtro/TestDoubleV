using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tasksSystem.Requests;
using tasksSystem.Services;

namespace tasksSystem.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }

        [Authorize]
        [HttpPut]
        [Route("user/{id}")]
        public async Task<IActionResult> PutUser(string id, UserRequest request)
        {
            var result = await _userService.PutUser(id, request, User);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        [Route("user/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUser(id, User);

            return Ok(result);
        }

        [HttpGet]
        [Route("user/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var result = await _userService.GetUser(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetUsers();

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("user/task")]
        public async Task<IActionResult> PostUserTask(UserTaskRequest request)
        {
            var result = await _userService.PostUserTask(request, User);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        [Route("user/role")]
        public async Task<IActionResult> PostUserRole(UserRoleRequest request)
        {
            var result = await _userService.PostUserRole(request);

            return Ok(result);
        }

    }
}
