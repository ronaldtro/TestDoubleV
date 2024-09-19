using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using tasksSystem.Models;
using tasksSystem.Requests;

namespace tasksSystem.Services
{
    public interface IUserService
    {
        Task<Object> PutUser(string id, UserRequest request, ClaimsPrincipal User);
        Task<Object> DeleteUser(string id, ClaimsPrincipal User);
        Task<Object> GetUser(string id);
        Task<Object> GetUsers();
        Task<Object> PostUserRole(UserRoleRequest request);
        Task<Object> PostUserTask(UserTaskRequest request, ClaimsPrincipal User);
        Task<Object> GetUserTasks(ClaimsPrincipal User);
        Task<Object> PutUserTaskState(string id, TaskRequest request, ClaimsPrincipal User);
    }
    public class UserService:IUserService
    {
        private TasksSystemDbContext _db;
        private PasswordHasher<string> _passwordHasher;
        public UserService(TasksSystemDbContext db) {
            _db = db;
            _passwordHasher = new PasswordHasher<string>();
        }

        public async Task<Object> PutUser(string id, UserRequest request, ClaimsPrincipal User)
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

                User? user = _db.Users.FirstOrDefault(u => u.UserId == id);

                if (user == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Usuario no existe"
                    };
                }

                user.Email = request.email;
                user.Password = _passwordHasher.HashPassword(null, request.password);
                user.Names = request.names;
                user.LastNames = request.lastNames;
                user.DateOfBirth = DateTime.Parse(request.dateOfBirth);
                
                //var result = _db.Users.Update(user);
                _db.SaveChanges();

                return new
                {
                    status = 200,
                    success = true,
                    data = user
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

        public async Task<Object> GetUser(string id)
        {
            try
            {

                User? user = _db.Users.FirstOrDefault(u => u.UserId == id);

                if (user == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Usuario no existe"
                    };
                }


                return new
                {
                    status = 200,
                    success = true,
                    data = user
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

        public async Task<Object> GetUsers()
        {
            try
            {

                List<User> users = _db.Users.ToList();

                return new
                {
                    status = 200,
                    success = true,
                    data = users
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

        public async Task<Object> DeleteUser(string id, ClaimsPrincipal User)
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

                User? user = _db.Users.FirstOrDefault(u => u.UserId == id);

                if (user == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Usuario no existe"
                    };
                }

                var result = _db.Users.Remove(user);
                _db.SaveChanges();

                return new
                {
                    status = 200,
                    success = true,
                    data = user
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

        public async Task<Object> PostUserRole(UserRoleRequest request)
        {
            try
            {
                UserRole? searchUserRole = _db.UserRoles.FirstOrDefault(ur => ur.UserId == request.userId);

                if(searchUserRole != null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "El usuario ya posee un rol"
                    };
                }

                UserRole userRole = new UserRole
                {
                    UserRoleId = Guid.NewGuid().ToString(),
                    UserId = request.userId,
                    RoleId = request.roleId
                };

                var result = _db.UserRoles.Add(userRole).Entity;

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

        public async Task<Object> PostUserTask(UserTaskRequest request, ClaimsPrincipal User)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                UserRole? verifyRole = _db.UserRoles.FirstOrDefault(ur => ur.RoleId == "2" && ur.UserId == userId);

                if (verifyRole == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Accion no permitida para el usuario"
                    };
                }

                UserTask? searchUserTask = _db.UserTasks.FirstOrDefault(ut => ut.TaskId == request.taskId);

                if (searchUserTask != null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "El usuario ya posee la tarea"
                    };
                }

                UserTask userTask = new UserTask
                {
                    UserTaskId = Guid.NewGuid().ToString(),
                    UserId = request.userId,
                    TaskId = request.taskId
                };

                UserRole? verifyEmployee = _db.UserRoles.FirstOrDefault(ur => ur.RoleId == "3" && ur.UserId == request.userId);

                if (verifyEmployee == null) {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Las tareas solo se asignan a empleados"
                    };
                }

                var result = _db.UserTasks.Add(userTask).Entity;

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

        public async Task<Object> GetUserTasks(ClaimsPrincipal User)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                UserRole? verifyRole = _db.UserRoles.FirstOrDefault(ur => ur.RoleId == "3" && ur.UserId == userId);

                if (verifyRole == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Accion no permitida para el usuario"
                    };
                }

                List<UserTask> userTasks = _db.UserTasks.Where(ut => ut.UserId == userId).ToList();

                return new
                {
                    status = 200,
                    success = true,
                    data = userTasks
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

        public async Task<Object> PutUserTaskState(string id, TaskRequest request, ClaimsPrincipal User)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                UserRole? verifyRole = _db.UserRoles.FirstOrDefault(ur => ur.RoleId == "3" && ur.UserId == userId);

                if (verifyRole == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Accion no permitida para el usuario"
                    };
                }

                UserTask? task = _db.UserTasks.FirstOrDefault(ut => ut.TaskId == id && ut.UserId == userId);

                if(task == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Tarea no encontrada"
                    };
                }

                Models.Task? putTask = _db.Tasks.FirstOrDefault(t => t.TaskId == task.TaskId);

                putTask.TaskStateId = request.taskStateId;

                _db.Tasks.Update(putTask);
                _db.SaveChanges();

                return new
                {
                    status = 200,
                    success = true,
                    data = putTask
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
