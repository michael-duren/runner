using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

public class UserRunEntry
{
    [Key] public int Id { get; set; }
    public double Distance { get; set; }
    public DateTime DateScheduled { get; set; }
    public DateTime? DateCompleted { get; set; }
    public bool IsCompleted { get; set; }
    public double? Time { get; set; }
    public double? AveragePace { get; set; }
    public string? Notes { get; set; }

    [ForeignKey("UserSchedule")] public int UserScheduleId { get; set; }
    public UserSchedule UserSchedule { get; set; } = null!;
}