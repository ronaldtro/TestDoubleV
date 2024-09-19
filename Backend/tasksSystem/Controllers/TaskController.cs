using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tasksSystem.Requests;
using tasksSystem.Services;

namespace tasksSystem.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Authorize]
        [HttpPost]
        [Route("task")]
        public async Task<IActionResult> PostTask(TaskRequest request)
        {
            var result = await _taskService.PostTask(request, User);

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        [Route("task/{id}")]
        public async Task<IActionResult> PutTask(string id, TaskRequest request)
        {
            var result = await _taskService.PutTask(id, request, User);

            return Ok(result);
        }

        [Authorize]
        [HttpDelete]
        [Route("task/{id}")]
        public async Task<IActionResult> DeleteTask(string id)
        {
            var result = await _taskService.DeleteTask(id, User);

            return Ok(result);
        }

        [HttpGet]
        [Route("task/{id}")]
        public async Task<IActionResult> GetTask(string id)
        {
            var result = await _taskService.GetTask(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("tasks")]
        public async Task<IActionResult> GetTasks()
        {
            var result = await _taskService.GetTasks();

            return Ok(result);
        }
    }
}
