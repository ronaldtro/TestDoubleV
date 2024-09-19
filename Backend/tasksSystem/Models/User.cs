using System;
using System.Collections.Generic;

namespace tasksSystem.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Names { get; set; }

    public string? LastNames { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
