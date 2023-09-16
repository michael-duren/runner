using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Runner.Application.Models;

public class UserGoal
{
    [Key] public int Id { get; set; }
    public DateTime DueDate { get; set; }
    public string? GoalDescription { get; set; }
    public string GoalReason { get; set; } = null!;
    
    // Foreign Keys
    [ForeignKey("User")] public int? UserId { get; set; } // reference user
    public User? User { get; set; }
    
    // Reference Goal Type
    [ForeignKey("Goal")] public int? GoalId { get; set; }
    public Goal Goal { get; set; } = null!; // a user goal must be associated with a goal type
}