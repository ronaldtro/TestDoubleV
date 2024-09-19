using System;
using System.Collections.Generic;

namespace tasksSystem.Models;

public partial class Role
{
    public string RoleId { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
