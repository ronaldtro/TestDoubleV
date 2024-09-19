using System;
using System.Collections.Generic;

namespace tasksSystem.Models;

public partial class UserTask
{
    public string UserTaskId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string TaskId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Task Task { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
