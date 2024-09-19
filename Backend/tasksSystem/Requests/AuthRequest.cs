using System.ComponentModel.DataAnnotations;

namespace tasksSystem.Requests
{
    public class UserRoleRequest
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string roleId { get; set; }
    }
}
