using System.ComponentModel.DataAnnotations;

namespace Runner.Application.Models;

public class Goal
{
    [Key] public int Id { get; set; }
    public string GoalName { get; set; } = null!;
}