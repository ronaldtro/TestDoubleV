using System.ComponentModel.DataAnnotations;

namespace tasksSystem.Requests
{
    public class UserTaskRequest
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public string taskId { get; set; }
    }
}
