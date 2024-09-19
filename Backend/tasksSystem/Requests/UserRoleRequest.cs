using System.ComponentModel.DataAnnotations;

namespace tasksSystem.Requests
{
    public class AuthRequest
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
