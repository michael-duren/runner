using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

public class UserSchedule
{
    [Key] public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Foreign Keys
    [ForeignKey("User")] public int UserId { get; set; }
    public User User { get; set; } = null!;

    [ForeignKey("UserGoal")] public int UserGoalId { get; set; } // copied to UserSchedule
    public UserGoal UserGoal { get; set; } = null!;


    [ForeignKey("DifficultyLevel")] public int DifficultyLevelId { get; set; } // copied to UserRunEntry
    public DifficultyLevel DifficultyLevel { get; set; } = null!;

    /*
     * This information will be calculated using queries not stored
     */
    // public int TotalRuns { get; set; } = 0;
    // public int TotalDistance { get; set; } = 0;
    // public int TotalTime { get; set; } = 0;
}