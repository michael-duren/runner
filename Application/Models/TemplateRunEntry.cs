using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

/*
 * TemplateRun rows contain the information rows that are linked to a template schedule.
 * Both of this information is needed to create a UserSchedule based on a Goal and DifficultyLevel.
 * The TemplateSchedule table contains the additional schedule information like phases and meta data.
 * When creating a user schedule for a specific goal and difficulty level, the user schedule is created and contains this information
 */

public class TemplateRunEntry
{
    [Key] public int Id { get; set; }
    public int WeekNumber { get; set; } // copied to UserRunEntry
    public int DayNumber { get; set; } // day of the week 1-7 // copied to UserRunEntry
    [Column(TypeName = "float")] public int Distance { get; set; } // copied to UserRunEntry
    public bool Race { get; set; }

    // Foreign Keys
    [ForeignKey("TemplateSchedule")] public int TemplateScheduleId { get; set; }
    public TemplateSchedule TemplateSchedule { get; set; } = null!;

    [ForeignKey("SchedulePhase")] public int SchedulePhaseId { get; set; }
    public SchedulePhase SchedulePhase { get; set; } = null!;

    // navigation properties
    public ICollection<TemplateRunEntryRunType> TemplateRunRunTypes { get; set; } = null!;
}