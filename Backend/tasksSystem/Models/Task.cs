using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace tasksSystem.Models;

public partial class Task
{
    public string TaskId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string TaskStateId { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual TaskState TaskState { get; set; } = null!;
    public virtual ICollection<UserTask> UserTasks { get; set; } = new List<UserTask>();
}
