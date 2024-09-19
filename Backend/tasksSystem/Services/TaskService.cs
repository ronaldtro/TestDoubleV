using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using tasksSystem.Models;
using tasksSystem.Requests;

namespace tasksSystem.Services
{
    public interface ITaskService
    {
        Task<Object> PostTask(TaskRequest request, ClaimsPrincipal User);
        Task<Object> PutTask(string id, TaskRequest request, ClaimsPrincipal User);
        Task<Object> DeleteTask(string id, ClaimsPrincipal User);
        Task<Object> GetTask(string id);
        Task<Object> GetTasks();
    }
    public class TaskService:ITaskService
    {
        private TasksSystemDbContext _db;
        private PasswordHasher<string> _passwordHasher;

        public TaskService(TasksSystemDbContext db) {
            _db = db;
            _passwordHasher = new PasswordHasher<string>();
        }

        public async Task<Object> PostTask(TaskRequest request, ClaimsPrincipal User)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                UserRole? verifyRole = _db.UserRoles.FirstOrDefault(ur => ur.RoleId == "1" && ur.UserId == userId);

                if (verifyRole == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Accion no permitida para el usuario"
                    };
                }

                Models.Task newTask = new Models.Task
                {
                    TaskId = Guid.NewGuid().ToString(),
                    Name = request.name,
                    Description = request.description,
                    TaskStateId = "1"
                };

                var result = _db.Tasks.Add(newTask).Entity;

                _db.SaveChanges();

                return new
                {
                    status = 200,
                    success = true,
                    data = result
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> PutTask(string id, TaskRequest request, ClaimsPrincipal User)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                UserRole? verifyRole = _db.UserRoles.FirstOrDefault(ur => (ur.RoleId == "1" || ur.RoleId == "2") && ur.UserId == userId);

                if (verifyRole == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Accion no permitida para el usuario"
                    };
                }

                Models.Task? Task = _db.Tasks.FirstOrDefault(u => u.TaskId == id);

                if (Task == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Tarea no existe"
                    };
                }

                Task.Name = request.name;
                Task.Description = request.description;
                Task.TaskStateId = request.taskStateId != null ? request.taskStateId : Task.TaskStateId;

                //var result = _db.Tasks.Update(Task);
                _db.SaveChanges();

                return new
                {
                    status = 200,
                    success = true,
                    data = Task
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> GetTask(string id)
        {
            try
            {

                Models.Task? Task = _db.Tasks.FirstOrDefault(u => u.TaskId == id);

                if (Task == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Tarea no existe"
                    };
                }


                return new
                {
                    status = 200,
                    success = true,
                    data = Task
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> GetTasks()
        {
            try
            {

                List<Models.Task> Tasks = _db.Tasks.ToList();

                return new
                {
                    status = 200,
                    success = true,
                    data = Tasks
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

        public async Task<Object> DeleteTask(string id, ClaimsPrincipal User)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                UserRole? verifyRole = _db.UserRoles.FirstOrDefault(ur => ur.RoleId == "1" && ur.UserId == userId);

                if (verifyRole == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Accion no permitida para el usuario"
                    };
                }

                Models.Task? Task = _db.Tasks.FirstOrDefault(u => u.TaskId == id);

                if (Task == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Tarea no existe"
                    };
                }

                var result = _db.Tasks.Remove(Task);
                _db.SaveChanges();

                return new
                {
                    status = 200,
                    success = true,
                    data = Task
                };

            }
            catch (Exception ex)
            {
                return new
                {
                    status = 500,
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                };
            }
        }

    }
}
