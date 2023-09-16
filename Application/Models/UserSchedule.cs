using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

public class UserSchedule
{
    [Key] public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalRuns { get; set; } = 0;
    public int TotalDistance { get; set; } = 0;
    public int TotalTime { get; set; } = 0;
    

    // Foreign Keys
    [ForeignKey("User")] public int UserId { get; set; }
    public User User { get; set; } = null!;
}