using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

/*
 * TemplateSchedule rows contain the information needed to create a UserSchedule based on a Goal and DifficultyLevel.
 * The TemplateSchedule table contains all runs for all goals and difficulty levels.
 * When creating a user schedule for a specific goal and difficulty level, the user schedule is created and contains this information
 * We then select the rows from the TemplateSchedule table that match the goal and difficulty level and copy them into the UserSchedule table
 * For each UserRunEntry in the UserSchedule table, we then create a UserRunEntry and copy the data from each template run
 * This allows us to give the user flexibility to change the schedule as needed
 */
public class TemplateSchedule
{
    [Key] public int Id { get; set; }
    public int WeekNumber { get; set; } // copied to UserRunEntry
    public int DayNumber { get; set; } // day of the week 1-7 // copied to UserRunEntry
    [Column(TypeName = "float")] public int Distance { get; set; } // copied to UserRunEntry

    // Foreign Keys
    [ForeignKey("RunType")] public int RunTypeId { get; set; }
    public RunType RunType { get; set; } = null!;

    [ForeignKey("Goal")] public int GoalId { get; set; } // copied to UserSchedule
    public Goal Goal { get; set; } = null!;

    [ForeignKey("DifficultyLevel")] public int DifficultyLevelId { get; set; } // copied to UserRunEntry
    public DifficultyLevel DifficultyLevel { get; set; } = null!;
}