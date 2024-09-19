using System;
using System.Collections.Generic;

namespace tasksSystem.Models;

public partial class UserRole
{
    public string UserRoleId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
