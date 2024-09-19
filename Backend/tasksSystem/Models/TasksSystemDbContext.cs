using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tasksSystem.Models;

public partial class TasksSystemDbContext : DbContext
{
    public TasksSystemDbContext()
    {
    }

    public TasksSystemDbContext(DbContextOptions<TasksSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskState> TaskStates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserTask> UserTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__role__CD98462AE6D50C49");

            entity.ToTable("role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("roleId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__task__DD5D5A42B49E525C");

            entity.ToTable("task");

            entity.Property(e => e.TaskId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("taskId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TaskStateId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("taskStateId");

            entity.HasOne(d => d.TaskState).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.TaskStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__task__taskStateI__5812160E");
        });

        modelBuilder.Entity<TaskState>(entity =>
        {
            entity.HasKey(e => e.TaskStateId).HasName("PK__task_sta__93DDE51D013CCE57");

            entity.ToTable("task_state");

            entity.Property(e => e.TaskStateId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("taskStateId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__CB9A1CFF8ABFA0FB");

            entity.ToTable("user");

            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LastNames)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastNames");
            entity.Property(e => e.Names)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("names");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__user_rol__CD3149CCACC5CFE7");

            entity.ToTable("user_role");

            entity.Property(e => e.UserRoleId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userRoleId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.RoleId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("roleId");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userId");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_role__roleI__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_role__userI__5070F446");
        });

        modelBuilder.Entity<UserTask>(entity =>
        {
            entity.HasKey(e => e.UserTaskId).HasName("PK__user_tas__F46D0ADF707B04DD");

            entity.ToTable("user_task");

            entity.Property(e => e.UserTaskId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userTaskId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("createdAt");
            entity.Property(e => e.TaskId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("taskId");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userId");

            entity.HasOne(d => d.Task).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_task__taskI__5CD6CB2B");

            entity.HasOne(d => d.User).WithMany(p => p.UserTasks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_task__userI__5BE2A6F2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
