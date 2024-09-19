using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tasksSystem.Models;
using tasksSystem.Requests;

namespace tasksSystem.Services
{
    public interface IAuthService
    {
        Task<Object> Authentication(AuthRequest request);
        //Task<Object> testJwt(ClaimsPrincipal user);
        Task<Object> Register(UserRequest request, ClaimsPrincipal User);
    }
    public class AuthService : IAuthService
    {
        private TasksSystemDbContext _db;
        private JwtService _jwtService;
        private PasswordHasher<string> _passwordHasher;
        public AuthService(TasksSystemDbContext db, JwtService jwtService)
        {
            _db = db;
            _jwtService = jwtService;
            _passwordHasher = new PasswordHasher<string>();
        }
    
        public async Task<Object> Authentication(AuthRequest request)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == request.email && u.Password == request.password);

            if (user == null) {
                return new
                {
                    success = false,
                    status = 400,
                    message = "Email o password invalidos"
                };
            }

            var jwt = _jwtService.GenerateToken(user.UserId);

            var userRole = _db.UserRoles.FirstOrDefault(ur => ur.UserId == user.UserId).RoleId;

            return new
            {
                success = true,
                status =  200,
                data = new {
                    user = new User
                    {
                        UserId = user.UserId,
                        Email = user.Email,
                        Username = user.Username,
                        Password = user.Password,
                        Names = user.Names,
                        LastNames = user.LastNames,
                        DateOfBirth = user.DateOfBirth,
                    },
                    role = userRole,
                    token = jwt
                }
            };
        }


        public async Task<Object> Register(UserRequest request, ClaimsPrincipal User)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                UserRole? verifyRole = _db.UserRoles.FirstOrDefault(ur => ur.RoleId == "1" && ur.UserId == userId);

                if(verifyRole == null)
                {
                    return new
                    {
                        success = false,
                        status = 400,
                        message = "Accion no permitida para el usuario"
                    };
                }

                User newUser = new User
                {
                    UserId = Guid.NewGuid().ToString(),
                    Email = request.email,
                    Username = request.username,
                    Password = _passwordHasher.HashPassword(null, request.password),
                    Names = request.names,
                    LastNames = request.lastNames,
                    DateOfBirth = DateTime.Parse(request.dateOfBirth)
                };

                var user = _db.Users.FirstOrDefault(u => u.Username == request.username || u.Email == request.email);

                if (user != null)
                {
                    return new {
                        success = false,
                        status = 400,
                        message = "El email o usuario ya se encuentra registrado" };
                }

                var result = _db.Users.Add(newUser).Entity;
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
                    message = ex.InnerException?.Message ?? ex.Message,
                };
            }
        }
    }
}
