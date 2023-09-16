using Runner.Application.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Runner.Application.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { set; get; }
    public virtual DbSet<Role> Roles { set; get; }
    public virtual DbSet<UserRole> UserRoles { get; set; }

    // running specific tables 
    public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }
    public virtual DbSet<Goal> Goals { get; set; }
    public virtual DbSet<JournalNote> JournalNotes { get; set; }
    public virtual DbSet<RunType> RunTypes { get; set; }
    public virtual DbSet<TemplateSchedule> TemplateSchedules { get; set; }
    public virtual DbSet<UserGoal> UserGoals { get; set; }
    public virtual DbSet<UserRunEntry> UserRunEntries { get; set; }
    public virtual DbSet<UserSchedule> UserSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // it should be placed here, otherwise it will rewrite the following settings!
        base.OnModelCreating(builder);

        // Custom application mappings
        builder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(450).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Password).IsRequired();
        });

        builder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(450).IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
        });

        builder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.RoleId);
            entity.Property(e => e.UserId);
            entity.Property(e => e.RoleId);
            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
            entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
        });

        builder.Entity<Role>().HasData(
            new Role { Id = 1, Name = CustomRoles.User },
            new Role { Id = 2, Name = CustomRoles.Admin }
        );

        /*
         * Running specific mappings
         */
        // DifficultyLevel 
        builder.Entity<DifficultyLevel>(entity =>
        {
            entity.Property(e => e.Difficulty).HasMaxLength(50).IsRequired();
            entity.HasIndex(e => e.Difficulty).IsUnique();
        });
        builder.Entity<DifficultyLevel>().HasData(
            new DifficultyLevel { Id = 1, Difficulty = "Beginner" },
            new DifficultyLevel { Id = 2, Difficulty = "Intermediate" },
            new DifficultyLevel { Id = 3, Difficulty = "Advanced" },
            new DifficultyLevel { Id = 4, Difficulty = "Pro" }
        );

        // Goal
        builder.Entity<Goal>(entity =>
        {
            entity.Property(e => e.GoalName).HasMaxLength(50).IsRequired();
            entity.HasIndex(e => e.GoalName).IsUnique();
        });
        builder.Entity<Goal>().HasData(
            new Goal { Id = 1, GoalName = "5K" },
            new Goal { Id = 2, GoalName = "10K" },
            new Goal { Id = 3, GoalName = "Half Marathon" },
            new Goal { Id = 4, GoalName = "Marathon" }
        );
    }
}