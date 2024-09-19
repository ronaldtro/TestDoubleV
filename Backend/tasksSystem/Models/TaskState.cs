using System;
using System.Collections.Generic;

namespace tasksSystem.Models;

public partial class TaskState
{
    public string TaskStateId { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
