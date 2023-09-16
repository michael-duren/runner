using System.ComponentModel.DataAnnotations;

namespace Runner.Application.Models;

public class DifficultyLevel
{
    [Key] public int Id { get; set; }
    // TODO: currently range from 1-5 (1 being easiest, 5 being hardest) need to come up with names for each level 
    public string Difficulty { get; set; } = null!;
}