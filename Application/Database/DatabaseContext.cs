using Runner.Application.Models;
using Microsoft.EntityFrameworkCore;

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
    public virtual DbSet<SchedulePhase> SchedulePhases { get; set; }
    public virtual DbSet<TemplateRunEntry> TemplateRuns { get; set; }
    public virtual DbSet<TemplateRunEntryRunType> TemplateRunRunTypes { get; set; } // join table
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

        // RunTypes
        builder.Entity<RunType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
        });
        builder.Entity<RunType>().HasData(
            new RunType
            {
                Id = 1,
                Name = "Cross-training",
                Description =
                    "Non-weight-bearing aerobic activities such as aqua-jogging, swimming, or cycling. Be sure to perform them at conversation effort for 20-40 minutes."
            },
            new RunType
            {
                Id = 2,
                Name = "Recovery Run",
                Description =
                    "Very relaxed effort over flat terrain (track or trail or walk the hills on your favorite route)"
            },
            new RunType
            {
                Id = 3,
                Name = "Semi-Long Run",
                Description = "After 2 mile warm-up (very relaxed effort), settle into conversation effort."
            },
            new RunType
            {
                Id = 4,
                Name = "Long Run",
                Description = "After 2 mile warm-up (very relaxed effort), settle into conversation effort"
            },
            new RunType
            {
                Id = 5,
                Name = "Hilly Run",
                Description = "Find some hills on your route and stay relaxed on the uphills."
            },
            new RunType
            {
                Id = 6,
                Name = "Goal Pace Run",
                Description = "8G (4-3-1) means go easy for 4 miles, 3 miles at goal pace, 1 mile cool down."
            },
            new RunType
            {
                Id = 7,
                Name = "Long Fast Run",
                Description = "7(5-1-1) means go easy for 5 miles, 1 mile at long fast pace, 1 mile cool down."
            },
            new RunType
            {
                Id = 8,
                Name = "Short fast run",
                Description = "7SF: 6X800 means to perform a track workout of six 800 meter repeats."
            },
            new RunType
            {
                Id = 9,
                Name = "Or",
                Description = "The two workouts are interchangeable. Choose the ONE that fits your schedule."
            },
            new RunType
            {
                Id = 10,
                Name = "And Optional",
                Description = "You can add this workout to the end of any of the other workouts. It is optional."
            }
        );


        // SchedulePhase
        builder.Entity<SchedulePhase>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
        });

        builder.Entity<SchedulePhase>().HasData(
            new SchedulePhase { Id = 1, Name = "Endurance" },
            new SchedulePhase { Id = 2, Name = "Strength" },
            new SchedulePhase { Id = 3, Name = "Speed" },
            new SchedulePhase { Id = 4, Name = "Taper" },
            new SchedulePhase { Id = 5, Name = "Recovery" }
        );

        // TemplateRunEntryRunTypes Many to Many
        builder.Entity<TemplateRunEntryRunType>()
            .HasKey(t => new { t.TemplateRunId, t.RunTypeId });
        builder.Entity<TemplateRunEntryRunType>()
            .HasOne(tr => tr.TemplateRunEntry)
            .WithMany(t => t.TemplateRunRunTypes)
            .HasForeignKey(tr => tr.TemplateRunId);
        builder.Entity<TemplateRunEntryRunType>()
            .HasOne(rt => rt.RunType)
            .WithMany(r => r.TemplateRunEntryRunTypes)
            .HasForeignKey(rt => rt.RunTypeId);

        // UserRunEntryRunType    
        builder.Entity<UserRunEntryRunType>()
            .HasKey(u => new { u.UserRunEntryId, u.RunTypeId });
        builder.Entity<UserRunEntryRunType>()
            .HasOne(u => u.UserRunEntry)
            .WithMany(ur => ur.UserRunEntryRunTypes)
            .HasForeignKey(ur => ur.UserRunEntryId);
        builder.Entity<UserRunEntryRunType>()
            .HasOne(u => u.RunType)
            .WithMany(rt => rt.UserRunEntryRunTypes)
            .HasForeignKey(ur => ur.RunTypeId);
    }
}