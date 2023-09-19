using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

public class TemplateSchedule
{
    [Key] public int Id { get; set; }
    public string ScheduleName { get; set; } = null!;
    [ForeignKey("Goal")] public int GoalId { get; set; } // copied to UserSchedule
    public Goal Goal { get; set; } = null!;
    public int Weeks { get; set; }

    [ForeignKey("DifficultyLevel")] public int DifficultyLevelId { get; set; } // copied to UserRunEntry
    public DifficultyLevel DifficultyLevel { get; set; } = null!;
}